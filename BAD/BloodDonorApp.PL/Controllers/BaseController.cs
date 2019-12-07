using BloodDonorApp.BL.EF.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BloodDonorApp.PL.Controllers
{
    public class BaseController : Controller
    {
        public SessionUser currentUser { get; set; }
        //public SessionUser CurrentUser
        //{
        //    get
        //    {
        //        if (currentUser != null)
        //            return currentUser;
        //        var userData = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.UserData).Value;
        //        currentUser = JsonConvert.DeserializeObject(userData, typeof(SessionUser)) as SessionUser;
        //        return currentUser;
        //    }
        //}
    }
}