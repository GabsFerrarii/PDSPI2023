using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjeto2023_2.Models;

namespace WebAppProjeto2023_2.Controllers
{
    public class HomeController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }
    }
}