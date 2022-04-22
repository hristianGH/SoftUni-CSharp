﻿namespace SiteX.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Web.ViewModels.ShopViewModels.ProductModels;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductImageService productImageService;
        private readonly IProductListService toListService;

        public ProductsController(
            IProductService productService,
            UserManager<ApplicationUser> userManager,
            IProductImageService productImageService,
            IProductListService toListService)
        {
            this.productService = productService;
            this.userManager = userManager;
            this.productImageService = productImageService;
            this.toListService = toListService;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> All(int id = 1)
        {
            ProductAllViewModel productViewModel = new ProductAllViewModel() { Products = await this.productService.ToPageAsync(id, 6), PageNumber = id, ItemsPerPage = 6 };
            productViewModel.ItemsCount = await this.productService.GetProductCountAsync();
            productViewModel.ToSelectList = await this.toListService.ToSelectListAsync();
            return this.View(productViewModel);
        }

        public async Task<IActionResult> SearchByCategory(int id = 1)
        {
            ProductAllViewModel productViewModel = new ProductAllViewModel()
            {
                Products = this.productService.FilterByCategoryId(id),
            };
            productViewModel.ItemsCount = await this.productService.GetProductCountAsync();
            productViewModel.ToSelectList = await this.toListService.ToSelectListAsync();

            if (productViewModel != null)
            {
                return this.View("All", productViewModel);
            }

            return this.NotFound();
        }

        public async Task<IActionResult> SearchByGender(string id = "Male")
        {
            ProductAllViewModel productViewModel = new ProductAllViewModel()
            {
                Products = this.productService.FilterByGenderId(id),
            };

            productViewModel.ItemsCount = await this.productService.GetProductCountAsync();
            productViewModel.ToSelectList = await this.toListService.ToSelectListAsync();

            if (productViewModel != null)
            {
                return this.View("All", productViewModel);
            }

            return this.NotFound();
        }

        public   async Task<IActionResult> SearchByColor(int id = 1)
        {
            ProductAllViewModel productViewModel = new ProductAllViewModel()
            {
                Products = this.productService.FilterByColorId(id),
            };
            productViewModel.ItemsCount = await this.productService.GetProductCountAsync();
            productViewModel.ToSelectList = await this.toListService.ToSelectListAsync();

            if (productViewModel != null)
            {
                return this.View("All", productViewModel);
            }

            return this.NotFound();
        }

        public async Task<IActionResult> SearchBySize(int id = 1)
        {
            ProductAllViewModel productViewModel = new ProductAllViewModel()
            {
                Products = this.productService.FilterBySizeId(id),
            };
            productViewModel.ItemsCount = await this.productService.GetProductCountAsync();
            productViewModel.ToSelectList = await this.toListService.ToSelectListAsync();

            if (productViewModel != null)
            {
                return this.View("All", productViewModel);
            }

            return this.NotFound();
        }

        public async Task<IActionResult> ById(Guid id)
        {
            var product = this.productService.GetOutputProductById(id);
            this.ViewBag.ImageOne =await this.productImageService.GetImagesByProductIdAsync(id).Select(x => x.Path).FirstOrDefault();
            this.ViewBag.Images =await this.productImageService.GetImagesByProductIdAsync(id).Select(x => x.Path).Skip(1);
            var viewmodel = new BuyingProductViewModel() { ProductId = product.Id, Product = product };

            viewmodel.CategoriesToList = product.Categories;
            viewmodel.LocationsToList = product.Locations;
            viewmodel.SizesToList = product.Sizes;
            viewmodel.ColorsToList = product.Colors;

            return this.View(viewmodel);
        }

        [HttpPost]
        public IActionResult ById(BuyingProductViewModel viewmodel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction("Buy", viewmodel);
        }

        public IActionResult Buy(BuyingProductViewModel viewModel)
        {
            var prod = viewModel.Product;
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(Product viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.productService.BuyProductAsync(viewModel);
            return this.RedirectToAction("All");
        }
    }
}