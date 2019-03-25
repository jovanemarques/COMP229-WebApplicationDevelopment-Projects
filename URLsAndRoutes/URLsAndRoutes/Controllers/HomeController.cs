using Microsoft.AspNetCore.Mvc;
using URLsAndRoutes.Models;

namespace URLsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(string id)
        {
            Result result = new Result()
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            };
            result.Data["Id"] = id ?? "<no value>";
            result.Data["allElse"] = RouteData.Values["allElse"]?.ToString() ?? "<no more segments>";
            return View("Result", result);
        }
    }
}