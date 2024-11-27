using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidades;

namespace CapaAccesoDatos
{
    public class DAPlanillas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public DAPlanillas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Metodo inserta en la base
        public int InsertarPlanilla(EntidadPlanillas planilla)
        {
            //Establecer el objeto de Conexion
            SqlConnection conexion = new SqlConnection(_cadenaConexion);

            //Establecer el objeto para ejecutar comandos SQL
            SqlCommand comando = new SqlCommand();

            //Devolver valor guardado
            int id = 0;
            string sentencia = "INSERT INTO PLANILLAS(ID_EMPLEADO, SALARIO_BRUTO, EXTRAS, DEDUCCIONES, SALARIO_TOTAL) VALUES (@ID_EMPLEADO, @SALARIO_BRUTO, @EXTRAS, @DEDUCCIONES, @SALARIO_TOTAL) SELECT @@Identity";

            //Pasar la conexion al command
            comando.Connection = conexion;

            //Especificar las variables 
            comando.Parameters.AddWithValue("@ID_EMPLEADO", planilla.GetIdEmpleado());
            comando.Parameters.AddWithValue("@SALARIO_BRUTO", planilla.GetSalarioBruto());
            comando.Parameters.AddWithValue("@EXTRAS", planilla.GetExtras());
            comando.Parameters.AddWithValue("@DEDUCCIONES", planilla.GetDeducciones());
            comando.Parameters.AddWithValue("@SALARIO_TOTAL", planilla.GetSalarioTotal());
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
        }//Fin InsertarPlanilla

        //Devuelve un dataSet para mostrar la tabla
        public DataSet ListarPlanilla(string condicion, string orden)
        {
            DataSet datos = new DataSet();//Se guarda en la tabla de la consulta en SQL
            SqlConnection conexion = new SqlConnection(_cadenaConexion);
            SqlDataAdapter adapter;
            string sentencia = "SELECT ID_PLANILLA, ID_EMPLEADO, SALARIO_BRUTO, EXTRAS, DEDUCCIONES, SALARIO_TOTAL FROM PLANILLAS";

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
                adapter.Fill(datos, "PLANILLAS");
            }
            catch (Exception)
            {
                throw;
            }

            //Un tipo dataset
            return datos;

        } //Fin ListarPlanilla




    }//Fin clase DAPlanillas
}//Fin namespace
