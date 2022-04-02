﻿using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteX.Services.Data
{
    public class GenderService : IGenderToDictionary
    {
        private readonly IRepository<Gender> genderRepository;
        public GenderService(IRepository<Gender> repository)
        {
            this.genderRepository = repository;
        }
        public Dictionary<string, string> GetGenderAsKVP()
        {
            var dictionary = this.genderRepository.AllAsNoTracking().Select(x => new { x.Id, x.Name }).ToDictionary(x => x.Id.ToString(), x => x.Name);
            return dictionary;
 
        }


    }
}