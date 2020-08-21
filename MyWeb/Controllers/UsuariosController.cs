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

        [HttpPost]
        public ActionResult ValidarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return new HomeController().Index();
            }
            else
            {
                return View();
            }
        }
    }
}