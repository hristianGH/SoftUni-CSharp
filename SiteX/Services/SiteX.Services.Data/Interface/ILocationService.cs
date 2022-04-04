﻿using SiteX.Web.ViewModels.ShopViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiteX.Services.Data.Interface
{
    public interface ILocationService
    {
        Dictionary<string, string> GetLocationAsKVP();
        public IEnumerable<string> GetLocations();
        public Task CreateAsync(LocationViewModel viewModel);


        //ToDO MAKE I CATEGORY,IGENDER,ILOCATION,IPICTURES SERVICES ONE MAIN KEYVALUEPAIR SERVICE INTERFACE
    }
}