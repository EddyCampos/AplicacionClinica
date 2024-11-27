using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAPadecimientos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAPadecimientos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarPadecimiento(EntidadPadecimientos padecimiento)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO PADECIMIENTOS(ID_EXPEDIENTE, NOMBRE, DESCRIPCION, ESTADO) VALUES (@ID_EXPEDIENTE, @NOMBRE, @DESCRIPCION, @ESTADO) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_EXPEDIENTE", padecimiento.GetIdExpediente());
            comando.Parameters.AddWithValue("@NOMBRE", padecimiento.GetNombre());
            comando.Parameters.AddWithValue("@DESCRIPCION", padecimiento.GetDescripcion());
            comando.Parameters.AddWithValue("@ESTADO", padecimiento.GetEstado());
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
        }//Fin InsertarSecretario

        //Devuelve un dataSet para mostrar
        public DataSet ListarPadecimientos(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_PADECIMIENTO, ID_EXPEDIENTE, NOMBRE, DESCRIPCION, ESTADO FROM PADECIMIENTOS";

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
                adapter.Fill(datos, "PADECIMIENTOS");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarPadecimientos

    }//Fin clase DAPadecimientos
}//Fin namespace
