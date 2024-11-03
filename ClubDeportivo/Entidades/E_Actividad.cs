using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    internal class E_Actividad
    {
        public string nombre { get; set; }
        public int codActividad { get; set; }
        public float precio { get; set; }
        public DateTime horario { get; set; }
        public int cupo { get; set; }
        public int cupoDisponible { get; set; }
    }
}
