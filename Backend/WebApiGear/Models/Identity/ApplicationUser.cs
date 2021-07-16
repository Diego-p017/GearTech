using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiGear.Models.Identity;

namespace WebApiGear.Models.Identity
{
    [Serializable]
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(80)]
        public string DocumentNumber { get; set; }

        [Required, StringLength(80)]
        public string FirstName { get; set; }
        
        [Required, StringLength(80)]
        public string LastName { get; set; }

        [Required, StringLength(15)]
        public string Phone { get; set; }

        [Required, StringLength(80)]
        public string Address { get; set; }
   

        [Required, ForeignKey(nameof(Location))]
        public int CityId { get; set; }

        public virtual LocationModel Location { get; set; }

    }
}
