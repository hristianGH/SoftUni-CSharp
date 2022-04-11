﻿namespace SiteX.Services.Data.ShopService
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;

    public class ProductSizeService : IProductSizeService
    {
        private readonly IDeletableEntityRepository<ProductSize> prodSizeRepo;

        public ProductSizeService(IDeletableEntityRepository<ProductSize> prodSizeRepo)
        {
            this.prodSizeRepo = prodSizeRepo;
        }

        public async Task CreatingProductSizeAsync(ICollection<int> sizes, Guid product)
        {
            foreach (var item in sizes)
            {
                var entity = new ProductSize();
                entity.ProductId = product;
                entity.SizeId = item;

                await this.prodSizeRepo.AddAsync(entity);
            }

            await this.prodSizeRepo.SaveChangesAsync();
        }
    }
}
