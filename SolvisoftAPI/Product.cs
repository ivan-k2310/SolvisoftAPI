using System.ComponentModel.DataAnnotations.Schema;

namespace SolvisoftAPI
{
    public class Product
    {
       public int ProductId { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
