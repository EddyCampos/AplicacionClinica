using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLEmpleados
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLEmpleados(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarEmpleado(EntidadEmpleados empleado)
        {
            int idEmpleado = 0;

            DAEmpleados accesoDatos = new DAEmpleados(_cadenaConexion);

            try
            {
                idEmpleado = accesoDatos.InsertarEmpleado(empleado);
            }
            catch (Exception)
            {
                throw;
            }

            return idEmpleado;
        }//Fin InsertarEmpleado

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarEmpleados(string condicion, string orden)
        {
            DataSet DS;
            DAEmpleados accesoDatos = new DAEmpleados(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarEmpleados(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarEmpleados


        //Obtiene la información del empleado buscado
        public EntidadEmpleados ObtenerEmpleado(int id)
        {
            EntidadEmpleados empleado;
            DAEmpleados accesoDatos = new DAEmpleados(_cadenaConexion);

            try
            {
                empleado = accesoDatos.ObtenerEmpleado(id);
            }
            catch (Exception)
            {

                throw;
            }
            return empleado;
        }//Fin ObtenerEmpleado

        //Llama el procedimiento de la capa de acceso a datos que elimina con un SP
        public int EliminarEmpleadoConSP(EntidadEmpleados empleado)
        {
            int resultado;
            DAEmpleados accesoDatos = new DAEmpleados(_cadenaConexion);

            try
            {
                //Aqui se pueden hacer las validaciones antes de eliminar o agregar una logica de programacion
                resultado = accesoDatos.EliminarEmpleadoConSP(empleado);
                _mensaje = accesoDatos.Mensaje;
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }//Fin EliminarEmpleadoConSP

        /// <summary>
        /// Obtiene de la capa de acceso el metodo ObtenerNombres
        /// </summary>
        /// <param name="condicion"></param>
        /// <param name="orden"></param>
        /// <returns></returns>
        public DataSet ObtenerNombres(string condicion)
        {
            DataSet DS;
            DAEmpleados accesoDatos = new DAEmpleados(_cadenaConexion);

            try
            {
                DS = accesoDatos.ObtenerNombres(condicion);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }


    }//Fin clase BLEmpleados
}//Fin namespace
