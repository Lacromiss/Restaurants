using System.ComponentModel.DataAnnotations;

namespace Siuuuu.Models.Customer
{
    public class CustomerJobAndCareer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "BOS BURAXMAQ OLMAZ")]
        [MaxLength(50, ErrorMessage = "max simvol sayisi 50 dir")]
        public string Title { get; set; }
        [Required(ErrorMessage = "BOS BURAXMAQ OLMAZ")]
        [MaxLength(2500, ErrorMessage = "max simvol sayisi 2500 dir")]
        public string Description { get; set; }
    }
}
