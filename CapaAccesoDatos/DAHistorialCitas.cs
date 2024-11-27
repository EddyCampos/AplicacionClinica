using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAHistorialCitas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAHistorialCitas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarHistorialCitas(EntidadHistorialCitas historialCita)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO HISTORIAL_CITAS(ID_EXPEDIENTE, FECHA, HORA, ID_MEDICO_RESPONSABLE, MOTIVO) VALUES(@ID_EXPEDIENTE, @FECHA, @HORA, @ID_MEDICO_RESPONSABLE, @MOTIVO) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_EXPEDIENTE", historialCita.GetIdExpediente());
            comando.Parameters.AddWithValue("@FECHA", historialCita.GetFecha());
            comando.Parameters.AddWithValue("@HORA", historialCita.GetHora());
            comando.Parameters.AddWithValue("@ID_MEDICO_RESPONSABLE", historialCita.GetIdMedicoResponsable());
            comando.Parameters.AddWithValue("@MOTIVO", historialCita.GetMotivo());

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
        }//Fin InsertarHistorialCitas

        //Devuelve un dataSet para mostrar la tabla
        public DataSet ListarHistorialCitas(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_HISTORIAL_CITAS, ID_EXPEDIENTE, FECHA, HORA, ID_MEDICO_RESPONSABLE, MOTIVO FROM HISTORIAL_CITAS";

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
                adapter.Fill(datos, "HISTORIAL_CITAS");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarAgenda


    }//Fin clase DAHistorialCitas
}//Fin namespace
