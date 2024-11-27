using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAConsultas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAConsultas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarConsulta(EntidadConsultas consulta)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO CONSULTAS(ID_MEDICO, ID_PACIENTE, DIA, HORA, MOTIVO) VALUES(@ID_MEDICO, @ID_PACIENTE, @DIA, @HORA, @MOTIVO) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_MEDICO", consulta.GetIdMedico());
            comando.Parameters.AddWithValue("@ID_PACIENTE", consulta.GetIdPaciente());
            comando.Parameters.AddWithValue("@DIA", consulta.GetDia());
            comando.Parameters.AddWithValue("@HORA", consulta.GetHora());
            comando.Parameters.AddWithValue("@MOTIVO", consulta.GetMotivo());
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
        }//Fin InsertarConsulta

        //Devuelve un dataSet para mostrar la tabla
        public DataSet ListarConsultas(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_CONSULTA, ID_MEDICO, ID_PACIENTE, DIA, HORA, MOTIVO FROM CONSULTAS";

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
                adapter.Fill(datos, "CONSULTAS");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarConsultas

        //Método recibe el ID del medico y devuelve los datos
        public DataSet ObtenerListaConsultas(int condicion)
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter adapter;

            string sentencia = string.Format("SELECT ID_MEDICO, DIA, HORA FROM CONSULTAS WHERE ID_MEDICO = {0}", condicion);
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                //Se prepara el adapter
                adapter = new SqlDataAdapter(sentencia, conexion);

                //Ejecutar sentencia
                adapter.Fill(datos, "CONSULTAS");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }//Fin ObtenerHorario

        //Método recibe el ID del medico y devuelve los datos
        public EntidadConsultas ObtenerAgendaMedico(int id)
        {
            EntidadConsultas horario = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//No tiene constructor se llena con el execute
            string sentencia = string.Format("SELECT ID_MEDICO, DIA, HORA FROM CONSULTAS WHERE ID_MEDICO = {0}", id);
            //Si el Id es texto se escribe entre comillas '{0}'
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    horario = new EntidadConsultas();
                    dataReader.Read(); //Lee fila por fila del data reader
                    horario.SetIdMedico(dataReader.GetInt32(0));
                    horario.SetDia(dataReader.GetDateTime(1));
                    horario.SetHora(dataReader.GetDateTime(2));
                    horario.SetExiste(true);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return horario;
        }//Fin ObtenerHorario

        /// <summary>
        /// Obtiene los datos de la consulta, nombres, especialidades...
        /// </summary>
        /// <returns></returns>
        public DataSet ListarDatosConsultasCompletos()
        {
            DataSet datos = new DataSet();
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter adapter;

            string sentencia = string.Format("SELECT C.ID_CONSULTA AS ID_CONSULTA, P.ID_PACIENTE, P.NOMBRE AS NOMBRE_P, P.APELLIDO_01 AS APELLIDO1_P, P.APELLIDO_02 AS APELLIDO2_P, E.NOMBRE AS NOMBRE_E, E.APELLIDO_01 AS APELLIDO1_3, E.APELLIDO_02 AS APELLIDO1_E, ESPECIALIDAD, DIA, HORA FROM PACIENTES AS P INNER JOIN CONSULTAS AS C ON P.ID_PACIENTE = C.ID_PACIENTE INNER JOIN MEDICOS AS M ON C.ID_MEDICO = M.ID_MEDICO INNER JOIN EMPLEADOS AS E ON M.ID_EMPLEADO = E.ID_EMPLEADO");
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                //Se prepara el adapter
                adapter = new SqlDataAdapter(sentencia, conexion);

                //Ejecutar sentencia
                adapter.Fill(datos, "CONSULTAS");
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }

    }//Fin clase DAConsultas
}//Fin namespace
