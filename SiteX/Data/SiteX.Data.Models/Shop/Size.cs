﻿using SiteX.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteX.Data.Models.Shop
{
    public class Size:BaseModel<int>
    {
        public string Name { get; set; }
    }
}