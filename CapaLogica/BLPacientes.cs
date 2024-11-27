using System;
using System.Data;
using CapaAccesoDatos;
using CapaEntidades;


namespace CapaLogica
{
    public class BLPacientes
    {
        //Atributos
        private string _cadenaConexion;
        private string _mensaje;

        public string Mensaje { get => _mensaje; }

        public BLPacientes(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            _mensaje = string.Empty;
        }

        //Método para llamar insertar de la capa de Acceso a datos
        public int InsertarPaciente(EntidadPacientes paciente)
        {
            int idPaciente = 0;

            DAPacientes accesoDatos = new DAPacientes(_cadenaConexion);

            try
            {
                idPaciente = accesoDatos.InsertarPaciente(paciente);
            }
            catch (Exception)
            {
                throw;
            }

            return idPaciente;
        }//Fin InsertarPaciente

        //Metodo para llamar lista de clientes dev DataSet
        public DataSet ListarPacientes(string condicion, string orden)
        {
            DataSet DS;
            DAPacientes accesoDatos = new DAPacientes(_cadenaConexion);

            try
            {
                DS = accesoDatos.ListarPacientes(condicion, orden);
            }
            catch (Exception)
            {

                throw;
            }
            return DS;
        }//Fin ListarPacientes

        //Obtiene la información del cliente desde la 
        public EntidadPacientes ObtenerPaciente(int id)
        {
            EntidadPacientes paciente;
            DAPacientes accesoDatos = new DAPacientes(_cadenaConexion);

            try
            {
                paciente = accesoDatos.ObtenerPaciente(id);
            }
            catch (Exception)
            {

                throw;
            }

            return paciente;
        }//Fin ObtenerCliente

        //Llama al metodo de la DA que modifica un cliente
        public int ModificarPacientes(EntidadPacientes paciente)
        {
            int filasAfectadas = 0;
            DAPacientes accesoDatos = new DAPacientes(_cadenaConexion);

            try
            {
                filasAfectadas = accesoDatos.ModificarPacientes(paciente);
            }
            catch (Exception)
            {
                throw;
            }

            return filasAfectadas;
        }//Fin ModificarClientes

    }//Fin clase BLPacientes
}//Fin namespace
