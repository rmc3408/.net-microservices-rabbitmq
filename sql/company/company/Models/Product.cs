using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace company.Models
{
    [Table("product")]
    public class Product
    {
        [Column("Id")]
        [Display(Name = "Product ID")]
        public int Id { get; set; }

        [Column("Name")]
        [Display(Name = "Product Name")]
        public string? productName { get; set; }
    }
}
