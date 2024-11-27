using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAPacientes
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAPacientes(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarPaciente(EntidadPacientes paciente)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO PACIENTES(NUM_CEDULA, NOMBRE, APELLIDO_01, APELLIDO_02, PAIS, PROVINCIA, SEXO, FECHA_NACIMIENTO, ESTADO_CIVIL, CORREO_ELECTRONICO, NUM_TELEFONO, TIPO_SANGRE, ESTADO) VALUES(@CEDULA, @NOMBRE, @APELLIDO1, @APELLIDO2, @PAIS, @PROVINCIA, @SEXO, @FNACIMIENTO, @ESTADO_CIVIL, @CORREO, @TELEFONO, @TIPO_SANGRE, @ESTADO) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@CEDULA", paciente.GetNumCedula());
            comando.Parameters.AddWithValue("@NOMBRE", paciente.GetNombre());
            comando.Parameters.AddWithValue("@APELLIDO1", paciente.GetApellido01());
            comando.Parameters.AddWithValue("@APELLIDO2", paciente.GetApellido02());
            comando.Parameters.AddWithValue("@PAIS", paciente.GetPais());
            comando.Parameters.AddWithValue("@PROVINCIA", paciente.GetProvincia());
            comando.Parameters.AddWithValue("@SEXO", paciente.GetSexo());
            comando.Parameters.AddWithValue("@FNACIMIENTO", paciente.GetFNacimiento());
            comando.Parameters.AddWithValue("@ESTADO_CIVIL", paciente.GetEstadoCivil());
            comando.Parameters.AddWithValue("@CORREO", paciente.GetCorreoElectronico());
            comando.Parameters.AddWithValue("@TELEFONO", paciente.GetNumTelefono());
            comando.Parameters.AddWithValue("@TIPO_SANGRE", paciente.GetTipoSangre());
            comando.Parameters.AddWithValue("@ESTADO", paciente.GetEstado());
            
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
        public DataSet ListarPacientes(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_PACIENTE, NUM_CEDULA, NOMBRE, APELLIDO_01, APELLIDO_02, PAIS, PROVINCIA, SEXO, FECHA_NACIMIENTO, ESTADO_CIVIL, CORREO_ELECTRONICO, NUM_TELEFONO, TIPO_SANGRE, ESTADO FROM PACIENTES";

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
                adapter.Fill(datos, "PACIENTES");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarPacientes

        //Método recibe el ID y devuelve los datos
        public EntidadPacientes ObtenerPaciente(int id)
        {
            EntidadPacientes paciente = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//No tiene constructor se llena con el execute

            string sentencia = string.Format("SELECT ID_PACIENTE, NUM_CEDULA, NOMBRE, APELLIDO_01, APELLIDO_02, PAIS, PROVINCIA, SEXO, FECHA_NACIMIENTO, ESTADO_CIVIL, CORREO_ELECTRONICO, NUM_TELEFONO, TIPO_SANGRE, ESTADO FROM PACIENTES WHERE ID_PACIENTE = {0}", id);
            //Si el Id es texto se escribe entre comillas '{0}'
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    paciente = new EntidadPacientes();
                    dataReader.Read(); //Lee fila por fila del data reader

                    paciente.SetIdCliente(dataReader.GetInt32(0));
                    paciente.SetNumCedula(dataReader.GetString(1));
                    paciente.SetNombre(dataReader.GetString(2));
                    paciente.SetApellido01(dataReader.GetString(3));
                    paciente.SetApellido02(dataReader.GetString(4));
                    paciente.SetPais(dataReader.GetString(5));
                    paciente.SetProvincia(dataReader.GetString(6));
                    paciente.SetSexo(dataReader.GetString(7));
                    paciente.SetFechaNacimiento(dataReader.GetDateTime(8));
                    paciente.SetEstadoCivil(dataReader.GetString(9));
                    paciente.SetCorreoElectronico(dataReader.GetString(10));
                    paciente.SetNumTelefono(dataReader.GetString(11));
                    paciente.SetTipoSangre(dataReader.GetString(12));
                    paciente.SetEstado(dataReader.GetString(13));
                    paciente.SetExiste(true);
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return paciente;
        }//Fin obtenerCliente

        //Método para Actualizar un paciente
        public int ModificarPacientes(EntidadPacientes paciente)
        {
            int filasAfectadas = -1;

            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            string sentencia = "UPDATE PACIENTES SET NUM_CEDULA = @NUM_CEDULA, NOMBRE = @NOMBRE, APELLIDO_01 = @APELLIDO_01, APELLIDO_02 = @APELLIDO_02, PAIS = @PAIS, PROVINCIA = @PROVINCIA, SEXO = @SEXO, FECHA_NACIMIENTO = @FECHA_NACIMIENTO, ESTADO_CIVIL = @ESTADO_CIVIL, CORREO_ELECTRONICO = @CORREO_ELECTRONICO, NUM_TELEFONO = @NUM_TELEFONO, TIPO_SANGRE = @TIPO_SANGRE, ESTADO = @ESTADO WHERE ID_PACIENTE = @ID_PACIENTE";
            comando.CommandText = sentencia;
            comando.Connection = conexion;

            comando.Parameters.AddWithValue("@ID_PACIENTE", paciente.GetIdPaciente());
            comando.Parameters.AddWithValue("@NUM_CEDULA", paciente.GetNumCedula());
            comando.Parameters.AddWithValue("@NOMBRE", paciente.GetNombre());
            comando.Parameters.AddWithValue("@APELLIDO_01", paciente.GetApellido01());
            comando.Parameters.AddWithValue("@APELLIDO_02", paciente.GetApellido02());
            comando.Parameters.AddWithValue("@PAIS", paciente.GetPais());
            comando.Parameters.AddWithValue("@PROVINCIA", paciente.GetProvincia());
            comando.Parameters.AddWithValue("@SEXO", paciente.GetSexo());
            comando.Parameters.AddWithValue("@FECHA_NACIMIENTO", paciente.GetFNacimiento());
            comando.Parameters.AddWithValue("@ESTADO_CIVIL", paciente.GetEstadoCivil());
            comando.Parameters.AddWithValue("@CORREO_ELECTRONICO", paciente.GetCorreoElectronico());
            comando.Parameters.AddWithValue("@NUM_TELEFONO", paciente.GetNumTelefono());
            comando.Parameters.AddWithValue("@TIPO_SANGRE", paciente.GetTipoSangre());
            comando.Parameters.AddWithValue("@ESTADO", paciente.GetEstado());

            try
            {
                conexion.Open();
                filasAfectadas = comando.ExecuteNonQuery();
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

            return filasAfectadas;
        }//Fin ModificarPacientes



    }//Fin clase DAPaciente
}//Fin namespace
