using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccesoDatosCore.Data;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Controllers
{
    public class IncrementoEmpleadoController : Controller
    {
        EmpleadosContext context;
        public IncrementoEmpleadoController(EmpleadosContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Empleado> listaempleados = this.context.GetEmpleados();
            ViewBag.Empleados = listaempleados;
            return View();
        }
        [HttpPost]
        public IActionResult Index(int idempleado, int incremento)
        {
            List<Empleado> listaempleados = this.context.GetEmpleados();
            ViewBag.Empleados = listaempleados;
            int afectados = this.context.IncrementarSalarioEmpleado(idempleado, incremento);
            Empleado empleado = this.context.BuscarEmpleado(idempleado);
            ViewBag.Mensaje = "Registros modificados: " + afectados;
            return View(empleado);
        }
    }
}
