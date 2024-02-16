using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using BulkyBookSolution.BulkyBookModel.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BulkyBookModel
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Product Title")]
        public string ProductTitle { get; set; }
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Required]
        [Display(Name = "Product ISBN")]
        public string ProductISBN { get; set; }
        [Required]
        [Display(Name = "Product Author")]
        public string ProductAuthor { get; set; }
        [Required]
        [Display(Name ="List Price")]
        [Range(1,1000)]
        public double ProductListPrice { get; set; }

        [Required]
        [Display(Name = "Product Price for 1 to 50")]
        [Range(1, 1000)]
        public double ProductPriceOneToFifty { get; set; }

        [Required]
        [Display(Name = "Product Price for 50+")]
        [Range(1, 1000)]
        public double ProductPriceFiftyPlus { get; set; }

        [Required]
        [Display(Name = "Product Price for 100+")]
        [Range(1, 1000)]
        public double ProductPriceHundredPlus { get; set; }

        public int CategoryID { get; set;}
        [ForeignKey("CategoryID")]
        [ValidateNever]
        public CategoryModel Category { get; set; }
        [ValidateNever]
        [Display(Name ="Select Product Image")]
        public string? ProductImgUrl { get; set; }

}
}
