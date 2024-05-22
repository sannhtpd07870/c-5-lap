namespace Lap3.Models
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
    }

    public class ProductService : IProductService
    {
        public List<ProductViewModel> GetAllProducts()
        {
            // Giả sử bạn có một danh sách mẫu dữ liệu
            var products = new List<ProductViewModel>
        {
            new ProductViewModel { Id = 1, Name = "Product 1" },
            new ProductViewModel { Id = 2, Name = "Product 2" },
            new ProductViewModel { Id = 3, Name = "Product 3" }
        };

            return products;
        }
    }

}
