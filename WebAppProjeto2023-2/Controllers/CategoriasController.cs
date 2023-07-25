using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppProjeto2023_2.Models;
using Modelo.Tabelas;
using Modelo.Cadastros;
using Servico.Tabelas;

namespace WebAppProjeto2023_2.Controllers
{
    public class CategoriasController : Controller
    {
        //private EFContext context = new EFContext();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removida";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categorias
        /*
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() { CategoriaId = 1, Nome = "Notebooks"},
            new Categoria() { CategoriaId = 2, Nome = "Monitores"},
            new Categoria() { CategoriaId = 3, Nome = "Impressoras"},
            new Categoria() { CategoriaId = 4, Nome = "Mouses"},
            new Categoria() { CategoriaId = 5, Nome = "Desktops"}
        };
        public ActionResult Index()
        {
            return View(categorias);
        }
        // GET: Categorias
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categoria.CategoriaId = categorias.Select(m => m.CategoriaId).Max() + 1;
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(
            categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }*/
    }
}