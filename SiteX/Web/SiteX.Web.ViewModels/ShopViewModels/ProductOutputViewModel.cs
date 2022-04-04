﻿using SiteX.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteX.Web.ViewModels.ShopViewModels
{
    public class ProductOutputViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int Categoryid { get; set; }
        public Category Category{ get; set; }


        public ICollection<Location> Locations { get; set; }


    }
}