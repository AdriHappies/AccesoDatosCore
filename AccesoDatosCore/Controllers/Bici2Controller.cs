using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Controllers
{
    public class Bici2Controller : Controller
    {
        private Bici bike;

        public Bici2Controller(Bici bici)
        {
            this.bike = bici;
        }
        public IActionResult Index()
        {
            return View(this.bike);
        }
    }
}
