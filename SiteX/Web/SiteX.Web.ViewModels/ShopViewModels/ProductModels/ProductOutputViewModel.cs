﻿using SiteX.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteX.Web.ViewModels.ShopViewModels.ProductModels
{
    public class ProductOutputViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }


        public string Gender { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Size> Sizes { get; set; }
        public ICollection<Color> Colors { get; set; }



    }
}