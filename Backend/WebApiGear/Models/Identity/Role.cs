using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGear.Models.Identity
{
    [Table("AspNetRoles")]
    public class Role : IdentityRole
    {
    }
}
