using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookModel
{
    // Represents a user model for the application.
    // Inherits from IdentityUser for user authentication and authorization.
    public class ApplicationUserModel : IdentityUser
    {
        // Get or Set UserName and it is Required
        [Required]
        public string? ApplicationUserName { get; set; }

        //Get or Set Street Addess
        public String? ApplicationUserStreetAddress { get; set; }

        //Get or Set City
        public String? ApplicationUserCity { get; set; }

        //Get or Set State
        public String? ApplicationUserState{ get; set; }

        //Get or Set Postal Code
        public String? ApplicationUserPostalCode { get; set; }
    }
}
