using AccesoDatosCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Data
{
    public class PlantillasContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public PlantillasContext(String cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Plantilla> GetPlantilla()
        {
            String sql = "select * from plantilla";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Plantilla> listaplantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla p = new Plantilla();
                p.Apellido = this.reader["APELLIDO"].ToString();
                p.Funcion = this.reader["FUNCION"].ToString();
                p.Salario = (int)this.reader["SALARIO"];
                listaplantilla.Add(p);
            }
            this.reader.Close();
            this.cn.Close();
            return listaplantilla;
        }
    }
}
