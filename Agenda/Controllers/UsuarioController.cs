using AulaModelo.Modelo.DB;
using AulaModelo.Modelo.DB.Model;
using AulaModelo.Modelo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agenda.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult CadastrarUsuario()
        {
            return View();
        }

        public ActionResult EntrarUsuario()
        {
            return View(new Usuario());
        }

        public ActionResult Logar(string usuario, string senha)
        {
            LoginUtils.Logar(usuario, senha);

            if (LoginUtils.Usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("EntrarUsuario");
            }
        }

        public ActionResult DeslogarUsuario()
        {
            LoginUtils.Deslogar();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GravarUsuario(Usuario usuario)
        {
            DbFactory.Instance.RepositoryUsuario.SaveOrUpdate(usuario);
            return RedirectToAction("EntrarUsuario");
        }

    }
}