﻿using SiteX.Data.Common.Models;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Shop;
using SiteX.Services.Data.Interface;
using SiteX.Web.ViewModels.ShopViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteX.Services.Data
{
    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepo;
        private readonly IRepository<ProductCategory> productCategoryRepo;

        public ProductService(IDeletableEntityRepository<Product> productRepo,
            IRepository<ProductCategory> productCategoryRepo)
        {
            this.productRepo = productRepo;
            this.productCategoryRepo = productCategoryRepo;
        }
        public async Task CreateAsync(ProductViewModel viewModel)
        {

            var product = new Product
            {
                Name = viewModel.Name,
                User = viewModel.User,
                Description = viewModel.Description,
                Gender = viewModel.Gender,
                Locations = viewModel.Locations,
                Price = viewModel.Price,
                Pictures = viewModel.Pictures,

            };

            await this.productRepo.AddAsync(product);
            await this.productRepo.SaveChangesAsync();

            await CreatingProductCategory(viewModel, product);

        }
        public async Task CreatingProductCategory(ProductViewModel viewModel, Product product)
        {
            foreach (var item in viewModel.Categories)
            {
                var entity = new ProductCategory();
                entity.ProductId = product.Id;
                entity.CategoryId = item;

                await this.productCategoryRepo.AddAsync(entity);
            }
            await this.productCategoryRepo.SaveChangesAsync();
        }
    }
}