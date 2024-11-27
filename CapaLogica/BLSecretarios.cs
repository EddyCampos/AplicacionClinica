using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLSecretarios
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLSecretarios(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarSecretario(EntidadSecretarios secretario)
        {
            int idSecretario = 0;

            DASecretarios accesoDatos = new DASecretarios(_cadenaConexion);

            try
            {
                idSecretario = accesoDatos.InsertarSecretario(secretario);
            }
            catch (Exception)
            {

                throw;
            }

            return idSecretario;
        }//Fin InsertarSecretario

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarSecretarios(string condicion, string orden)
        {
            DataSet DS;
            DASecretarios accesoDatos = new DASecretarios(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarSecretarios(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarClientes


    }//Fin clase BLSecretarios
}//Fin namespace
