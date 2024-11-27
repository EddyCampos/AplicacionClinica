using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLPlanillas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLPlanillas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarPlanilla(EntidadPlanillas planilla)
        {
            int idPlanilla = 0;

            DAPlanillas accesoDatos = new DAPlanillas(_cadenaConexion);

            try
            {
                idPlanilla = accesoDatos.InsertarPlanilla(planilla);
            }
            catch (Exception)
            {
                throw;
            }

            return idPlanilla;
        }//Fin InsertarPlanilla

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarPlanilla(string condicion, string orden)
        {
            DataSet DS;
            DAPlanillas accesoDatos = new DAPlanillas(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarPlanilla(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarPlanilla

    }//Fin clase BLPlanillas
}//Fin namespace
