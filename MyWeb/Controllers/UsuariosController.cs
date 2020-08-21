using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ValidarUsuario(string email, string pass)
        {
            Usuario usuario = new Usuario()
            {
                Id = 1,
                Nombre = "Cristian",
                Apellido = "Manavella",
                Email = "crismanavella@gmail.com",
                Password = "Mana5692"
            };
            JsonResult retorno = new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = usuario
            };

            return retorno;
        }
    }
}