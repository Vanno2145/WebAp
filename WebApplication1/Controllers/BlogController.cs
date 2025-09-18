using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using WebApplication1.Models;

namespace MyBlogMvc.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var newsList = new List<News>
            {
                new News
                {
                    Title = "Первая новость",
                    Content = "Это содержание первой новости.",
                    PublicationDate = DateTime.Now.AddDays(-2)
                },
                new News
                {
                    Title = "Вторая новость",
                    Content = "Это содержание второй новости.",
                    PublicationDate = DateTime.Now.AddDays(-1)
                },
                new News
                {
                    Title = "Третья новость",
                    Content = "Это содержание третьей новости.",
                    PublicationDate = DateTime.Now
                }
            };

            return View(newsList);
        }

        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetTheme(string theme)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddYears(1),
                IsEssential = true
            };

            Response.Cookies.Append("theme", theme, options);

            return RedirectToAction("Index");
        }
    }
}