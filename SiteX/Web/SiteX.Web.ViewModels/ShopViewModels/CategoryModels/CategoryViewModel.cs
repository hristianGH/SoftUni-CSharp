﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiteX.Web.ViewModels.ShopViewModels.CategoryModels
{
    public class CategoryViewModel
    {
        
        [Required, MaxLength(100), MinLength(3)]
        public string Name { get; set; }
    }
}