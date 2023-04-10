using Microsoft.AspNetCore.Mvc.Rendering;

namespace WAD_MVC_11359.Models
{
    public class CustomerOrderViewModel
    {
        public Order Order { get; set; }
        public SelectList Customer { get; set; }

    }
}
