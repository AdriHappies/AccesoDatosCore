using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Data;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosController : Controller
    {
        //declamramos nuetro objeto context
        EmpleadosContext context;
        public EmpleadosController(EmpleadosContext context)
        {
            //instanciamos el objeto context
            this.context = context;
        }
        public IActionResult Index()
        {
            //usamos los metodos
            List<Empleado> listaempleados = this.context.GetEmpleados();
            return View(listaempleados);
        }
    }
}
