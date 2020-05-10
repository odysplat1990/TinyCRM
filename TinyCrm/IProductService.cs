using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCrm
{
    public interface IProductService
    {
        Product CreateProduct(CreateProductOptions options);

        Product UpdateProduct(UpdateProductOptions options);
        IQueryable<Product> SearchProducts(SearchProductOptions options);
        Product GetProductById(string prodId);
    }
}
