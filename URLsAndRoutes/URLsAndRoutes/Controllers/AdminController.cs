using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLsAndRoutes.Models;

namespace URLsAndRoutes.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(Index)
            });
    }
}