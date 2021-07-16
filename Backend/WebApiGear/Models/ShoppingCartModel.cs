using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using WebApiGear.Models.Identity;

using WebApiUser.Model.ViewModels;

namespace WebApiGear.Models
{
    public class ShoppingCartModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdShoppingCart { get; set; }
       
        [Required, ForeignKey(nameof(PurchasePrice))]
        public int IdPurchase { get; set; }

        [Required, ForeignKey(nameof(UserCart))]
        public string  id { get; set; }

        public virtual PurchaseDetailModel PurchasePrice { get; set; }
        public virtual ApplicationUser UserCart { get; set; }
    }
}
