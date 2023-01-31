using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Project.Extend
{
     public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public string? ImgUrl { get; set; }

        public bool? Gender { get; set; }

    }
}
