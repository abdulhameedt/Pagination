using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pagination.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private List<Product> productTable = new List<Product>();
        public ProductsController()
        {
            for (int i=1 ; i <= 100; i++)
            {
                productTable.Add(new Product { Id= i,Name = "Product " + i,Price = i*1.5m });
            }
        }
        [HttpGet]
        public IEnumerable<Product> Get(int page=1, int pageSize=10)
        {
            var totalCount = productTable.Count;
            var totalPages = (int)Math.Ceiling((decimal) totalCount / pageSize);
            var productsPerPage = productTable.Skip((page -1) * pageSize).Take(pageSize).ToList();
            return productsPerPage;
        }
       
    }
}
