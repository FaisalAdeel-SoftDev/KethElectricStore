using KethElectStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KethElectStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Email_Set _email_Set;
        public ProductsController(IConfiguration configuration,IOptions<Email_Set> options)
        {
            _configuration = configuration;
            _email_Set=options.Value;
        }
        public async Task<IActionResult> Index()
        {
            //var t=_configuration["ApiKey"];
            //var t1=_configuration["Api"];
            //var t2=_configuration["EnvType"];
            //var t3=_configuration["Email_Set:Service"];
            //var t4 = _email_Set.Service;
            await makeclaim();
            return View();
        }
        public async Task makeclaim()
        {
            //throw new Exception("Out of bound");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"Faisal"),
                new Claim(ClaimTypes.Role,"Admin")
            };
            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
           CookieAuthenticationDefaults.AuthenticationScheme,
           principal);
        }
    }

}
