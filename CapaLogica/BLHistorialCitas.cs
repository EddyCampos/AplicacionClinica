using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLHistorialCitas
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLHistorialCitas(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarHistorialCitas(EntidadHistorialCitas historialCita)
        {
            int idHistorialCita = 0;

            DAHistorialCitas accesoDatos = new DAHistorialCitas(_cadenaConexion);

            try
            {
                idHistorialCita = accesoDatos.InsertarHistorialCitas(historialCita);
            }
            catch (Exception)
            {
                throw;
            }

            return idHistorialCita;
        }//Fin InsertarHistorialCitas

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarHistorialCitas(string condicion, string orden)
        {
            DataSet DS;
            DAHistorialCitas accesoDatos = new DAHistorialCitas(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarHistorialCitas(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarHistorialCitas


    }//Fin clase BLHistorialCitas
}//Fin namespace
