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
        public JsonResult ValidarUsuario(Usuario usuario)
        {
            var respuesta = new Response
            {
                Valida = false,
                Modelo = null,
                Error = "El E-Mail y/o la Contraseña son incorrectos."
            };

            if (ModelState.IsValid)
            {
                if(usuario.Email=="crismanavella@gmail.com" && usuario.Password == "Mana5692")
                {
                    Usuario usuarioToSend = new Usuario{
                        Id = 1,
                        Nombre = "Cristian",
                        Apellido = "Manavella",
                        Email = usuario.Email,
                        Password = usuario.Password
                    };

                    respuesta.Valida = true;
                    respuesta.Modelo = usuarioToSend;
                    respuesta.Error = "";
                }
            }

            return Json(respuesta);
        }
    }
}