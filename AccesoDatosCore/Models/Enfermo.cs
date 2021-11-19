using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Models
{
    public class Enfermo
    {
        public int Inscripcion { get; set; }
        public String Apellido { get; set; }
        public String Direccion { get; set; }
        public DateTime Fecha { get; set; }
        public String Sex { get; set; }
        public int Nss { get; set; }
    }
}
