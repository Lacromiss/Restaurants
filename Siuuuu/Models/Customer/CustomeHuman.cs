using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siuuuu.Models.Customer
{
    public class CustomeHuman
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "BOS BURAXMAQ OLMAZ")]
        [MaxLength(25, ErrorMessage = "max simvol limiti 25")]
        public string insta { get; set; }
    }
}
