﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppProjeto2023_2.Models;

namespace WebAppProjeto2023_2.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias

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
        public ActionResult Create()
        {
            return View();
        }
    }
}