
using AulaModelo.Modelo.DB;
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
            var x = DbFactory.Instance;
            var p1 = new Pessoa()
            {
                Nome="Tadeu",
                Telefone ="32 32323232",
                Email = "email@oi.com.br",
                DtNascimento = DateTime.Now,
                Id = Guid.NewGuid()
            };
            var p2 = new Pessoa()
            {
                Nome = "B",
                Telefone = "32 32323232",
                Email = "email@oi.com.br",
                DtNascimento = DateTime.Now,
                Id = Guid.NewGuid()
            };
            var p3 = new Pessoa()
            {
                Nome = "C",
                Telefone = "32 32323232",
                Email = "email@oi.com.br",
                DtNascimento = DateTime.Now,
                Id = Guid.NewGuid()
            };

            Pessoa.Pessoas.Add(p1);
            Pessoa.Pessoas.Add(p2);
            Pessoa.Pessoas.Add(p3);
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

        public ActionResult Search(String edtSearch)
        {
            var pessoaAux = new List<Pessoa>();
            if (String.IsNullOrEmpty(edtSearch))
            {
                return View("Index", Pessoa.Pessoas);
            }
            //1 - Filtro com FOR
            //for(var i=0; i<Pessoa.Pessoas.Count; i++)
            //{
            //    if(Pessoa.Pessoas[i].Nome == edtSearch.Trim())
            //    {
            //        pessoaAux.Add(Pessoa.Pessoas[i]);
            //    }
            //}

            //2 - Filtro com FOREACH
            //foreach(var pessoa in Pessoa.Pessoas)
            //{
            //    if(pessoa.Nome == edtSearch.Trim())
            //    {
            //        pessoaAux.Add(pessoa);
            //    }
            //}

            //3 - Filtro com LINQ
            //pessoaAux = (
            //    from p in Pessoa.Pessoas
            //    where p.Nome == edtSearch.Trim()
            //    select p
            //    ).ToList();

            //4 - Filtro com LAMBDA
            pessoaAux = Pessoa.Pessoas.Where(pessoa =>  
                                pessoa.Nome.Contains(edtSearch.Trim())
                            ).ToList();

            return View("Index", pessoaAux);
        }
    }
}