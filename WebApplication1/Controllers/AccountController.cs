using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;

public class AccountController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("RegistrationSuccess");
        }

        return View(model);
    }

    [AcceptVerbs("GET", "POST")]
    public IActionResult IsUsernameUnique(string username)
    {
        var existingUsernames = new[] { "admin", "testuser", "user123" };
        if (existingUsernames.Contains(username.ToLower()))
        {
            return Json(false);
        }

        return Json(true);
    }

    public IActionResult RegistrationSuccess()
    {
        return View();
    }
}