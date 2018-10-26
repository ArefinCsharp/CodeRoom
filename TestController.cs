//-------------Attribute routing Demo--------------
//Author: Md Arefin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAPP2.Controllers
{    
    public class TestController : Controller
    {        
        public ActionResult Index()
        {
            var data = TempData["Count"].ToString();
            return View();
        }

        [Route("Arefin")]
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Help(int? id,string value)
        {            
            return View();
        }

        protected override ITempDataProvider CreateTempDataProvider()
        {
            return new CookieTempDataProvider(HttpContext);
        }
    }
}