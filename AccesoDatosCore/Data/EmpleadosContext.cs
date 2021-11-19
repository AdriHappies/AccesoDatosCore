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

        public List<Empleado> GetEmpleadosSalario(int salario)
        {
            String sql = "select * from emp where salario>@salario";
            this.com.CommandText = sql;
            SqlParameter pamsalario = new SqlParameter("@salario", salario);
            this.com.Parameters.Add(pamsalario);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Empleado> listaempleados = new List<Empleado>();
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
            this.com.Parameters.Clear();
            if (listaempleados.Count == 0)
            {
                return null;
            }
            else
            {
                return listaempleados;
            }
        }

        public List<String> GetOficios()
        {
            String sql = "select distinct oficio from emp";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<String> listaoficios = new List<String>();
            while (this.reader.Read())
            {
                String oficio = this.reader["OFICIO"].ToString();
                listaoficios.Add(oficio);
            }
            this.reader.Close();
            this.cn.Close();
            return listaoficios;
        }

        public List<Empleado> GetEmpleadosOficio(String oficio)
        {
            String sql = "select * from emp where oficio=@oficio";
            this.com.CommandText = sql;
            SqlParameter pamofico = new SqlParameter("@oficio", oficio);
            this.com.Parameters.Add(pamofico);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Empleado> listaempleados = new List<Empleado>();
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
            this.com.Parameters.Clear();
            return listaempleados;
        }

        public int IncrementarSalarioEmpleado(int idempleado, int incremento)
        {
            String sql = "update emp set salario = salario + @incremento" +
                " where emp_no=@idempleado";
            this.com.CommandText = sql;
            SqlParameter pamincre = new SqlParameter("@incremento", incremento);
            SqlParameter pamid = new SqlParameter("@idempleado", idempleado);
            this.com.Parameters.Add(pamincre);
            this.com.Parameters.Add(pamid);
            this.cn.Open();
            int resultado = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return resultado;
        }
    }
}
