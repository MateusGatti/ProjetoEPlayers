using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoEPlayers.Models;

namespace ProjetoEPlayers.Controllers
{
    
    public class NoticiasController : Controller
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