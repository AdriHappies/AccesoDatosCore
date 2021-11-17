using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Models
{
    public class Bici
    {
        public String Marca { get; set; }
        public String Imagen { get; set; }
        public int Velocidad { get; set; }
        public int Aceleracion { get; set; }
        
        public int Acelerar()
        {
            this.Velocidad = this.Velocidad + this.Aceleracion;
            return this.Velocidad;
        }
        public int Frenar()
        {
            this.Velocidad = this.Velocidad - this.Aceleracion;
            if (this.Velocidad < 0)
            {
                this.Velocidad = 0;
            }
            return this.Velocidad;
        }
    }
}
