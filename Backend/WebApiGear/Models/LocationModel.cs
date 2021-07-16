using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApiGear.Models.Identity
{
    public class LocationModel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [Required, StringLength(150)]
        public string CityName { get; set; }

       
    }
}
