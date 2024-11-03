using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class Socio : Clientes
    {
        private int idSocio;
        public bool pagarCuota()
        {
            return true;
        }
    }
}
