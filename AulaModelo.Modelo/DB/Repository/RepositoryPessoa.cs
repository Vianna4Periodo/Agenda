using AulaModelo.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Repository
{
    public class RepositoryPessoa : RepositoryBase<Pessoa>
    {
        public RepositoryPessoa(ISession session) : base(session)
        {
        }

        public IList<Pessoa> GetAllByName(String nome)
        {
            try
            {
                return this.Session.Query<Pessoa>().Where(w => w.Nome.ToLower() == nome.Trim().ToLower()).ToList();
            }catch(Exception ex)
            {
                throw new Exception("The pearson " + nome + " was not found! Error: ", ex);
            }
        }
    }
}
