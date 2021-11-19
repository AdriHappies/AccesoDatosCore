using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class IncrementoPlantillaController : Controller
    {
        PlantillasContext context;
        public IncrementoPlantillaController(PlantillasContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<String> listafunciones = this.context.GetFuncionPlantilla();
            ViewBag.Funciones = listafunciones;
            return View();
        }
        [HttpPost]
        public IActionResult Index(String funcion, int incremento)
        {
            List<String> listafunciones = this.context.GetFuncionPlantilla();
            ViewBag.Funciones = listafunciones;
            int resultado = this.context.IncrementarSalarioPlantilla(funcion, incremento);
            ViewBag.Mensaje = "Empleados modificados: " + resultado;
            List<Plantilla> listaplantilla = this.context.BuscarPlantilla(funcion);
            return View(listaplantilla);
        }
    }
}
