using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Siuuuu.Models.Account;
using Siuuuu.Vm;
using System.Threading.Tasks;

namespace Siuuuu.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _user;
        private readonly SignInManager<AppUser> _sign;
        private readonly RoleManager<IdentityRole> _role;

        public LoginController(UserManager<AppUser> user, SignInManager<AppUser> sign, RoleManager<IdentityRole> role)
        {
            _user = user;
            _sign = sign;
            _role = role;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVM)
        {
            if (!ModelState.IsValid) return View();
            if (registerVM == null) return NotFound();
            AppUser user = new AppUser
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                
            };
            IdentityResult result = await _user.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }
         
            return RedirectToAction("Login", "Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm,string ReturnUrl)
        {
            AppUser user;
            if (loginVm.EmailOrUsername.Contains("@"))
            {
                user = await _user.FindByEmailAsync(loginVm.EmailOrUsername);
            }
            else
            {
                user = await _user.FindByNameAsync(loginVm.EmailOrUsername);
            }
            if (user == null)
            {
                ModelState.AddModelError("", "Sifreniz veya Istifadeci adiniz yanlisdir!");
                return View();
            }
            var result = await _sign.PasswordSignInAsync(user, loginVm.Password, loginVm.RememberMe, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Sizin Hesabiniz bir muddetlik bloklanib!");
                return View(loginVm);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Sifreniz veya Istifadeci adiniz yanlisdir!");
                return View(loginVm);
            }
            if (ReturnUrl!=null)
            {
                return LocalRedirect(ReturnUrl);

            }
            return RedirectToAction("Homw", "Index");

        }
        public async Task<IActionResult> LogOut()
        {
            await _sign.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
