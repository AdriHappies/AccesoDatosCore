using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Models
{
    public class Doctor
    {
        public int HospitalCod { get; set; }
        public int DoctorNum { get; set; }
        public String Apellido { get; set; }
        public String Especialidad { get; set; }
        public int Salario { get; set; }
    }
}
