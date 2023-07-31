using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        public IActionResult GetAllBook()
        {
            return View();
        }
    }
}
