using Northwind.Entities.Concrete;

namespace NorthwindMvc.WebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get;  set; }
    }
}
