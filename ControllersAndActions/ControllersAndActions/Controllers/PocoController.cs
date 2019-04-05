﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersAndActions.Controllers
{
    public class PocoController//:Controller
    {
        [ControllerContext]
        public ControllerContext ControllerContext { get; set; }
        //public string Index() => "This is POCO controller";

        //public ViewResult Index()
        //{
        //    return new ViewResult()
        //    {
        //        ViewName = "Result",
        //        ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),
        //                   new ModelStateDictionary())
        //        {
        //            Model = "This is a POCO controller"
        //        }
        //    };
        //}

        //public ViewResult Index() => View("Result", "This is my POCO controller 3");

        public ViewResult Headers()
        {
            return new ViewResult()
            {
                ViewName = "DictionaryResult",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(),
                           new ModelStateDictionary())
                {
                    Model = ControllerContext.HttpContext.Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First())
                }
            };
        }
    }
}
