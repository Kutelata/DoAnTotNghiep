using BookSocial.EntityClass.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        [Authorize(Policy = "Library Manager")]
        [HttpPost]
        public async Task<IActionResult> AssignAuthorToBook(AuthorBook authorBook)
        {
            if (authorBook.BookId == 0 || authorBook.AuthorId == 0)
            {
                TempData["Fail"] = "You must enter correctly!";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            var checkAuthorBook = await _authorBookService.GetByAuthorBookId(authorBook.BookId, authorBook.AuthorId);
            if (checkAuthorBook == null)
            {
                int result = await _authorBookService.Create(authorBook);
                if (result != 0)
                {
                    TempData["Success"] = "Assign author success!";
                    return RedirectToAction("DetailBook", "Home", new { id = authorBook.BookId });
                }
                else
                {
                    TempData["Fail"] = "Assign author fail!";
                }
            }
            else
            {
                TempData["Fail"] = "Author is assigned!";
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Authorize(Policy = "Library Manager")]
        public async Task<IActionResult> DeleteAuthorFromBook(int bookId, int authorId)
        {
            int result = await _authorBookService.Delete(bookId, authorId);
            if (result != 0)
            {
                TempData["Success"] = "Delete author from book success!";
                return RedirectToAction("DetailBook", "Home", new { id = bookId });
            }
            TempData["Fail"] = "Delete author from book fail!";
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
