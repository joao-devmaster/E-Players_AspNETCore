using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace E_Players.Controllers
{
    public class NoticiaController : Controller
    {

        Noticias noticiasModel = new Noticias();
       

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }


           public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia   = new Noticias();
            novaNoticia.IdNoticia = Int32.Parse(form["IdEquipe"]);
            novaNoticia.Titulo     = form["Titulo"];
            novaNoticia.Texto   = form["Texto"];
            novaNoticia.Imagem   = form["Imagem"];

            noticiasModel.Create(novaNoticia);            
            ViewBag.Equipes = noticiasModel.ReadAll();

            return LocalRedirect("~/Noticias");
        }



    }
}