using System.ComponentModel.DataAnnotations;

namespace Siuuuu.Models.HomePage
{
    public class HomeTxt2
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "bos buraxmaq olmaz")]
        [MaxLength(50, ErrorMessage = "max simvol sayisi 50dir")]
        public string Title { get; set; }
        [Required(ErrorMessage = "bos buraxmaq olmaz")]
        [MaxLength(1900, ErrorMessage = "max simvol sayisi 1900dir")]


        public string Description { get; set; }
        [Required(ErrorMessage = "bos buraxmaq olmaz")]
        [MaxLength(1900, ErrorMessage = "max simvol sayisi 1900dir")]


        public string Description2 { get; set; }
    }
}
