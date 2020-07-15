using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;

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

        public IActionResult Cadastrar (IFormCollection form)
        {
            Equipe equipeNova    = new Equipe();
            equipeNova.IdEquipe  = Int32.Parse(form["IdEquipe"]);
            equipeNova.Nome      = form["Nome"];
            equipeNova.Imagem    = form["Imagem"];

            equipeNova.Create(equipeNova);
            ViewBag.Equipes = equipe1model.ReadAll();

            return LocalRedirect("~/Equipe");
            
        }
    }

}
