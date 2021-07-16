using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGear.Models
{
    public class PaymentOrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }
        [Required, ForeignKey(nameof(PaymentOrder))]
        public int IdPayment { get; set; }

        [Required, ForeignKey(nameof(StatusOrder))]
        public int IdStatus { get; set; }

        public virtual PaymentsModel PaymentOrder { get; set; }
        public virtual PaymentOrderStatusModel StatusOrder { get; set; }
    }
}
