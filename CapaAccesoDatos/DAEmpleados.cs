using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAEmpleados
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAEmpleados(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarEmpleado(EntidadEmpleados empleado)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO EMPLEADOS(NUM_CEDULA, NUM_CARNET, NOMBRE, APELLIDO_01, APELLIDO_02, PAIS, PROVINCIA, SEXO, FECHA_NACIMIENTO, ESTADO_CIVIL, CORREO_ELECTRONICO, NUM_TELEFONO, ESTADO)VALUES(@CEDULA, @CARNET, @NOMBRE, @APELLIDO01, @APELLIDO02, @PAIS, @PROVINCIA, @SEXO, @FNACIMIENTO, @ESTADOCIVIL, @EMAIL, @TELEFONO, @ESTADO) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@CEDULA", empleado.GetNumCedula());
            comando.Parameters.AddWithValue("@CARNET", empleado.GetNumCarnet());
            comando.Parameters.AddWithValue("@NOMBRE", empleado.GetNombre());
            comando.Parameters.AddWithValue("@APELLIDO01", empleado.GetApellido01());
            comando.Parameters.AddWithValue("@APELLIDO02", empleado.GetApellido02());
            comando.Parameters.AddWithValue("@PAIS", empleado.GetPais());
            comando.Parameters.AddWithValue("@PROVINCIA", empleado.GetProvincia());
            comando.Parameters.AddWithValue("@SEXO", empleado.GetSexo());
            comando.Parameters.AddWithValue("@FNACIMIENTO", empleado.GetFNacimiento());
            comando.Parameters.AddWithValue("@ESTADOCIVIL", empleado.GetEstadoCivil());
            comando.Parameters.AddWithValue("@EMAIL", empleado.GetCorreoElectronico());
            comando.Parameters.AddWithValue("@TELEFONO", empleado.GetNumTelefono());
            comando.Parameters.AddWithValue("@ESTADO", empleado.GetEstado());
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

        }//Fin InsertarEmpleado


        //Devuelve un dataSet de Clientes para mostrar en un diagrama
        public DataSet ListarEmpleados(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_EMPLEADO, NUM_CEDULA, NUM_CARNET, NOMBRE, APELLIDO_01, APELLIDO_02, PAIS, PROVINCIA, SEXO, FECHA_NACIMIENTO, ESTADO_CIVIL, CORREO_ELECTRONICO, NUM_TELEFONO, ESTADO FROM EMPLEADOS";

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
                adapter.Fill(datos, "Empleados");
            }
            catch (Exception)
            {

                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarClientes


        //Método recibe el ID y devuelve los datos
        public EntidadEmpleados ObtenerEmpleado(int id)
        {
            EntidadEmpleados empleado = null;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader dataReader;//No tiene constructor se llena con el execute

            string sentencia = string.Format("SELECT ID_EMPLEADO, NUM_CEDULA, NUM_CARNET, NOMBRE, APELLIDO_01, APELLIDO_02, PAIS, PROVINCIA, SEXO, FECHA_NACIMIENTO, ESTADO_CIVIL, CORREO_ELECTRONICO, NUM_TELEFONO, ESTADO FROM EMPLEADOS WHERE ID_EMPLEADO = {0}", id);
            //Si el Id es texto se escribe entre comillas '{0}'
            comando.Connection = conexion;
            comando.CommandText = sentencia;

            try
            {
                conexion.Open();
                dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    empleado = new EntidadEmpleados();
                    dataReader.Read(); //Lee fila por fila del data reader

                    empleado.SetIdEmpleado(dataReader.GetInt32(0));
                    empleado.SetNumCedula(dataReader.GetString(1));
                    empleado.SetNumCarnet(dataReader.GetString(2));
                    empleado.SetNombre(dataReader.GetString(3));
                    empleado.SetApellido01(dataReader.GetString(4));
                    empleado.SetApellido02(dataReader.GetString(5));
                    empleado.SetPais(dataReader.GetString(6));  
                    empleado.SetProvincia(dataReader.GetString(7));
                    empleado.SetSexo(dataReader.GetString(8));
                    empleado.SetFechaNacimiento(dataReader.GetDateTime(9));
                    empleado.SetEstadoCivil(dataReader.GetString(10));
                    empleado.SetCorreoElectronico(dataReader.GetString(11));
                    empleado.SetNumTelefono(dataReader.GetString(12));
                    empleado.SetEstado(dataReader.GetString(13));
                    empleado.SetExiste(true);
                    
                }
                conexion.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return empleado;
        }//Fin ObtenerEmpleado


        //Eliminar un empleado con un stored procedure creado en la DB
        public int EliminarEmpleadoConSP(EntidadEmpleados empleado)
        {
            int resultado = -1;
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();

            //Nombre del procedimiento almacenado
            comando.CommandText = "ELIMINAR_EMPLEADO";

            //Se especifica que tipo de comando es, en este caso es un SP
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = conexion;

            //Paramtero de entrada para el SP
            comando.Parameters.AddWithValue("@IDEMPLEADO", empleado.GetIdEmpleado());

            //Parametro de salida del SP
            comando.Parameters.Add("@MSJ", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            //Se declara otro parametro de retorno del SP qu obtenga el retorno del SP
            comando.Parameters.Add("@RETORNO", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

            try
            {
                conexion.Open();
                //Ejecuta el SP y se llenan las variables de retorno del SP
                comando.ExecuteNonQuery();

                //Obtengo la variable de retorno
                resultado = Convert.ToInt32(comando.Parameters["@RETORNO"].Value);

                //Se va a leer el parametro de salida del SP
                _mensaje = comando.Parameters["@MSJ"].Value.ToString();//Obtiene el mensaje que se devolvio del SP
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }//Fin EliminarEmpleadoConSP


        /// <summary>
        /// Obtiene los datos de los empleados que son medicos
        /// </summary>
        /// <param name="condicion"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        public DataSet ObtenerNombres(string condicion)
        {

            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataAdapter adapter;

            string sentencia = string.Format("SELECT ID_MEDICO, NOMBRE, APELLIDO_01, APELLIDO_02 FROM EMPLEADOS INNER JOIN MEDICOS ON EMPLEADOS.ID_EMPLEADO = MEDICOS.ID_EMPLEADO WHERE ESPECIALIDAD = '{0}'", condicion);
            comando.Connection = conexion;
            comando.CommandText = sentencia;
            
            try
            {
                //Se prepara adapter
                adapter = new SqlDataAdapter(sentencia, conexion);

                //Ejecutar sentencia
                adapter.Fill(datos, "EMPLEADOS");
            }
            catch (Exception)
            {

                throw;
            }

            //Un tipo dataset
            return datos;

        }//Fin ObtenerNombres


    }//Fin clase DAEmpleados
}//Fin namespace
