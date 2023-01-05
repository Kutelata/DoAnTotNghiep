using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Cms.Controllers
{
    public partial class HomeController
    {
        [Authorize(Policy = "Admin and Library Manager")]
        [HttpPost]
        public async Task<IActionResult> AssignAuthorToBook(AuthorBook authorBook)
        {
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
                    return RedirectToAction("DetailBook", "Home", new { id = authorBook.BookId });
                }
                else
                {
                    TempData["Fail"] = "Gán tác giả thất bại!";
                }
            }
            else
            {
                TempData["Fail"] = "Gán tác giả thất bại!";
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Authorize(Policy = "Admin and Library Manager")]
        public async Task<IActionResult> DeleteAuthorFromBook(int bookId, int authorId)
        {
            int result = await _authorBookService.Delete(bookId, authorId);
            if (result != 0)
            {
                TempData["Success"] = "Gỡ tác giả thành công!";
                return RedirectToAction("DetailBook", "Home", new { id = bookId });
            }
            TempData["Fail"] = "Gỡ tác giả thất bại!";
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
