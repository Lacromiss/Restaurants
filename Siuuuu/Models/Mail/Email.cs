using System;
using System.ComponentModel.DataAnnotations;

namespace Siuuuu.Models.Mail
{
    public class Email
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(60, ErrorMessage = "Maksimum simvol kecilib")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz"), DataType(DataType.EmailAddress)]
        [MaxLength(60, ErrorMessage = "Maksimum simvol kecilib")]
        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz"), DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Bos buraxmaq olmaz")]
        [MaxLength(5000, ErrorMessage = "Maksimum simvol kecilib")]
        public string Kontent { get; set; }
        public DateTime dateTime { get; set; }

    }
}
