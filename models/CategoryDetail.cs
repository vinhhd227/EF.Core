namespace EFcore
{
    public class CategoryDetail
    {
        public int CategoryDetailId { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
        public int CountProduct { get; set; }
        public Category Category { get; set; }
    }
}