using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLMedicos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLMedicos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarMedico(EntidadMedicos medico)
        {
            int idMedico = 0;

            DAMedicos accesoDatos = new DAMedicos(_cadenaConexion);

            try
            {
                idMedico = accesoDatos.InsertarMedico(medico);
            }
            catch (Exception)
            {
                throw;
            }

            return idMedico;
        }//Fin InsertarEmpleado

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarMedicos(string condicion, string orden)
        {
            DataSet DS;
            DAMedicos accesoDatos = new DAMedicos(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarMedicos(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarMedicos

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarNombres(string condicion, string orden)
        {
            DataSet DS;
            DAMedicos accesoDatos = new DAMedicos(_cadenaConexion);

            try
            {
                DS = accesoDatos.MuestraNombre(condicion, orden);
            }
            catch (Exception)
            {
                throw;
            }
            return DS;
        }//Fin ListarMedicos

    }//Fin clase BLMedicos
}//Fin namespace
