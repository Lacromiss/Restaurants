using System.ComponentModel.DataAnnotations;

namespace Siuuuu.Models.Karoke
{
    public class KarokeRezerevation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(100, ErrorMessage = "maksimum simvol haqqin 100 dur")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(1000, ErrorMessage = "maksimum simvol haqqin 1000 dur")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(50, ErrorMessage = "maksimum simvol haqqin 50 dir")]
        public string Link { get; set; }
    }
}
