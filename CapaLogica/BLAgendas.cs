using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogica
{
    public class BLAgendas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLAgendas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarAgenda(EntidadAgendas agenda)
        {
            int idAgenda= 0;

            DAAgendas accesoDatos = new DAAgendas(_cadenaConexion);

            try
            {
                idAgenda = accesoDatos.InsertarAgenda(agenda);
            }
            catch (Exception)
            {
                throw;
            }

            return idAgenda;
        }//Fin InsertarEmpleado

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarAgenda(string condicion, string orden)
        {
            DataSet DS;
            DAAgendas accesoDatos = new DAAgendas(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarAgenda(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarAgenda

        /// <summary>
        /// Obtiene la agenda del respectivo medico
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns></returns>
        public DataSet ObtenerAgendaMedico(int condicion)
        {
            DataSet ds;
            DAAgendas accesoDatos = new DAAgendas(_cadenaConexion);

            try
            {
                ds = accesoDatos.ObtenerAgendaMedico(condicion);
            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }

    }//Clase BLAgendas
}//Fin namespace
