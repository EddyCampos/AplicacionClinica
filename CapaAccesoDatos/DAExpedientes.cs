using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapaAccesoDatos
{
    public class DAExpedientes
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAExpedientes(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarExpediente(EntidadExpedientes expediente)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO EXPEDIENTES(ID_PACIENTE, FECHA_CREACION) VALUES(@ID_PACIENTE, @F_CREACION) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_PACIENTE", expediente.GetIdPaciente());
            comando.Parameters.AddWithValue("@F_CREACION", expediente.GetFCreacion());
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
        }//Fin InsertarExpediente

        //Devuelve un dataSet de Clientes para mostrar
        public DataSet ListarExpedientes(string condicion, string orden, string id)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = string.Format("SELECT ID_EXPEDIENTE, ID_PACIENTE, FECHA_CREACION FROM EXPEDIENTES WHERE ID_PACIENTE = {0}", condicion);
            try
            {
                //Se prepara adapter
                adapter = new SqlDataAdapter(sentencia, conexion);
                //Ejecutar sentencia
                adapter.Fill(datos, "EXPEDIENTES");
                ObtenerExpediente(id);
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarExpedientes

        //Método recibe el ID del clientesy devuelve la entidad cliente
        public EntidadExpedientes ObtenerExpediente(string id)
        {
            EntidadExpedientes expediente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//No tiene constructor se llena con el execute
            
            string sentencia = string.Format("SELECT ID_EXPEDIENTE, ID_PACIENTE, FECHA_CREACION FROM EXPEDIENTES WHERE ID_PACIENTE = {0}", id);
            //Si el Id es texto se escribe entre comillas '{0}'
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    expediente = new EntidadExpedientes();
                    dataReader.Read(); //Lee fila por fila del data reader

                    expediente.SetIdExpediente(dataReader.GetInt32(0));
                    expediente.SetIdPaciente(dataReader.GetInt32(1));
                    expediente.SetFCreacion(dataReader.GetDateTime(2));
                    expediente.SetExiste(true);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return expediente;
        }//Fin ObtenerExpediente

    }//Fin clase DAExpedientes
}//Fin namespace
