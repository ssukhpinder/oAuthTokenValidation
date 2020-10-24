using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oAuthTokenValidation.Controllers
{
    public class HomeController : Controller
    {
        private static string _provider { get; set; }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Provide = "";
            var authCode = this.Request.QueryString["code"];
            if (authCode != null)
            {
                ViewBag.Data = new TokenValidatorController().ValidateToken(_provider, authCode);
            }
            return View();
        }

        public void Google(string provider)
        {
            _provider = provider;
            Response.Redirect("https://accounts.google.com/o/oauth2/v2/auth?redirect_uri=http://localhost:51491&prompt=consent&response_type=code&client_id=633622781734-9dtbahaafjtkt3ai50d9i47dgj47kljh.apps.googleusercontent.com&scope=https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.email+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.profile+openid&access_type=offline");
        }

        public void Github(string provider)
        {
            _provider = provider;
            Response.Redirect("https://github.com/login?client_id=10f4d8c6134a1a0419f5&return_to=%2Flogin%2Foauth%2Fauthorize%3Fclient_id%3D10f4d8c6134a1a0419f5%26redirect_uri=http://localhost:51491&scope%3Duser");
        }
    }
}
