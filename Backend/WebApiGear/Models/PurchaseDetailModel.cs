using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGear.Models
{
    public class PurchaseDetailModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPurchase { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal PurchasePrice { get; set; }
        [Required]
        public int PurchaseAmount { get; set; }
        [Required, ForeignKey(nameof(ProductName))]
        public int IdProduct { get; set; }

        public virtual ProductsModel ProductName { get; set; }
    }
}
