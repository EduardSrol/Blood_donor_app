using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.Facades;
using BloodDonorApp.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BloodDonorApp.PL.Controllers
{
    public class AccountController : Controller
    {

        public CommonUserFacade CommonUserFacade { get; set; }
        public AdminFacade AdminFacade { get; set; }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Register(CommonUserRegistrationDTO userCreateDto)
        {
            try
            {
                await CommonUserFacade.RegisterCustomer(userCreateDto);
                //FormsAuthentication.SetAuthCookie(userCreateDto.Username, false);

                var authTicket = new FormsAuthenticationTicket(1, userCreateDto.Username, DateTime.Now,
                    DateTime.Now.AddMinutes(30), false, "");
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("Username", "Account with that username already exists!");
                return View();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            var isValidAdmin = await AdminFacade.Login(model.Username, model.Password);
            var isValid = await CommonUserFacade.Login(model.Username, model.Password);
            if (isValid)
            {
                var authTicket = new FormsAuthenticationTicket(1, model.Username, DateTime.Now,
                    DateTime.Now.AddMinutes(30), false, "");
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);

                var decodedUrl = "";
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    decodedUrl = Server.UrlDecode(returnUrl);
                }

                if (Url.IsLocalUrl(decodedUrl))
                {
                    return Redirect(decodedUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Wrong username or password!");
            return View();
        }
    }
}