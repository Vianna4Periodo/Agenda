
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
            var pessoas = DbFactory.Instance.RepositoryPessoa.FindAll();
            return View(pessoas);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult PersistPearson(Pessoa p)
        {
            DbFactory.Instance.RepositoryPessoa.SaveOrUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult Search(String edtSearch)
        {           
            if (String.IsNullOrEmpty(edtSearch))
            {
                return View("Index");
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
            var pessoas = DbFactory.Instance.RepositoryPessoa.GetAllByName(edtSearch);

            return View("Index", pessoas);
        }

        public ActionResult Delete(Guid id)
        {
            var p = DbFactory.Instance.RepositoryPessoa.FindById(id);

            if(p != null)
            {
                DbFactory.Instance.RepositoryPessoa.Delete(p);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdatePearson(Guid id)
        {
            var p = DbFactory.Instance.RepositoryPessoa.FindById(id);

            if (p != null)
            {
                return View(p);
            }
            return RedirectToAction("Index");
        }
    }
}