using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siuuuu.Models.Curious
{
    public class CuriorOne
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(45, ErrorMessage = "maksimum simvol sayisi kecilib")]
        public string Txt { get; set; }
    }
}
