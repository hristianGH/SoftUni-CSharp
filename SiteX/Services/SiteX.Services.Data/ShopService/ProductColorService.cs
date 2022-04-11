﻿namespace SiteX.Services.Data.ShopService
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;

    public class ProductColorService : IProductColorService
    {
        private readonly IDeletableEntityRepository<ProductColor> prodColorRepo;

        public ProductColorService(IDeletableEntityRepository<ProductColor> prodColorRepo)
        {
            this.prodColorRepo = prodColorRepo;
        }

        public async Task CreatingProductColorAsync(ICollection<int> colors, Guid product)
        {
            foreach (var item in colors)
            {
                var entity = new ProductColor();
                entity.ProductId = product;
                entity.ColorId = item;

                await this.prodColorRepo.AddAsync(entity);
            }

            await this.prodColorRepo.SaveChangesAsync();
        }
    }
}
