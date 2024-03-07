using System.ComponentModel.DataAnnotations;

namespace BulkyBookModel
{
    public class CompanyModel
    {
        [Key]
        public int CompanyID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Street Address")]
        public string? StreetAddress { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }
        [Display(Name = "State")]
        public string? State { get; set; }

        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }
        
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
    }
}
