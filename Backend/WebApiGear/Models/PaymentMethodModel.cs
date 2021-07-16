using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGear.Models
{
    public class PaymentMethodModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMethod { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }

        [Required, StringLength(150)]
        public string MethodDescription { get; set; }
    }
}
