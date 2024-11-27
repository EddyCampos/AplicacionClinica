using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaAccesoDatos
{
    public class DAUsuarioIngreso
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAUsuarioIngreso(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarUsuario(EntidadUsuarioIngresos usuario)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO USUARIO_INGRESO(ID_PACIENTE, CORREO_ELECTRONICO, CONTRASENA) VALUES (@ID_PACIENTE, @CORREO_ELECTRONICO, @CONTRASENA) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_PACIENTE", usuario.GetIdPaciente());
            comando.Parameters.AddWithValue("@CORREO_ELECTRONICO", usuario.GetCorreoElectronico());
            comando.Parameters.AddWithValue("@CONTRASENA", usuario.GetContrasena());
            comando.CommandText = sentencia;

            //Ejecutar el comando
            try
            {
                conexion.Open();
                id = Convert.ToInt32(comando.ExecuteScalar());
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

            return id;
        }//Fin InsertarUsuario


        //Devuelve un dataSet para mostrar la tabla
        public DataSet ListarUsuarios(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_USUARIO, ID_PACIENTE, CORREO_ELECTRONICO, CONTRASENA FROM USUARIO_INGRESO";

            if (!string.IsNullOrEmpty(condicion))
            {
                //Si la condicion no esta vacía
                sentencia = string.Format("{0} where {1}", sentencia, condicion);
            }

            if (!string.IsNullOrEmpty(orden))
            {
                //Si la condicion no esta vacía
                sentencia = string.Format("{0} where {1}", sentencia, orden);
            }
            try
            {
                //Se prepara adapter
                adapter = new SqlDataAdapter(sentencia, conexion);

                //Ejecutar sentencia
                adapter.Fill(datos, "USUARIO_INGRESO");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarUsuarios


    }//Fin clase DAUsuarioIngreso
}//Fin namespace
