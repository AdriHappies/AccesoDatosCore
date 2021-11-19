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
        public List<Plantilla> BuscarPlantilla(String funcion)
        {
            String sql = "select * from plantilla where funcion=@funcion";
            this.com.CommandText = sql;
            SqlParameter pamfun = new SqlParameter("@funcion", funcion);
            this.com.Parameters.Add(pamfun);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Plantilla> listaplantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla p = new Plantilla();
                p.Apellido = this.reader["APELLIDO"].ToString();
                p.Funcion = this.reader["FUNCION"].ToString();
                p.Salario = (int)this.reader["SALARIO"];
                p.IdPlantilla = (int)this.reader["EMPLEADO_NO"];
                p.Turno = this.reader["T"].ToString();
                listaplantilla.Add(p);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return listaplantilla;
        }
        public List<Plantilla> GetPlantillaTurno(String turno)
        {
            String sql = "select * from plantilla where t=@turno";
            this.com.CommandText = sql;
            SqlParameter pamturno = new SqlParameter("@turno", turno);
            this.com.Parameters.Add(pamturno);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Plantilla> listaplantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla p = new Plantilla();
                p.Apellido = this.reader["APELLIDO"].ToString();
                p.Funcion = this.reader["FUNCION"].ToString();
                p.Salario = (int)this.reader["SALARIO"];
                p.Turno = this.reader["T"].ToString();
                listaplantilla.Add(p);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            if(listaplantilla.Count == 0)
            {
                return null;
            }
            else
            {
                return listaplantilla;
            }
        }

        public List<String> GetFuncionPlantilla()
        {
            String sql = "select distinct funcion from plantilla";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<String> listafunciones = new List<String>();
            while (this.reader.Read())
            {
                String funcion = this.reader["FUNCION"].ToString();
                listafunciones.Add(funcion);
            }
            this.reader.Close();
            this.cn.Close();
            return listafunciones;
        }

        public int IncrementarSalarioPlantilla(String funcion, int incremento)
        {
            String sql = "update plantilla set salario = salario + @incremento" +
                " where FUNCION=@funcion";
            this.com.CommandText = sql;
            SqlParameter pamincre = new SqlParameter("@incremento", incremento);
            SqlParameter pamfun = new SqlParameter("@funcion", funcion);
            this.com.Parameters.Add(pamincre);
            this.com.Parameters.Add(pamfun);
            this.cn.Open();
            int resultado = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return resultado;
        }
    }
}
