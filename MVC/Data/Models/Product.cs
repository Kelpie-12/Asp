using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Data.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("ProductName")]
        public required string Name { get;set; }
        public  string ?Description { get;set; }
        public  decimal? Price { get;set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public List<Review> Reviews { get; set; } = new List<Review>();

    }
}
