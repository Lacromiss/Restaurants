using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siuuuu.Models.Booking
{
    public class Middle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "bos bos buraxmaq olmaz")]
        [MaxLength(50, ErrorMessage = "maksimum simvol 50dir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "bos bos buraxmaq olmaz")]
        [MaxLength(50, ErrorMessage = "maksimum simvol 50dir")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "bos bos buraxmaq olmaz")]
        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "bos bos buraxmaq olmaz")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "bos bos buraxmaq olmaz")]

        [DataType(DataType.DateTime)]

        public DateTime EndTime { get; set; }
        [Required]
        public int MiddleStolId { get; set; }
        public MiddleStol MiddleStol { get; set; }
        [NotMapped]
        public string xeber { get; set; }
    }
}
