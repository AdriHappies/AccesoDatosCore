using AccesoDatosCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Data
{
    public class HospitalContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public HospitalContext(String cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Hospital> GetHospitales()
        {
            String sql = "select * from hospital";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Hospital> listahospitales = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital h = new Hospital();
                h.Nombre = this.reader["NOMBRE"].ToString();
                h.Direccion = this.reader["DIRECCION"].ToString();
                h.Telefono = this.reader["TELEFONO"].ToString();
                h.NumCama = (int)this.reader["NUM_CAMA"];
                h.HospitalCod = (int)this.reader["HOSPITAL_COD"];
                listahospitales.Add(h);
            }
            this.reader.Close();
            this.cn.Close();
            return listahospitales;
        }
        public Hospital BuscarHospital(int hospitalcod)
        {
            String sql = "select * from hospital where hospital_cod=@hospitalcod";
            this.com.CommandText = sql;
            SqlParameter pamhoscod = new SqlParameter("@hospitalcod", hospitalcod);
            this.com.Parameters.Add(pamhoscod);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            Hospital hospital = new Hospital();
            if (this.reader.Read())
            {
                
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.NumCama = (int)this.reader["NUM_CAMA"];
                hospital.HospitalCod = (int)this.reader["HOSPITAL_COD"];

            }
            else
            {
                hospital = null;
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return hospital;
        }
        public List<Plantilla> GetPlantilla(int hospitalcod)
        {
            String sql = "select * from plantilla where hospital_cod=@hospitalcod";
            this.com.CommandText = sql;
            SqlParameter pamhoscod = new SqlParameter("@hospitalcod", hospitalcod);
            this.com.Parameters.Add(pamhoscod);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Plantilla> listaplantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla p = new Plantilla();
                p.Apellido = this.reader["APELLIDO"].ToString();
                p.Funcion = this.reader["FUNCION"].ToString();
                p.Salario = (int)this.reader["SALARIO"];
                p.HospitalCod = (int)this.reader["HOSPITAL_COD"];
                listaplantilla.Add(p);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return listaplantilla;
        }
        public List<Doctor> GetDoctores(int hospitalcod)
        {
            String sql = "select * from doctor where hospital_cod=@hospitalcod";
            this.com.CommandText = sql;
            SqlParameter pamhoscod = new SqlParameter("@hospitalcod", hospitalcod);
            this.com.Parameters.Add(pamhoscod);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> listadoctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor d = new Doctor();
                d.DoctorNum = (int)this.reader["DOCTOR_NO"];
                d.Apellido = this.reader["APELLIDO"].ToString();
                d.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                d.Salario = (int)this.reader["SALARIO"];
                d.HospitalCod = (int)this.reader["HOSPITAL_COD"];
                listadoctores.Add(d);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return listadoctores;
        }
    }
}
