using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAAgendas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAAgendas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarAgenda(EntidadAgendas agenda)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO AGENDA(ID_MEDICO, DIA, HORA_ENTRADA, HORA_SALIDA) VALUES(@ID_MEDICO, @DIA, @H_ENTRADA, @H_SALIDA) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_MEDICO", agenda.GetIdMedico());
            comando.Parameters.AddWithValue("@DIA", agenda.GetDia());
            comando.Parameters.AddWithValue("@H_ENTRADA", agenda.GetHEntrada());
            comando.Parameters.AddWithValue("@H_SALIDA", agenda.GetHSalida());
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
        public DataSet ListarAgenda(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_AGENDA, ID_MEDICO, DIA, HORA_ENTRADA, HORA_SALIDA FROM AGENDA";

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
                adapter.Fill(datos, "AGENDA");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarAgenda

        /// <summary>
        /// Obtiene la agenda del respectivo medico que recibe
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        public DataSet ObtenerAgendaMedico(int condicion)
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter adapter;

            string sentencia = string.Format("SELECT DIAS_SEMANA, HORA_ENTRADA, HORA_SALIDA FROM AGENDA A INNER JOIN MEDICOS ME ON A.ID_MEDICO = ME.ID_MEDICO WHERE A.ID_MEDICO = {0}", condicion);
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                //Se prepara el adapter
                adapter = new SqlDataAdapter(sentencia, conexion);

                //Ejecutar sentencia
                adapter.Fill(datos, "AGENDA");
            }
            catch (Exception)
            {

                throw;
            }

            return datos;
        }


    }//Fin clase DAAgendas
}//Fin namespace
