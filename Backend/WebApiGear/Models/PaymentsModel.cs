using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGear.Models
{
    public class PaymentsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPayment { get; set; }

        [Required, ForeignKey(nameof(MethodPayment))]
        public int IdMethod { get; set; }

        [Required, ForeignKey(nameof(PaymentCart))]
        public int IdShoppingCart { get; set; }

        public virtual PaymentMethodModel MethodPayment { get; set; }
        public virtual ShoppingCartModel PaymentCart { get; set; }
    }
}
