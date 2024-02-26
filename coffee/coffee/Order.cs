using Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сoffee
{
    public class Order
    {
        public int Id { get; }
        // в данном случае состояние класса останется корректным
        private List<OrderItem> items;

        public IReadOnlyCollection<OrderItem> Items { get { return items; } }

        public int TotalCount
        { get { return items.Sum(item => item.Count); } }
        public decimal TotalPrice
        { get { return items.Sum(item => item.Price * item.Count); } }

        // IEnumerable - итератор , который скрывает данные, но можно с помощью него перебрать всю коллекцию
        public Order(int id, IEnumerable<OrderItem> items) 
        {
            if(items ==null)
                throw new ArgumentNullException(nameof(items));
            Id = id;

            this.items = new List <OrderItem>(items);
        }

        public void AddItem(Product product, int count)
        {
            if(product == null) 
                throw new ArgumentNullException(nameof(product));
            var item = items.SingleOrDefault(x => x.ProductId == product.Id);

            if(item == null)
            {
                items.Add(new OrderItem(product.Id, count, product.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(product.Id, count + item.Count, product.Price));
            }
                
        }
    }
}
