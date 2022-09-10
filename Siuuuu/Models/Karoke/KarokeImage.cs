using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siuuuu.Models.Karoke
{
    public class KarokeImage
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string ImgUrl { get; set; }
    }
}
