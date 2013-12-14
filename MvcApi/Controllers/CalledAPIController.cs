using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessLayer;
using MvcApi.Services;

namespace MvcApi.Controllers
{
    public class CalledAPIController : Controller
    {
        
        public ActionResult Index()
        {
            CalledAPIBL ApiBL = new CalledAPIBL();
            List<CalledAPI> API= ApiBL.CalledAPIs.ToList();

            return View(API);
        }

        [HttpGet]
        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Create(CalledAPI api)
        {
            CalledAPIBL ApiBL = new CalledAPIBL();
            ApiBL.Save(api);
            return RedirectToAction("Index");
        }

        public string CallServiceApi(string input, string CallMode)
        {
            string retValue = string.Empty;
            if (!String.IsNullOrEmpty(input))
            {
                I33tsp34kService I33 = new I33tsp34kService();
                retValue = I33.CallWebApi(input, CallMode);
            }
            return retValue;
        }
    }
}
