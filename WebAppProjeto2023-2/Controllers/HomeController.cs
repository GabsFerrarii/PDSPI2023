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
        public ActionResult Index(long? FabricanteId, long? CategoriaId)
        {
            Home h = new Home();
            h.fabricantes = context.Fabricantes.OrderBy(c => c.FabricanteId);
            h.categorias = context.Categorias.OrderBy(c => c.CategoriaId);
            if((FabricanteId != null) && (FabricanteId != 0))
            {
                h.filtro = "Fabricante";
                h.produtos = context.Produtos.Where(p => p.FabricanteId == FabricanteId).OrderBy(c => c.Nome);
            }
            if ((CategoriaId != null) && (CategoriaId != 0))
            {
                h.filtro = "Categoria";
                h.produtos = context.Produtos.Where(p => p.CategoriaId == CategoriaId).OrderBy(c => c.Nome);
            }
            return View(h);
        }
    }
}