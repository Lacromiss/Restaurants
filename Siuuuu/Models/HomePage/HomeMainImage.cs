using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siuuuu.Models.HomePage
{
    public class HomeMainImage
    {
        public int Id { get; set; }
        public string ImgUrl1 { get; set; }
        public string ImgUrl2 { get; set; }
        [NotMapped]
        public IFormFile Photo1 { get; set; }
        [NotMapped]
        public IFormFile Photo2 { get; set; }
    }
}
