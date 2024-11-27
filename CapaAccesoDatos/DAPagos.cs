using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAPagos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAPagos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarPago(EntidadPagos pago)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO PAGOS(ID_PACIENTE, MONTO, METODO_PAGO, ESTADO) VALUES(@ID_PACIENTE, @MONTO, @METODO_PAGO, @ESTADO) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_PACIENTE", pago.GetIdPaciente());
            comando.Parameters.AddWithValue("@MONTO", pago.GetMonto());
            comando.Parameters.AddWithValue("@METODO_PAGO", pago.GetMetodoPago());
            comando.Parameters.AddWithValue("@ESTADO", pago.GetEstado());
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
        }//Fin InsertarAgenda

        //Devuelve un dataSet para mostrar la tabla
        public DataSet ListarPagos(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_PAGO, ID_PACIENTE, MONTO, METODO_PAGO, ESTADO FROM PAGOS";

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
                adapter.Fill(datos, "PAGOS");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarPagos

    }//Fin clase DAPagos
}//Fin namespace
