using BloodDonorApp.BL.EF.DTO;
using BloodDonorApp.BL.EF.Facades;
using BloodDonorApp.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BloodDonorApp.PL.Controllers
{
    public class AccountController : BaseController
    {

        public CommonUserFacade CommonUserFacade { get; set; }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> EditExtended()
        {
            Guid id = Guid.Parse(Request.Cookies["ID"].Value);
            var user = await CommonUserFacade.GetCommonUserByIdAsync(id);
            return View("EditExtended", user);
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Register(CommonUserRegistrationDto userCreateDto)
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

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(UserLogInDto model, string returnUrl)
        {
            SessionUser user;
            (bool succ, string roles) = CommonUserFacade.Login(model.Username, model.Password, out user);
            if (succ)
            {
                var authTicket = new FormsAuthenticationTicket(1, model.Username, DateTime.Now,
                    DateTime.Now.AddMinutes(30), false, roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                var idCookie = new HttpCookie("ID")
                {
                    Value = user.Id.ToString()
                };
                HttpContext.Response.Cookies.Add(idCookie);
                HttpContext.Response.Cookies.Add(authCookie);
                currentUser = user;
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

        public ActionResult Logout()
        {
            var customer = CommonUserFacade.GetCommonUserByUserName(User.Identity.Name);

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}