using System.ComponentModel.DataAnnotations;

namespace Siuuuu.Models.Karoke
{
    public class KarokeConcept
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(100, ErrorMessage = "maksimum simvol haqqin 100 dur")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(30, ErrorMessage = "maksimum simvol haqqin 30 dur")]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(3500, ErrorMessage = "maksimum simvol haqqin 3500 dir")]
        public string Description1 { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(3500, ErrorMessage = "maksimum simvol haqqin 3500 dir")]
        public string Description2 { get; set; }
    }
}
