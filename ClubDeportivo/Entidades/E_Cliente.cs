using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_Cliente
    {
        public int idCliente { get; set; }
        public required string nombre { get; set; }
        public required string apellido { get; set; }
        public int dni { get; set; }
        public bool aptoFisico { get; set; }
        public bool esSocio { get; set; }
    }
}
