using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siuuuu.Models.Cv
{
    public class CvForm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu tələb olunan sahədir.")]
        [MaxLength(70, ErrorMessage = "Maksimum simvol heddi asilib")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu tələb olunan sahədir."), DataType(DataType.PhoneNumber)]

        public int phone { get; set; }
        [Required(ErrorMessage = "Bu tələb olunan sahədir."), DataType(DataType.EmailAddress)]


        public string EmailAdress { get; set; }
     
        [Required(ErrorMessage = "Bu tələb olunan sahədir.")]
        [MaxLength(20, ErrorMessage = "Maksimum simvol heddi asilib")]

        public string Jobb { get; set; }
        public string File { get; set; }
        [NotMapped]
        public IFormFile Pdf { get; set; }
        public DateTime time { get; set; }
    }
}
