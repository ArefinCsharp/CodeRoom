using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;
using System.Net;
using DemoAPP2.Models;

namespace DemoAPP2.Controllers
{
    [RoutePrefix("Test")]    
    public class HomeController : Controller
    {      
        [Route("Index")]  
        public ActionResult Index()
        {
            //Session
            Session["check"] = "test";
            System.Web.HttpContext.Current.Session["check2"] = "test2";
            var data = (string)System.Web.HttpContext.Current.Session["check2"];
            HttpSessionStateBase datas = new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session);
            datas.Add("check3", "test3");            

            //Hiddenfield
            var model = new DemoModel {
                Property1 = 10,
                Property2 = 20
            };

            //Cookies            
            
            //ViewData
            ViewData.Add(new KeyValuePair<string, object>("","10"));

            //ViewBag

            //TempData
            //TempData.Add("Count",10);                                                          
            return View(model);
        }
        [HttpPost]
        public void Index(FormCollection collection)
        {
            var data = collection["Property1"];
        }
        
        [Route("Hey/{id:int?}")]        
        public ActionResult About(int? id)
        {
            //var temp = TempData["Count"].ToString();
            //TempData.Keep();          
            //var data2 = (string)Session["check2"];
            //var data3 = (string)Session["check3"];
            Session.Abandon();
            return View();
        }

        [Route("Heys")]
        public ActionResult Help()
        {
            if (TempData["Count"] != null)
            {
                var data = TempData["Count"].ToString();
            }            
            return View();
        }
        
        public ActionResult Route()
        {
            return View("About");
        }

        protected override ITempDataProvider CreateTempDataProvider()
        {
            return new CookieTempDataProvider(HttpContext);
        }
    }
}