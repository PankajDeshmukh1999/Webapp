using System.ComponentModel.DataAnnotations;

namespace eShopOrder.Models
{
    public class Order
    {
  
        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        public string? CustomerName { get; set; }
        public string? Item { get; set; }
        public int TotalAmount { get; set; }

    }
}
