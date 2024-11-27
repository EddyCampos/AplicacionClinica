using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLPadecimientos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLPadecimientos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarPadecimiento(EntidadPadecimientos padecimiento)
        {
            int idPadecimiento = 0;

            DAPadecimientos accesoDatos = new DAPadecimientos(_cadenaConexion);

            try
            {
                idPadecimiento = accesoDatos.InsertarPadecimiento(padecimiento);
            }
            catch (Exception)
            {
                throw;
            }

            return idPadecimiento;
        }//Fin InsertarPadecimiento


        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarPadecimientos(string condicion, string orden)
        {
            DataSet DS;
            DAPadecimientos accesoDatos = new DAPadecimientos(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarPadecimientos(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarPadecimientos

    }//Fin BLPadecimientos
}//Fin namespace
