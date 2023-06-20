using CircuitCruisers.Helpers.Repositories;
using CircuitCruisers.Models.Dtos;
using CircuitCruisers.Models.Entities;
using CircuitCruisers.Models.ViewModels;
using System.Diagnostics;

namespace CircuitCruisers.Helpers.Services
{
    public class ProductService
    {

        private readonly ProductEntityRepository _productEntityRepository;

        public ProductService(ProductEntityRepository productEntityRepo)
        {
            _productEntityRepository = productEntityRepo;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var items = await _productEntityRepository.GetAllAsync();
            var list = new List<Product>();
            foreach (var item in items)
            {
                var tagList = new List<string>();
                foreach (var tag in item.Tags)

                    tagList.Add(tag.Tag.TagName);
               
                    list.Add(new Product
                    {
                        ArticleNumber = item.ArticleNumber,
                        ProductName = item.ProductName,
                        Description = item.Description,
                        Ingress = item.Ingress,
                        Tags = tagList,
                        VendorName = item.VendorName,
                        BarCode = item.BarCode,

                    });            
            }

            return list;
        }

        public async Task<IEnumerable<Product>> GetAllByTagNameAsync(string tagName)
        {
            var items = await _productEntityRepository.GetAllAsync();
            var list = new List<Product>();
            foreach (var item in items)
            {
                var tagList = new List<string>();
                foreach (var tag in item.Tags)
                
                    tagList.Add(tag.Tag.TagName);

                if (tagList.Contains(tagName))
                {
                    list.Add(new Product
                    {
                        ArticleNumber = item.ArticleNumber,
                        ProductName = item.ProductName,
                        Description = item.Description,
                        Ingress = item.Ingress,
                        Tags = tagList,
                        VendorName = item.VendorName,
                        BarCode = item.BarCode,
                        

                    });
                }
                        

            }

            return list;
        }

        public async Task<ProductEntity> CreateProductAsync(CreateProductViewModel product)
        {

            var createProduct = new ProductEntity()
            {
                ArticleNumber = product.ArticleNumber,
                ProductName = product.ProductName,
                Ingress = product.Ingress,
                VendorName = product.VendorName,
                Description = product.Description,
                BarCode = product.BarCode,
                             
            };

            await _productEntityRepository.AddAsync(createProduct);

            return createProduct;
        }

        public async Task<Product> GetAsync(string articleNumber)
        {
            var item = await _productEntityRepository.GetAsync(x => x.ArticleNumber == articleNumber);
            
                var tagList = new List<string>();

                foreach (var tag in item.Tags)
                    tagList.Add(tag.Tag.TagName);

                var product = new Product
                {
                    ArticleNumber = item.ArticleNumber,
                    ProductName = item.ProductName,
                    Description = item.Description,
                    Ingress = item.Ingress,
                    Tags = tagList,
                    VendorName = item.VendorName,
                    BarCode = item.BarCode,

                };

            return product;
            
        }
    }
}
