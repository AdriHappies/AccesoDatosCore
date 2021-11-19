using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class HospitalController : Controller
    {
        HospitalContext context;
        public HospitalController(HospitalContext context)
        {
            this.context = context;
        }
        public IActionResult Menu()
        {
            List<Hospital> listahospitales = this.context.GetHospitales();
            return View(listahospitales);
        }
        public IActionResult DetalleHospital(int hospitalcod)
        {
            Hospital hospital = this.context.BuscarHospital(hospitalcod);
            return View(hospital);
        }
        public IActionResult ListaPlantilla(int hospitalcod)
        {
            List<Plantilla> listaplantilla = this.context.GetPlantilla(hospitalcod);
            return View(listaplantilla);
        }
        public IActionResult ListaDoctores(int hospitalcod)
        {
            List<Doctor> listadoctores = this.context.GetDoctores(hospitalcod);
            return View(listadoctores);
        }
    }
}
