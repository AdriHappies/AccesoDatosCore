using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoDatosCore.Controllers
{
    public class EmpleadosController : Controller
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public EmpleadosController()
        {
            this.cadenaconexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=azure";
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public IActionResult Index()
        {
            String sql = "select * from emp";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Empleado> listaempleados = new List<Empleado>();
            //leemos un conjunto de empleados
            while (this.reader.Read())
            {
                Empleado empleado = new Empleado();
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = (int)this.reader["SALARIO"];
                listaempleados.Add(empleado);
            }

            this.reader.Close();
            this.cn.Close();
            return View(listaempleados);
        }
    }
}
