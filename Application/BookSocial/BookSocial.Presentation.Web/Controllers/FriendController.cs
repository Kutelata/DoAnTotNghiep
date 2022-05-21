using BookSocial.EntityClass.Entity;
using BookSocial.EntityClass.Enum;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Web.Controllers
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
            int size = 5;
            filter = ((int)FriendStatus.Friends).ToString();

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
                    data.SingleBookCurrentlyReading = await _bookService.GetSingleBookCurrentlyReading(data.Id);
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

        public async Task<IActionResult> DeleteFriend(int userFriendId)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            int resultFromUser = await _friendService.DeleteByUserAndUserFriendId(Convert.ToInt32(userIdClaim), userFriendId);
            int resultFromUserFriend = await _friendService.DeleteByUserAndUserFriendId(userFriendId, Convert.ToInt32(userIdClaim));
            if (resultFromUser != 0 && resultFromUserFriend != 0)
            {
                TempData["Success"] = "Delete Friend success!";
            }
            else
            {
                TempData["Fail"] = "Delete Friend fail!";
            }
            return RedirectToAction("FriendList", "Home");
        }

        public async Task<IActionResult> AddFriend(int userFriendId)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var compareUserAndUserFriend = await _friendService.GetByUserAndUserFriendId(Convert.ToInt32(userIdClaim), userFriendId);
            var compareUserFriendAndUser = await _friendService.GetByUserAndUserFriendId(userFriendId, Convert.ToInt32(userIdClaim));
            if (compareUserAndUserFriend == null && compareUserFriendAndUser == null)
            {
                var friend = new Friend
                {
                    UserId = Convert.ToInt32(userIdClaim),
                    UserFriendId = userFriendId
                };
                int result = await _friendService.Create(friend);
                if (result != 0)
                {
                    TempData["Success"] = "Add friend success!";
                }
                else
                {
                    TempData["Fail"] = "Add friend fail!";
                }
            }
            else
            {
                TempData["Fail"] = "Already add this friend!";
            }
            return RedirectToAction("FriendList", "Home", new { filter = ((int)FriendStatus.Suggest).ToString() });
        }

        public async Task<IActionResult> ConfirmFriend(int userFriendId)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            var compareUserAndUserFriend = await _friendService.GetByUserAndUserFriendId(Convert.ToInt32(userIdClaim), userFriendId);
            if (compareUserAndUserFriend == null)
            {
                var friend = new Friend
                {
                    UserId = Convert.ToInt32(userIdClaim),
                    UserFriendId = userFriendId,
                };
                int result = await _friendService.Create(friend);
                if (result != 0)
                {
                    TempData["Success"] = "Confirm friend success!";
                }
                else
                {
                    TempData["Fail"] = "Confirm friend fail!";
                }
            }
            else
            {
                TempData["Fail"] = "Already confirm this friend!";
            }
            return RedirectToAction("FriendList", "Home", new { filter = ((int)FriendStatus.Request).ToString() });
        }
    }
}
