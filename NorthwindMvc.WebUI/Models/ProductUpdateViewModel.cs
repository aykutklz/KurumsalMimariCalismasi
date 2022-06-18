using Northwind.Entities.Concrete;

namespace NorthwindMvc.WebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get;  set; }
        public List<Category> Categories { get;  set; }
    }
}
