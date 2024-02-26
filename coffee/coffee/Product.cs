using System;
using System.Text.RegularExpressions;
namespace Coffee
{
    public class Product
    {
        public int Id { get; }

        public string Isbn {  get; }
        public string Title { get; }
        public string Description { get; }

        public decimal Price { get; }
        public Product(int id, string isbn, string title, string description, decimal price)
        {
            Title = title;
            Id = id;
            Isbn = isbn;
            Price = price;
            Description = description;
        }
        internal static bool IsIsbn(string s)
        {
            if(s==null)
            {
                return false;
            }
            s = s.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");

        }
    }
}
