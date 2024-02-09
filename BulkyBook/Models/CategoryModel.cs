using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public int CategoryDisplayOrder { get; set; }
    }
}
