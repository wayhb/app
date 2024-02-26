using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;
namespace Coffee.Memory
{
    public class ProductRepository : IProductRepository
    {
        private readonly Product[] products = new[]
    {
        new Product(1, "ISBN 34242-34442", "Cappuchino", 
            "Кофейный напиток итальянской кухни на основе" +
            " эспрессо с добавлением в него подогретого до 65" +
            " градусов вспененного молока.", 100.0m),
        new Product(2, "ISBN 33334-34832", "Latte", "Кофейный напиток, который включает в себя три слоя: молочную пену, молоко и кофе эспрессо.\r\n\r\nДля изготовления латте используется порция эспрессо и вспененное молоко. Кофе может заливаться как горячим, так и холодным молоком. Соотношение эспрессо, взбитого молока и молочной пены составляет 1:2. ",
            100.0m),
        new Product(3, "ISBN 34252-34242", "Mocco", "Непосредственно напиток на основе эспрессо с добавлением молока и какао-порошка. Можно сказать, что это латте, приготовленный с какао.",
            100.0m),
    };
        public Product[] GetAllByIds(IEnumerable<int> productIds)
        {
            var foundProduct = from product in products
                             join productId in productIds on product.Id equals productId
                             select product;

            return foundProduct.ToArray();
        }


        public Product[] GetAllByIsbn(string isbn)
        {
            return products.Where(product => product.Isbn == isbn)
                .ToArray();
        }

        public Product[] GetAllByTitle(string titlePart)
        {
            return products.Where(product => product.Title.Contains(titlePart)).ToArray();
        }

        public Product GetById(int id)
        {
            return products.Single(product => product.Id == id);
        }

    }
}
