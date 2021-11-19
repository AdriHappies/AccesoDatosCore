using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;
using AccesoDatosCore.Data;

namespace AccesoDatosCore.Controllers
{
    public class EnfermosController : Controller
    {
        EnfermosContext context;
        public EnfermosController(EnfermosContext context)
        {
            this.context = context;
        }
        
        public IActionResult EliminarBoton()
        {
            List<Enfermo> listaenfermos = this.context.GetEnfermos();
            ViewBag.Elim = 0;
            return View(listaenfermos);
        }
        [HttpPost]
        public IActionResult EliminarBoton(int inscripcion)
        {
            List<Enfermo> listaenfermos = this.context.GetEnfermos();
            int eliminados = this.context.EliminarEnfermo(inscripcion);
            ViewBag.Elim = eliminados;
            return View(listaenfermos);
        }

        public IActionResult EliminarLista(string inscripcion)
        {
            if (inscripcion != null)
            {
                int eliminados = this.context.EliminarEnfermo(int.Parse(inscripcion));
                List<Enfermo> listaenfermos = this.context.GetEnfermos();
                ViewBag.Elim = eliminados;
                return View(listaenfermos);
            }
            else
            {
                List<Enfermo> listaenfermos = this.context.GetEnfermos();
                ViewBag.Elim = 0;
                return View(listaenfermos);
            }
            
        }
    }
}
