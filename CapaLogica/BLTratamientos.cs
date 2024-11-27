using System;
using System.Collections.Generic;
using System.Text;
using CapaEntidades;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogica
{
    public class BLTratamientos
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLTratamientos(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarTratamiento(EntidadTratamientos tratamiento)
        {
            int idTratamiento = 0;

            DATratamientos accesoDatos = new DATratamientos(_cadenaConexion);

            try
            {
                idTratamiento = accesoDatos.InsertarTratamiento(tratamiento);
            }
            catch (Exception)
            {
                throw;
            }

            return idTratamiento;
        }//Fin InsertarTratamiento

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarTratamientos(string condicion, string orden)
        {
            DataSet DS;
            DATratamientos accesoDatos = new DATratamientos(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarTratamientos(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarTratamientos


    }//Fin clase BLTratamientos
}//Fin namespace
