using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace E_Players.Controllers
{
    public class EquipeController : Controller
    {
        Equipe equipe1model = new Equipe();

        public IActionResult Index()
        {
            ViewBag.Equipes = equipe1model.ReadAll();
            return View();

        }
/// <summary>
/// Cadastrar uma nova equipe atraves de um Formulario
/// </summary>
/// <param name="form"></param>
/// <returns></returns>
        public IActionResult Cadastrar (IFormCollection form)
        {
            Equipe equipeNova    = new Equipe();
            equipeNova.IdEquipe  = Int32.Parse(form["IdEquipe"]);
            equipeNova.Nome      = form["Nome"];
            //upload da imagem
            equipeNova.Imagem    = form["Imagem"];
           
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

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
                equipeNova.Imagem   = file.FileName;
            }
            else
            {
                equipeNova.Imagem   = "padrao.png";
            }
             // fim - upload imagem
             
            equipeNova.Create(equipeNova);
            

            return LocalRedirect("~/Equipe");
            
        }
/// <summary>
/// metodo feito para excluir equipes atraves do id
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
        [Route("Equipe/{id}")]
         public IActionResult Excluir(int id)
        {
           equipe1model.Delete(id);
           
            return LocalRedirect("~/Equipe");
        }
    }

}
