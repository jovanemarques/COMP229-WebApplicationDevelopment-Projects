﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SoccerManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();                                                                                                                                                                                                                                          
        }
        public ViewResult Club()
        {
            return View();
        }
        public ViewResult AddClub()
        {
            return View();
        }
        public ViewResult ShowClubDetails()
        {
            return View();
        }
        public ViewResult ManagePlayers()
        {
            return View();
        }
    }
}