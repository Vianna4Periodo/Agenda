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
    }
}
