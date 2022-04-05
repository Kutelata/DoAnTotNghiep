using Microsoft.AspNetCore.Mvc;

namespace BookSocial.Presentation.Admin.Controllers
{
    public partial class HomeController
    {
        public IActionResult AuthorList()
        {
            return View("~/Views/Author/Index.cshtml");
        }

        public async Task<IActionResult> AuthorData(string search)
        {
            var data = await _authorService.GetAll();
            var handleData = data.Where(data => (data.Name != null && data.Name.Contains(search)));
            return Json(handleData);
        }

        public IActionResult DetailAuthor()
        {
            return View("~/View/Author/Detail");
        }

        public IActionResult CreateAuthor()
        {
            return View("~/Views/Author/Create.cshtml");
        }

        public IActionResult EditAuthor()
        {
            return View("~/Views/Author/Edit.cshtml");
        }
    }
}
