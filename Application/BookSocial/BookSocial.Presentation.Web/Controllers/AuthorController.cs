using BookSocial.EntityClass.Entity;
using BookSocial.Presentation.Web.Helper;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Web.Controllers
{
    public partial class HomeController
    {
        public async Task<IActionResult> AuthorProfile(int authorId)
        {
            var author = await _authorService.GetById(authorId);
            if (author != null)
            {
                var bookByAuthorId = await _bookService.GetBookListByAuthorId(authorId);
                EntityClass.DTO.AuthorProfile authorProfile = _mapper.Map<EntityClass.DTO.AuthorProfile>(author);

                authorProfile.BookListByAuthorId = bookByAuthorId.ToList();
                return View("~/Views/Author/Index.cshtml", authorProfile);
            }
            else
            {
                return RedirectToAction("Error", "Route");
            }

        }

        public async Task<IActionResult> AuthorData(string search)
        {
            var data = await _authorService.GetAll();
            var handleData = data.Where(data => (data.Name != null && data.Name.Contains(search)));
            return Json(handleData);
        }

        public async Task<IActionResult> SearchAuthor(int page = 1, string search = null)
        {
            var allData = await _authorService.GetSearchAuthor();
            var dataInPage = allData;
            int size = 2;

            if (allData != null)
            {
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
                        (data.Birthday != null && data.Birthday.ToString().Contains(search)) ||
                        data.BookHaveBeenWrittens.ToString() == search);
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
            return View("~/Views/Search/SearchByAuthor.cshtml", dataInPage);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(Author author, IFormFile Image)
        {
            if (author != null)
            {
                var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
                double numberBooksOnShelf = await _shelfService.GetTotalReadByUserId(Convert.ToInt32(userIdClaim));
                if (numberBooksOnShelf < 10)
                {
                    TempData["Fail"] = "Người dùng phải đọc tối thiểu 10 cuốn sách mới có quyền thêm sách!";
                    return Redirect(Request.Headers["Referer"].ToString());
                }
                if (String.IsNullOrEmpty(author.Name))
                {
                    TempData["Fail"] = "Tên tác giả không được để trống!";
                    return Redirect(Request.Headers["Referer"].ToString());
                }
                else
                {
                    if (Image != null)
                    {
                        Random random = new();
                        int randomNumber = random.Next(0, 1000);
                        string convertAuthorName = StringHelper
                            .RemoveSign4VietnameseString(author.Name).Replace(" ", "").ToLower();
                        author.Image = $"{randomNumber}_{convertAuthorName}.jpg";
                    }
                    int result = await _authorService.Create(author);
                    if (result != 0)
                    {
                        if (Image != null && Image.Length > 0)
                        {
                            var pathAuthor = Path.Combine(
                                Directory.GetParent(Directory.GetCurrentDirectory()).FullName,
                                @"BookSocial.Presentation.Cms\wwwroot\assets\images\author");
                            var imagePath = Path.Combine(pathAuthor, author.Image);
                            using (var stream = new FileStream(imagePath, FileMode.Create))
                            {
                                await Image.CopyToAsync(stream);
                            }
                        }
                        TempData["Success"] = "Thêm tác giả thành công!";
                    }
                    else
                    {
                        TempData["Fail"] = "Thêm tác giả thất bại!";
                    }
                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }
            TempData["Fail"] = "Dữ liệu rỗng!";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public async Task<IActionResult> AssignAuthorToBook(AuthorBook authorBook)
        {
            var userIdClaim = User.Claims.Where(c => c.Type == "Id").Select(c => c.Value).SingleOrDefault();
            double numberBooksOnShelf = await _shelfService.GetTotalReadByUserId(Convert.ToInt32(userIdClaim));
            if (numberBooksOnShelf < 10)
            {
                TempData["Fail"] = "Người dùng phải đọc tối thiểu 10 cuốn sách mới có quyền thêm sách!";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            if (authorBook.BookId == 0 || authorBook.AuthorId == 0)
            {
                TempData["Fail"] = "Bạn phải nhập chính xác!";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            var checkAuthorBook = await _authorBookService.GetByAuthorBookId(authorBook.BookId, authorBook.AuthorId);
            if (checkAuthorBook == null)
            {
                int result = await _authorBookService.Create(authorBook);
                if (result != 0)
                {
                    TempData["Success"] = "Gán tác giả thành công!";
                    return Redirect(Request.Headers["Referer"].ToString());
                }
                else
                {
                    TempData["Fail"] = "Gán tác giả thất bại!";
                }
            }
            else
            {
                TempData["Fail"] = "Gán tác giả thất bại, tác giả đã được gán!";
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
