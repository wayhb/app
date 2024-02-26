using Microsoft.AspNetCore.Mvc;

namespace Coffee.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index(int id)
        {
            Product product = productRepository.GetById(id);

            return View();
        }
    }
}
