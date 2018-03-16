using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Usuario
    {
        public virtual Guid Id { get; set; }
        public virtual String Login { get; set; }
        public virtual String Senha { get; set; }
    }

    public class UsuarioMap: ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.Id, mbox => mbox.Generator(Generators.Guid));

            Property(x => x.Login);
            Property(x => x.Senha);
        }
    }

}
