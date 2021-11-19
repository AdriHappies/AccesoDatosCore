using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class PlantillaTurnoController : Controller
    {
        PlantillasContext context;
        public PlantillaTurnoController(PlantillasContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(String turno)
        {
            List<Plantilla> listaplantilla = this.context.GetPlantillaTurno(turno);
            return View(listaplantilla);
        }
    }
}
