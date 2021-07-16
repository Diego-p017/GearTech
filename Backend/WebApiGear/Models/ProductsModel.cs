using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGear.Models
{
    public class ProductsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }

        [Required, StringLength(150)]
        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal ProductPrice { get; set; }

        [Required]
        public int ProductStock { get; set; }
        
        public string Description { get; set; }
        public string Specifications { get; set; }

        [Required]
        public string ImageProduct { get; set; }

        [ForeignKey(nameof(Category))]
        public int IdCategory { get; set; }

        public virtual CategoryModel Category { get; set; }
        // [ForeignKey("IdCategory")] public virtual CategoryModel Category { get; set; }
    }
}
