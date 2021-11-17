using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Data
{
    public class EmpleadosContext
    {
        //declaramso los objetos de acceso a datos
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        //en el constructor los iniciamos
        //para construir el contexto me tienen que dar una cadena de conexion
        public EmpleadosContext(String cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        //metodos a realizar en la BBDD
        public List<Empleado> GetEmpleados()
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
            return listaempleados;
        }

        public Empleado BuscarEmpleado(int idempleado)
        {
            String sql = "select * from emp where emp_no=@empno";
            this.com.CommandText = sql;
            SqlParameter pamempno = new SqlParameter("@empno", idempleado);
            this.com.Parameters.Add(pamempno);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            Empleado empleado;
            if (this.reader.Read())
            {
                empleado = new Empleado();
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = (int)this.reader["SALARIO"];
            }
            else
            {
                empleado = null;
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return empleado;
        }
    }
}
