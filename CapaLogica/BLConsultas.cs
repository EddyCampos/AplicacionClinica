using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogica
{
    public class BLConsultas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLConsultas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarConsulta(EntidadConsultas consulta)
        {
            int idConsulta = 0;

            DAConsultas accesoDatos = new DAConsultas(_cadenaConexion);

            try
            {
                idConsulta = accesoDatos.InsertarConsulta(consulta);
            }
            catch (Exception)
            {
                throw;
            }

            return idConsulta;
        }//Fin InsertarConsulta

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarConsultas(string condicion, string orden)
        {
            DataSet DS;
            DAConsultas accesoDatos = new DAConsultas(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarConsultas(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarConsultas

        //Obtiene la información del cliente desde la 
        public DataSet ObtenerListaConsultas(int condicion)
        {
            DataSet DS;
            DAConsultas accesoDatos = new DAConsultas(_cadenaConexion);

            try
            {
                DS = accesoDatos.ObtenerListaConsultas(condicion);
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }//Fin ObtenerExpedientes
        
        /// <summary>
        /// Obtiene el metodo que lista los datos completos de la consulta
        /// </summary>
        /// <returns></returns>
        public DataSet ListarDatosConsultasCompletos()
        {
            DataSet DS;
            DAConsultas accesoDatos = new DAConsultas(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarDatosConsultasCompletos();
            }
            catch (Exception)
            {

                throw;
            }

            return DS;
        }//Fin ObtenerExpedientes



    }//Fin clase BLConsultas
}//Fin namespace
