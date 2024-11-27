using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAMedicos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAMedicos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarMedico(EntidadMedicos medicos)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO MEDICOS(ID_EMPLEADO, ESPECIALIDAD, NUM_CERTIFICACION) VALUES(@ID_EMPLEADO, @ESPECIALIDAD, @NUM_CERTIFICACION) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_EMPLEADO", medicos.GetIdEmpleado());
            comando.Parameters.AddWithValue("@ESPECIALIDAD", medicos.GetEspecialidad());
            comando.Parameters.AddWithValue("@NUM_CERTIFICACION", medicos.GetNumCertificacion());
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

        //Devuelve un dataSet de Clientes para mostrar
        public DataSet ListarMedicos(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_MEDICO, ID_EMPLEADO, ESPECIALIDAD, NUM_CERTIFICACION FROM MEDICOS";

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
                adapter.Fill(datos, "MEDICOS");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarMedicos

        //Devuelve un dataSet de Clientes para mostrar
        public DataSet MuestraNombre(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT NOMBRE, APELLIDO_01, APELLIDO_02 FROM EMPLEADOS";

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
                adapter.Fill(datos, "MEDICOS");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarMedicos

    }//Fin clase DAMedicos
}//Fin namespace
