using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class NoSocio : Clientes
    {

        public bool registrarActividad(int idActividad, int idCliente)
        {
            return Actividad.inscribirActividad(idActividad, idCliente);
        }

    }
}
