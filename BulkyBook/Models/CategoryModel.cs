using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set;}
        [Required(ErrorMessage ="Category Name is Required.")]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

       
        [DisplayName("Display Order"),Range(1,100,ErrorMessage = "Display Order Must be between 1-100 .")]
        public int CategoryDisplayOrder { get; set; }
    }
}
