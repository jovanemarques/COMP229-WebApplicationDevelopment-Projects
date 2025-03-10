﻿using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cart)
        {
            this.cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
