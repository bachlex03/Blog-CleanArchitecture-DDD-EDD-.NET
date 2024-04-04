using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Domain;

namespace Blog.Infrastructure.data.Sqlite
{
    public class ProductRepository : IProductRepository
    {
        public Task Add(Product product)
        {
            throw new NotImplementedException();
        }
    }
}