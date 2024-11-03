using ClubDeportivo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class Cuota
    {
        public int idCuota { get; set; }
        public DateTime fechaUltimoPago { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public float monto { get; set; }
        public bool pagado { get; set; }
        public int idSocio { get; set; }

        public bool actualizarFecha()
        {
            return true;
        }

        public List<E_Cuota_Cliente> listarVencimientos()
        {
            return new List<E_Cuota_Cliente>();
        }
    }
}
