﻿namespace SiteX.Web.ViewModels.ShopViewModels.ProductModels
{
    using System;

    public class BuyingProductViewModel : ToSelectList
    {
        public ProductOutputViewModel Product { get; set; }

        public Guid ProductId { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }
    }
}
