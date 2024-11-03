using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_Cuota_Cliente
    {
        public E_Cliente? cliente { get; set; }
        public E_Cuota? cuota { get; set; }
    }
}
