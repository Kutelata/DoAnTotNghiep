using BookSocial.EntityClass.Enum;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.User.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> FriendList(int page = 1, string search = null, string filter = null)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var allData = await _userService.GetAllUser();
            var dataInPage = allData.Where(u => u.Id != Convert.ToInt32(userIdClaim));
            List<EntityClass.DTO.FriendList> userSuggests = new();
            List<EntityClass.DTO.FriendList> userRequests = new();
            List<EntityClass.DTO.FriendList> userFriends = new();
            int size = 2;

            if (allData != null)
            {
                foreach (var data in dataInPage)
                {
                    var compareUserAndUserFriend = await _friendService.GetByUserAndUserFriendId(Convert.ToInt32(userIdClaim), data.Id);
                    var compareUserFriendAndUser = await _friendService.GetByUserAndUserFriendId(data.Id, Convert.ToInt32(userIdClaim));
                    if (compareUserAndUserFriend == null && compareUserFriendAndUser == null)
                    {
                        userSuggests.Add(data);
                    }
                    if (compareUserAndUserFriend == null && compareUserFriendAndUser != null)
                    {
                        userRequests.Add(data);
                    }
                    if (compareUserAndUserFriend != null && compareUserFriendAndUser != null)
                    {
                        userFriends.Add(data);
                    }
                }
                if (Request.Query.ContainsKey("filter"))
                {
                    if (Request.Query["filter"].ToString() != null && Request.Query["filter"].ToString() != "")
                    {
                        var isNumeric = int.TryParse(Request.Query["filter"].ToString(), out int number);
                        if (isNumeric)
                        {
                            filter = Request.Query["filter"].ToString();
                        }
                        else
                        {
                            filter = ((int)FriendStatus.Friends).ToString();
                        }
                    }
                }
                if (filter != null && filter != "")
                {
                    switch (Convert.ToInt32(filter))
                    {
                        case (int)FriendStatus.Suggest: dataInPage = userSuggests; break;
                        case (int)FriendStatus.Request: dataInPage = userRequests; break;
                        case (int)FriendStatus.Friends: dataInPage = userFriends; break;
                    }
                }

                if (Request.Query.ContainsKey("search"))
                {
                    var newSearch = Request.Query["search"].ToString();
                    search = newSearch;
                }
                if (search != null)
                {
                    dataInPage = dataInPage.Where(data =>
                        (data.Id.ToString() == search) ||
                        (data.Name != null && data.Name.Contains(search)) ||
                        (data.Image != null && data.Image.Contains(search)) ||
                        (data.Description != null && data.Description.Contains(search)) ||
                        (data.Gender.ToString() == search) ||
                        (data.Status.ToString() == search));
                }

                int pages = (int)Math.Ceiling((double)dataInPage.Count() / size);
                ViewBag.Pages = pages;

                if (Request.Query.ContainsKey("page"))
                {
                    var newPage = Convert.ToInt32(Request.Query["page"].ToString());
                    page = newPage;
                }
                if (page > pages)
                {
                    page = pages;
                }
                if (page <= 0)
                {
                    page = 1;
                }
                dataInPage = dataInPage.Skip((page - 1) * size).Take(size);
            }

            ViewBag.CurrentPage = page;
            ViewBag.CurrentSearch = search;
            ViewBag.CurrentFilter = filter;
            return View("~/Views/Friend/Index.cshtml", dataInPage);
        }
    }
}
