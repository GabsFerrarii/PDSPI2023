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
            Home h = new Home();
            h.fabricantes = context.Fabricantes.OrderBy(c => c.FabricanteId);
            h.categorias = context.Categorias.OrderBy(c => c.CategoriaId);
            return View(h);
        }
    }
}