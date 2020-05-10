using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCrm
{
    public class ProductService : IProductService
    {
        private TinyCrmDbContext context_;

        public ProductService(TinyCrmDbContext context)
        {
            context_ = context;
        }
        public Product CreateProduct(CreateProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var product = new Product()
            {
                ProductId = options.ProductId,
                Name = options.Name,
                Price = options.Price
            };

            context_.Add(product);

            if (context_.SaveChanges() > 0)
            {
                return product;
            }

            return null;
        }

        public IQueryable<Product> SearchProducts(SearchProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var query = context_
                 .Set<Product>()
                 .AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.ProductId))
            {
                query = query.Where(p => p.ProductId == options.ProductId);
            }

            if (options.PriceFrom != null)
            {
                query = query.Where(p => p.Price >= options.PriceFrom);
            }

            if (options.PriceTo != null)
            {
                query = query.Where(p => p.Price <= options.PriceTo);
            }

            if (options.Category != null)
            {
                query = query.Where(p => p.Category == options.Category);
            }

            query = query.Take(500);

            return query;
        }

        public Product UpdateProduct(UpdateProductOptions options)
        {
            if (options == null)
            {
                return null;
            }

            var product = SearchProducts(new SearchProductOptions()
            {
                ProductId = options.ProductId
            }).SingleOrDefault();

            if (product == null)
            {
                return null;
            }

            if (options.Name != null)
            {
                product.Name = options.Name;
            }
            if (options.Price != null)
            {
                product.Price = options.Price.Value;
            }
            if (options.Category != null)
            {
                product.Category = options.Category.Value;
            }

            context_.SaveChanges();

            return product;
        }

        public Product GetProductById(string prodId)
        {
            if (prodId == null)
            {
                return null;
            }

            var product = SearchProducts(new SearchProductOptions()
            {
                ProductId = prodId
            });

            if (product == null)
            {
                return null;
            }

            return product.SingleOrDefault();
        }
    }
}
