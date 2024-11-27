using System;

namespace CapaEntidades
{
    public class EntidadPacientes: EntidadPersona
    {
        //Atributos
        private int _idPaciente;
        private string _tipoSangre;

        //Constructor Vacio
        public EntidadPacientes(): base()
        {
            _idPaciente = 0;
            _tipoSangre = string.Empty;
        }

        //Constructor con Parámetros
        public EntidadPacientes(string numCedula, string nombre, string apellido01, string apellido02, string pais, string provincia, string sexo, DateTime? fNacimiento, string estadoCivil, string correoElectronico, string numTelefono, string estado, bool existe, int idPaciente, string tipoSangre) : base(numCedula, nombre, apellido01, apellido02, pais, provincia, sexo, fNacimiento, estadoCivil, correoElectronico, numTelefono, estado, existe)
        {
            this._idPaciente = idPaciente;
            this._tipoSangre = tipoSangre;
        }

        //Métodos de acceso
        public int IdPaciente { get => _idPaciente; set => _idPaciente = value; }
        public string TipoSangre { get => _tipoSangre; set => _tipoSangre = value; }

        //Set
        public void SetIdCliente(int idPaciente) { this._idPaciente = idPaciente; }
 
        public void SetTipoSangre(string tipoSangre) { this._tipoSangre = tipoSangre; }
 
        //Get
        public int GetIdPaciente() { return _idPaciente; }
   
        public string GetTipoSangre() { return _tipoSangre; }


    }//Fin clase EntidadPacientes
}//Fin namespace
