using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesoDatosCore.Data;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosDetalleSelectController : Controller
    {
        EmpleadosContext context;
        public EmpleadosDetalleSelectController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Empleado> listaapellidos = this.context.GetEmpleados();
            ViewBag.Apellidos = listaapellidos;
            return View();
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            List<Empleado> listaapellidos = this.context.GetEmpleados();
            ViewBag.Apellidos = listaapellidos;
            Empleado empleado = this.context.BuscarEmpleado(id);
            return View(empleado);
        }
    }
}
