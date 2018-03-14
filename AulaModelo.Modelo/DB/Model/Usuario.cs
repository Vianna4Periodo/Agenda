using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaModelo.Modelo.DB.Model
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
    }
}
