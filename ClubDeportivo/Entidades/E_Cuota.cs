using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_Cuota
    {
        public int idCuota { get; set; }
        public DateTime fechaUltimoPago { get; set; }
        public float valorCuota { get; set; }
        public string formaPago { get; set; }
        public DateTime? fechaVencimiento { get; set; }
        public int idCliente { get; set; }
        
    
    
    }
}
