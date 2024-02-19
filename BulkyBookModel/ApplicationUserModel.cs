using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookModel
{
    public class ApplicationUserModel : IdentityUser
    {
        [Required]
        public string? ApplicationUserName { get; set; }

        public String? ApplicationUserStreetAddress { get; set; }

        public String? ApplicationUserCity { get; set; }

        public String? ApplicationUserState{ get; set; }

        public String? ApplicationUserPostalCode { get; set; }
    }
}
