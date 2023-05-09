using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFcore
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Tensanpham", TypeName = "ntext")]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int CateId { get; set; }
        //Foreign key
        [ForeignKey("CateId")]
        //[Required]
        public virtual Category Category { get; set; }
        public int? CateId2 { get; set; }
        //Foreign key
        [ForeignKey("CateId2")]
        //[Required]
        [InverseProperty("Products")]
        public virtual Category Category2 { get; set; }
        public void PrintInfo() => Console.WriteLine($"{ProductID} - {Name} - {Price} - {CateId}");
    }
}
/*
    Table("TableName)
    [Key] ->Primary Key (PK)
    [Required] -> not null
    [StringLength(50)] -> string - nvarchar
*/