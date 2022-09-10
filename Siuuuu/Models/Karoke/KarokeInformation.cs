using System.ComponentModel.DataAnnotations;

namespace Siuuuu.Models.Karoke
{
    public class KarokeInformation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(100, ErrorMessage = "maksimum simvol haqqin 100 dur")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(1000, ErrorMessage = "maksimum simvol haqqin 1000 dur")]
        public string Description1 { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(1000, ErrorMessage = "maksimum simvol haqqin 1000 dur")]
        public string Description2 { get; set; }
    }
}
