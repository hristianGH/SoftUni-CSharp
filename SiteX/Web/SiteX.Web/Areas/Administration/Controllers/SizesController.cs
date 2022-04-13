﻿namespace SiteX.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Web.ViewModels.ShopViewModels.SizeModels;

    public class SizesController : AdministrationController
    {
        private readonly ISizeService sizeService;

        public SizesController(ISizeService sizeService)
        {
            this.sizeService = sizeService;
        }

        public IActionResult Index()
        {
            var sizes = this.sizeService.GetSizes();
            return this.View(sizes);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SizeViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.sizeService.CreateAsync(viewModel);
            return this.Redirect("/");
        }

        public IActionResult Edit(int id)
        {
            var viewModel = this.sizeService.GetSizeById(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Size viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.sizeService.EditSizeAsync(viewModel);

            return this.Redirect("/");
        }
    }
}