using AulaModelo.Modelo.DB;
using AulaModelo.Modelo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AulaModelo.Modelo.Utils
{
    public class LoginUtils
    {
        public static Usuario Usuario
        {
            get
            {
                if (HttpContext.Current.Session["Usuario"] != null)
                {
                    return (Usuario)HttpContext.Current.Session["Usuario"];
                }

                return null;
            }
        }

        public static void Logar(string login, string senha)
        {
            try
            {
                Usuario usuario = DbFactory.Instance.RepositoryUsuario.Login(login, senha);
                HttpContext.Current.Session["Usuario"] = usuario;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void Deslogar()
        {
            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session.Remove("Usuario");
        }
    }
}
