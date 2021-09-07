using Microsoft.AspNetCore.Mvc;

namespace Management.MVC.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult ErrorHandler(string code)
        {
            switch (code)
            {
                case "404":
                    return RedirectToAction("Error",
                        new { errMsg = "Page not found", statusCode = code });
                case "401":
                    return RedirectToAction("Error",
                        new { errMsg = "Unauthorized access!", statusCode = code });
                case "302":
                    return RedirectToAction("Error",
                        new { errMsg = "Sorry, some redirecting issues came up.", statusCode = code });
                default:
                    return RedirectToAction("Error",
                        new { errMsg = "Hmm... something went wrong", statusCode = code });
            }
        }

        public IActionResult Index()
        {
            ViewBag.ErrorMessage = "Sorry, an error occured. We are working on it.";
            ViewBag.StatusCode = 500;
            return View();
        }

        public IActionResult Error(string statusCode, string errMsg)
        {
            ViewBag.ErrorMessage = errMsg;
            ViewBag.StatusCode = statusCode;
            return View();
        }
    }
}