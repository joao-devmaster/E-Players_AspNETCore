using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using E_Players_AspNETCore.Models;

namespace E_PLAYERS.Controllers
{
    public class NoticiasController : Controller
    {
        Noticias noticiasModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }

        /// <summary>
        /// Publica as informações inseridas
        /// </summary>
        /// <param name="form">entrada de informações</param>
        /// <returns></returns>
        public IActionResult Adicionar(IFormCollection form)
        {
            Noticias noticias = new Noticias();
            noticias.IdNoticia = Int32.Parse( form["IdNoticia"]);
            noticias.Titulo   = form["Titulo"];
            noticias.Texto    = form["Texto"];
            // caminho da imagem
            noticias.Imagem   = form["Imagem"];

            noticiasModel.Create(noticias);
            
            ViewBag.Noticias = noticiasModel.ReadAll();
            return LocalRedirect("~/Noticias");
        }

    }
}