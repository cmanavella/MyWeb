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

        public ActionResult SignOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult SignIn(User usuario)
        {
            //Cargo la variable respuesta que será devuelta mediante el uso de JSon. Es una instancia al Modelo
            //Response usado para devolver datos con JSon.
            var respuesta = new Response
            {
                Valida = false,
                Modelo = null,
                Error = "El E-Mail y/o la Contraseña son incorrectos."
            };

            //Vuelvo a preguntar si el Formulario se encuentra validado.
            if (ModelState.IsValid)
            {
                try
                {
                    using (mandrakeEntities3 db = new mandrakeEntities3())
                    {
                        var lst = from d in db.Users where d.Email == usuario.Email &&
                                  d.Password == usuario.Password && d.IdState == 1
                                  select d;

                        if (lst.Count() > 0)
                        {
                            usuario = lst.First();
                            Session["User"] = usuario;
                            respuesta.Valida = true;
                            respuesta.Error = "";
                        }
                    }
                }catch(Exception ex)
                {
                    respuesta.Valida = false;
                    respuesta.Modelo = null;
                    respuesta.Error = "Error: " + ex.Message;
                }

                //Acá es donde tengo que buscar si el usuario ingresado existe en la BD.
                //if(usuario.Email=="crismanavella@gmail.com" && usuario.Password == "Mana5692")
                //{
                //    Usuario usuarioToSend = new Usuario{
                //        Id = 1,
                //        Nombre = "Cristian",
                //        Apellido = "Manavella",
                //        Email = usuario.Email,
                //        Password = usuario.Password
                //    };

                //    respuesta.Valida = true;
                //    respuesta.Modelo = usuarioToSend;
                //    respuesta.Error = "";
                //}
            }

            //Retorno el JSon.
            return Json(respuesta);
        }
    }
}