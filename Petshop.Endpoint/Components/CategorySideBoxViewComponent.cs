using Microsoft.AspNetCore.Mvc;
using Petshop.Contract.Categories;
using Petshop.Endpoint.Models.Categories;

namespace Petshop.Endpoint.Components
{
    public class CategorySideBoxViewComponent : ViewComponent
    {
        private readonly CategoryRepository categoryRepository;

        public CategorySideBoxViewComponent(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var viewModel = new CategorySideBoxViewModel
            {
                categories = categoryRepository.GetAllCategories(),

            };
            if (RouteData?.Values.ContainsKey("category") == true)
            {
                viewModel.currentCategory = RouteData.Values["category"].ToString();
                    
            }
                return View(viewModel);
        }
    }
}
