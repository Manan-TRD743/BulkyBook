using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBookModel
{
    // Represents a user model for the application.
    // Inherits from IdentityUser for user authentication and authorization.
    public class ApplicationUserModel : IdentityUser
    {
        
        [Required]
        public string? ApplicationUserName { get; set; }  
        public String? ApplicationUserStreetAddress { get; set; }
        public String? ApplicationUserCity { get; set; }
        public String? ApplicationUserState{ get; set; }
        public String? ApplicationUserPostalCode { get; set; }

        public int? CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        [ValidateNever]
        public CompanyModel Company { get; set; }
    }
}
