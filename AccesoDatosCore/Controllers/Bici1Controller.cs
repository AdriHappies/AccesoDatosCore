using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class Bici1Controller : Controller
    {
        private Bici bike;

        public Bici1Controller(Bici bici)
        {
            this.bike = bici;
        }
        public IActionResult Index()
        {
            return View(this.bike);
        }
        [HttpPost]
        public IActionResult Index(string accion)
        {
            if (accion == "acelerar")
            {
                this.bike.Acelerar();
            }
            else
            {
                this.bike.Frenar();
            }
            return View(this.bike);
        }
    }
}
