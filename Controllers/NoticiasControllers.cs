using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using E_Players_AspNETCore.Models;
using System.IO;

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
            Noticias news = new Noticias();
            news.IdNoticia = Int32.Parse( form["IdNoticia"]);
            news.Titulo   = form["Titulo"];
            news.Texto    = form["Texto"];
            // inicio do upload da imagem
            news.Imagem   = form["Imagem"];

            
           
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias"); 

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                news.Imagem   = file.FileName;
            }
            else
            {
                news.Imagem   = "padrao.png";
            }
            // fim do upload da imagem

            noticiasModel.Create(news);
            
            ViewBag.Noticias = noticiasModel.ReadAll();
            return LocalRedirect("~/Noticias");
        }

              [Route("Noticias/{id}")]

        public IActionResult Excluir(int id)  
        {
            noticiasModel.Delete(id);
            return LocalRedirect("~/Noticias");

        }
    }

    }
