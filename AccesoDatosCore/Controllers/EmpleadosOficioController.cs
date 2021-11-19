using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosOficioController : Controller
    {
        EmpleadosContext context;
        public EmpleadosOficioController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<String> listaoficios = this.context.GetOficios();
            ViewBag.Oficios = listaoficios;
            return View();
        }
        [HttpPost]
        public IActionResult Index(String oficio)
        {
            List<String> listaoficios = this.context.GetOficios();
            ViewBag.Oficios = listaoficios;
            List<Empleado> listaempleados = this.context.GetEmpleadosOficio(oficio);
            return View(listaempleados);
        }
    }
}
