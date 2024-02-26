using Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace Сoffee
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product[] GetAllByQuery(string query)
        {
            if(Product.IsIsbn(query))
                return productRepository.GetAllByIsbn(query);
            return productRepository.GetAllByTitle(query);
        }
    }
}
