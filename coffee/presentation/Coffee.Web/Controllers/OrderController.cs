using Coffee.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Сoffee;

namespace Coffee.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);

                OrderModel model = null;

                return View(model);
            }
            return View("Empty");
        }

        public IActionResult SendConfirmationCode(int id, string cell) 
        {
            var order = orderRepository.GetById(id);
            var model = Map(order);

            if(!IsValidCellPhone(cellphone))
            {
                model.Errors["cellPhone"] = "Номер телефона не соответствует";
                return View("Index", model);
            }

            int code = 1111;
            HttpContext.Session.SetInt32(cellPhone, code);
            notificationService.SendConfirmationCode(cellPhone, code);

            return View("Confirmation", new ConfirmationModel { CellPhone = cellPhone});
        }
        public IActionResult AddItem(int id)
        {
            

            Order order;
            Cart cart;

            if(HttpContext.Session.TryGetCart(out cart)) 
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }
            var product = productRepository.GetById(id);
            order.AddItem(product, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);
            return RedirectToAction("Index", "Product", new {id }); 
        }
    }
}
