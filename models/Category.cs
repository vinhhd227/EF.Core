using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcore
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        // Colect Navigation
        public virtual List<Product> Products { get; set; }
        public CategoryDetail CategoryDetail { get; set; }
    }
}