using Microsoft.AspNetCore.Mvc;
using Petshop.Contract.Products;
using Petshop.Endpoint.Models.Products;

namespace Petshop.Endpoint.Components
{
    public class CategorySideBoxViewComponent : ViewComponent
    {
        private readonly ProductRepository productRepository;

        public CategorySideBoxViewComponent(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IViewComponentResult Invoke()
        {
            var viewModel = new CategorySideBoxViewModel();
            if (RouteData?.Values["category"] != null)
            {
                object? routeData = RouteData?.Values["category"];
                viewModel = new CategorySideBoxViewModel
                {
                    Data = productRepository.GetAllCategories(),
                    routeCategory = routeData.ToString()
                };
                return View(viewModel);

            }
            viewModel = new CategorySideBoxViewModel
            {
                Data = productRepository.GetAllCategories(),
                routeCategory = ""
            };
            return View(viewModel);
        }
    }
}
