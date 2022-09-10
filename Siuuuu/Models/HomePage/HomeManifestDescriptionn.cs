using System.ComponentModel.DataAnnotations;

namespace Siuuuu.Models.HomePage
{
    public class HomeManifestDescriptionn
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(80, ErrorMessage = "maksimum simvol limiti 80 dir")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(1500, ErrorMessage = "maksimum simvol limiti 1500 dir")]


        public string Description { get; set; }
        public string Descriptio2 { get; set; }
    }
}
