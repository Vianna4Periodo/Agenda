using AulaModelo.Modelo.DB.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Repository
{
    public class UsuarioRepository: RepositoryBase<Usuario>
    {
        public UsuarioRepository(ISession session) : base(session) { }

        public Usuario Login(String login, String senha)
        {
            try
            {
                return this.Session.Query<Usuario>().FirstOrDefault(f => f.Login == login && f.Senha == senha);
            }
            catch (Exception ex)
            {
                throw new Exception("Não achei as pessoas pelo filtro", ex);
            }
        }

    }
}
