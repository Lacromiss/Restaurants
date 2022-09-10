using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siuuuu.Models.Menu
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bos kecirile bilmez")]
        [MaxLength(40,ErrorMessage ="Maksimum simvol 40 dir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bos kecirile bilmez")]
        [Range(1,1000000000,ErrorMessage = "maksimim mebleg 1000000000dir")]

        public double Price { get; set; }
        [Required(ErrorMessage = "Bos kecirile bilmez")]
        [MaxLength(3000, ErrorMessage = "Maksimum simvol 3000 dir")]
        public string Description { get; set; }
     
        public string LargeImg { get; set; }

        [NotMapped]

        public IFormFile Photo2 { get; set; }
        [Required(ErrorMessage ="kataqorya elave etmelisen")]
        public int CatagoryId { get; set; }
        public Catagory Catagory { get; set; }
    }
}
