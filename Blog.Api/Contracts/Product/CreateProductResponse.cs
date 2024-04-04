using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Contracts.Product
{
    public record CreateProductResponse(Guid id, string name, double price, string currency, string sku);

}