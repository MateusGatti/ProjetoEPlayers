using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

            // Upload de imagem inicio
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
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // Upload de imagem final

            noticiasModel.Create(novaNoticia);            
            ViewBag.Noticias = noticiasModel.ReadAll();

            return LocalRedirect("~/Noticias");

        }

        [Route("[controller]/{id}")]
        public IActionResult Excluir(int id)
        {
            noticiasModel.Delete(id);
            ViewBag.Noticias = noticiasModel.ReadAll();
            return LocalRedirect("~/Noticias");
        }
        
    }
}