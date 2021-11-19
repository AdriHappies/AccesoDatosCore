using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Models
{
    public class Plantilla
    {
        public String Apellido { get; set; }
        public String Funcion { get; set; }
        public int Salario { get; set; }
        public int IdPlantilla { get; set; }
        public String Turno { get; set; }
        public int SalaCod { get; set; }
        public int HospitalCod { get; set; }
    }
}
