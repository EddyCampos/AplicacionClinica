using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogica
{
    public class BLAuxiliares
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLAuxiliares(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarAuxiliar(EntidadAuxiliares auxiliar)
        {
            int idAuxiliar = 0;

            DAAuxiliares accesoDatos = new DAAuxiliares(_cadenaConexion);

            try
            {
                idAuxiliar = accesoDatos.InsertarAuxiliar(auxiliar);
            }
            catch (Exception)
            {
                throw;
            }

            return idAuxiliar;
        }//Fin InsertarEmpleado

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarAuxiliares(string condicion, string orden)
        {
            DataSet DS;
            DAAuxiliares accesoDatos = new DAAuxiliares(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarAuxiliares(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarAuxiliares

    }//Fin clase BLAuxiliares
}//Fin namespace
