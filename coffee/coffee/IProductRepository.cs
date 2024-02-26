using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee
{
    public interface IProductRepository
    {
        Product[] GetAllByIsbn(string isbn);
        Product[] GetAllByTitle(string titlePart);
        Product GetById(int id);
        Product[] GetAllByIds(IEnumerable<int> productIds);
    }
}
