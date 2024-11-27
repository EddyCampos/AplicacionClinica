using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLExpedientes
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLExpedientes(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarExpediente(EntidadExpedientes expediente)
        {
            int idExpediente = 0;

            DAExpedientes accesoDatos = new DAExpedientes(_cadenaConexion);

            try
            {
                idExpediente = accesoDatos.InsertarExpediente(expediente);
            }
            catch (Exception)
            {
                throw;
            }

            return idExpediente;
        }//Fin InsertarExpediente

        //Metodo para llamar lista dev DataSet
        public DataSet ListarExpedientes(string condicion, string orden, string id)
        {
            DataSet DS;
            DAExpedientes accesoDatos = new DAExpedientes(_cadenaConexion);

            EntidadExpedientes expediente;

            try
            {
                DS = accesoDatos.ListarExpedientes(condicion, orden, id);
                expediente = accesoDatos.ObtenerExpediente(id);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }//Fin ListarExpedientes

        //Obtiene la información del cliente desde la 
        public EntidadExpedientes ObtenerExpedientes(string id)
        {
            EntidadExpedientes expediente;
            DAExpedientes accesoDatos = new DAExpedientes(_cadenaConexion);

            try
            {
                expediente = accesoDatos.ObtenerExpediente(id);
            }
            catch (Exception)
            {

                throw;
            }

            return expediente;
        }//Fin ObtenerExpedientes


    }//Fin clase BLExpedientes
}//Fin namespace
