﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Pessoa
    {

        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public virtual String Email { get; set; }
        public virtual String Telefone { get; set; }
    }

    public class PessoaMap : ClassMapping<Pessoa>
    {
        public PessoaMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));
            Property(x => x.Nome);
            Property(x => x.DtNascimento);
            Property(x => x.Email);
            Property(x => x.Telefone);
        }
    }
}
