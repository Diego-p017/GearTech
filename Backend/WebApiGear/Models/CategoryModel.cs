using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGear.Models
{
    public class CategoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategory { get; set; }
        [Required, StringLength(150)]
        public string CategoryName { get; set; }

        [ForeignKey(nameof(TrademarkName)), Required]
        public int IdTrademark { get; set; }

        public virtual TrademarkModel TrademarkName { get; set; }
    }
}
