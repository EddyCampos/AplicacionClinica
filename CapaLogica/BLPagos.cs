using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLPagos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLPagos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarPago(EntidadPagos pago)
        {
            int idPago = 0;

            DAPagos accesoDatos = new DAPagos(_cadenaConexion);

            try
            {
                idPago = accesoDatos.InsertarPago(pago);
            }
            catch (Exception)
            {
                throw;
            }

            return idPago;
        }//Fin InsertarPago

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarPagos(string condicion, string orden)
        {
            DataSet DS;
            DAPagos accesoDatos = new DAPagos(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarPagos(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarPagos


    }//Fin clase BLPagos
}//Fin namespace
