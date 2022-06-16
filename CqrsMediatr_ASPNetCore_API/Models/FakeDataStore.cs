namespace CqrsMediatr_ASPNetCore_API.Models
{
    public class FakeDataStore
    {
        public static List<Product> _products { get; set; }
        public FakeDataStore()
        {
            _products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Test Name 1" },
                new Product() { Id = 2, Name = "Test Name 2" },
                new Product() { Id = 3, Name = "Test Name 3" },
                new Product() { Id = 4, Name = "Test Name 4" },
                new Product() { Id = 5, Name = "Test Name 5" },
            };
        }

        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);
        public async Task<Product> GetProductById(int id) => await Task.FromResult(_products.Single(p => p.Id == id));
        public async Task<Product> UpdateProduct(Product product)
        {
            var value = _products.SingleOrDefault(p => p.Id == product.Id);
            var updatedProduct = new Product() { Id = product.Id, Name = product.Name };
            if (value != null)
            {
                _products.Remove(value);
                _products.Add(updatedProduct);
                var updatedValue = _products.Single(p => p.Id == product.Id);
                return await Task.FromResult(updatedValue);
            }
            else
            {
                return new Product() { };
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var value = _products.SingleOrDefault(p => p.Id == id);
            if (value != null)
            {
                _products.Remove(value);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
