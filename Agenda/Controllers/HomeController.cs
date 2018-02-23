
using AulaModelo.Modelo.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {          
            return View(Pessoa.Pessoas);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult PersistPearson(Pessoa p)
        {
            Pessoa.Pessoas.Add(p);
            return RedirectToAction("Index");
        }
    }
}