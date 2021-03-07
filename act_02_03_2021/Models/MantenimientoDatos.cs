using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace act_02_03_2021.Models
{
    public class MantenimientoDatos
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Datos art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into tabla (correo,nombreUsuario,clave,repetirClave,apellido,nombre,paisOrigen,provincia,codigoPostal,sexo,fechaNacimiento,comentarios,aceptoTerminos) values (@correo,@nombreUsuario,@clave,@repetirClave,@apellido,@nombre,@paisOrigen,@provincia,@codigoPostal,@sexo,@fechaNacimiento,@comentarios,@aceptoTerminos)", con);
            comando.Parameters.Add("@correo", SqlDbType.VarChar);
            comando.Parameters.Add("@nombreUsuario", SqlDbType.VarChar);
            comando.Parameters.Add("@clave", SqlDbType.VarChar);
            comando.Parameters.Add("@repetirClave", SqlDbType.VarChar);
            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@paisOrigen", SqlDbType.VarChar);
            comando.Parameters.Add("@provincia", SqlDbType.VarChar);
            comando.Parameters.Add("@codigoPostal", SqlDbType.VarChar);
            comando.Parameters.Add("@sexo", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaNacimiento", SqlDbType.VarChar);
            comando.Parameters.Add("@comentarios", SqlDbType.VarChar);
            comando.Parameters.Add("@aceptoTerminos", SqlDbType.VarChar);

            comando.Parameters["@correo"].Value = art.Correo;
            comando.Parameters["@nombreUsuario"].Value = art.NombreUsuario;
            comando.Parameters["@clave"].Value = art.Clave;
            comando.Parameters["@repetirClave"].Value = art.RepetirClave;
            comando.Parameters["@apellido"].Value = art.Apellido;
            comando.Parameters["@nombre"].Value = art.Nombre;
            comando.Parameters["@paisOrigen"].Value = art.PaisOrigen;
            comando.Parameters["@provincia"].Value = art.Provincia;
            comando.Parameters["@codigoPostal"].Value = art.CodigoPostal;
            comando.Parameters["@sexo"].Value = art.Sexo;
            comando.Parameters["@fechaNacimiento"].Value = art.FechaNacimiento;
            comando.Parameters["@comentarios"].Value = art.Comentarios;
            comando.Parameters["@aceptoTerminos"].Value = art.AceptoTerminos;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Datos> RecuperarTodos()
        {
            Conectar();
            List<Datos> datos = new List<Datos>();

            SqlCommand com = new SqlCommand("select correo,nombreUsuario,clave,repetirClave,apellido,nombre,paisOrigen,provincia,codigoPostal,sexo,fechaNacimiento,comentarios,aceptoTerminos from tabla ", con);

            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {
                Datos art = new Datos
                {
                    Correo = registros["correo"].ToString(),
                    NombreUsuario = registros["nombreUsuario"].ToString(),
                    Clave = registros["clave"].ToString(),
                    RepetirClave = registros["repetirClave"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    PaisOrigen = registros["paisOrigen"].ToString(),
                    Provincia = registros["provincia"].ToString(),
                    CodigoPostal = registros["codigoPostal"].ToString(),
                    Sexo = registros["sexo"].ToString(),
                    FechaNacimiento = registros["fechaNacimiento"].ToString(),
                    Comentarios = registros["comentarios"].ToString(),
                    AceptoTerminos = registros["aceptoTerminos"].ToString()
                };
                datos.Add(art);
            }
            con.Close();
            return datos;
        }


        public Datos Recuperar(string nombreUsuario)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select correo,nombreUsuario,clave,repetirClave,apellido,nombre,paisOrigen,provincia,codigoPostal,sexo,fechaNacimiento,comentarios,aceptoTerminos from tabla where nombreUsuario=@nombreUsuario", con);

            comando.Parameters.Add("@nombreUsuario", SqlDbType.VarChar);
            comando.Parameters["@nombreUsuario"].Value = nombreUsuario;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Datos datos = new Datos();
            if (registros.Read())
            {
                datos.Correo = registros["correo"].ToString();
                datos.NombreUsuario = registros["nombreUsuario"].ToString();
                datos.Clave = registros["clave"].ToString();
                datos.RepetirClave = registros["repetirClave"].ToString();
                datos.Apellido = registros["apellido"].ToString();
                datos.Nombre = registros["nombre"].ToString();
                datos.PaisOrigen = registros["paisOrigen"].ToString();
                datos.Provincia = registros["provincia"].ToString();
                datos.CodigoPostal = registros["codigoPostal"].ToString();
                datos.Sexo = registros["sexo"].ToString();
                datos.FechaNacimiento = registros["fechaNacimiento"].ToString();
                datos.Comentarios = registros["comentarios"].ToString();
                datos.AceptoTerminos = registros["aceptoTerminos"].ToString();
            }
            con.Close();
            return datos;
        }

        public int Modificar(Datos art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update tabla set correo=@correo,nombreUsuario=@nombreUsuario,clave=@clave,repetirClave=@repetirClave,apellido=@apellido,nombre=@nombre,paisOrigen=@paisOrigen,provincia=@provincia,codigoPostal=@codigoPostal,sexo=@sexo,fechaNacimiento=@fechaNacimiento,comentarios=@comentarios,aceptoTerminos=@aceptoTerminos where nombreUsuario=@nombreUsuario", con);


            comando.Parameters.Add("@correo", SqlDbType.VarChar);
            comando.Parameters["@correo"].Value = art.Correo;

            comando.Parameters.Add("@nombreUsuario", SqlDbType.VarChar);
            comando.Parameters["@nombreUsuario"].Value = art.NombreUsuario;

            comando.Parameters.Add("@clave", SqlDbType.VarChar);
            comando.Parameters["@clave"].Value = art.Clave;

            comando.Parameters.Add("@repetirClave", SqlDbType.VarChar);
            comando.Parameters["@repetirClave"].Value = art.RepetirClave;

            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters["@apellido"].Value = art.Apellido;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = art.Nombre;

            comando.Parameters.Add("@paisOrigen", SqlDbType.VarChar);
            comando.Parameters["@paisOrigen"].Value = art.PaisOrigen;

            comando.Parameters.Add("@provincia", SqlDbType.VarChar);
            comando.Parameters["@provincia"].Value = art.Provincia;

            comando.Parameters.Add("@codigoPostal", SqlDbType.VarChar);
            comando.Parameters["@codigoPostal"].Value = art.CodigoPostal;

            comando.Parameters.Add("@sexo", SqlDbType.VarChar);
            comando.Parameters["@sexo"].Value = art.Sexo;

            comando.Parameters.Add("@fechaNacimiento", SqlDbType.VarChar);
            comando.Parameters["@fechaNacimiento"].Value = art.FechaNacimiento;

            comando.Parameters.Add("@comentarios", SqlDbType.VarChar);
            comando.Parameters["@comentarios"].Value = art.Comentarios;

            comando.Parameters.Add("@aceptoTerminos", SqlDbType.VarChar);
            comando.Parameters["@aceptoTerminos"].Value = art.AceptoTerminos;


            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public int Borrar(string nombreUsuario)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from tabla where nombreUsuario=@nombreUsuario", con);
            comando.Parameters.Add("@nombreUsuario", SqlDbType.VarChar);
            comando.Parameters["@nombreUsuario"].Value = nombreUsuario;
            con.Open();

            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}