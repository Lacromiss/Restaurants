using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siuuuu.Models.Buy
{
    public class BuyProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bos buraxmaq olmaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [Range(1,1000000000000,ErrorMessage ="limit kecilib")]


        public double Price { get; set; }
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public int Count { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(500,ErrorMessage ="MAX SIMVOL 500 DUR")]
        public string Description { get; set; }
    }
}
