using System.ComponentModel.DataAnnotations;

namespace Siuuuu.Vm
{
    public class LoginVm
    {
        [Required]
        public string EmailOrUsername { get; set; }
        [Required]

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
