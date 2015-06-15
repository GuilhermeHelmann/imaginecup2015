using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Imaginecupbox.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public String Index()
        {
            return "meu Deus que loco isso...";
        }
        public ActionResult Sobre()
        {
            ViewBag.nomeuniv = "UNIVILLE - Universidade da R...";
            ViewBag.datahoje = DateTime.Today;

            return View();
        }


    }
}
