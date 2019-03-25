using Microsoft.AspNetCore.Mvc;
using URLsAndRoutes.Models;

namespace URLsAndRoutes.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });
    }
}
