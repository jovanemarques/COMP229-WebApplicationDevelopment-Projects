﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLsAndRoutes.Models
{
    public class Result
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public IDictionary<string, string> Data { get; } = new Dictionary<string, string>();
    }
}
