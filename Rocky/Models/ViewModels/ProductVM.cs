﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product{ get; set; }
        public IEnumerable<SelectListItem> CategoryDropDown { get; set; }
    }
}
