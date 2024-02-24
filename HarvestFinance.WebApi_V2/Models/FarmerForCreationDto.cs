
using System.ComponentModel.DataAnnotations;

namespace HarvestFinance.WebApi_V2.Models
{
    public class FarmerForCreationDto
    {
        [Required(ErrorMessage ="Absolutely each farmer has a name! Enter a correct Name")]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required( ErrorMessage = "Absolutely each farmer has a name! Enter a correct Name" )]
        [MaxLength(150)]
        public string LastName { get; set; } = string.Empty;
        [Phone]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [MaxLength(400)]
        public string Address { get; set; } = string.Empty;
                
    }
}   
