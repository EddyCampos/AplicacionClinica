using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadEmpleados : EntidadPersona
    {
        //Atributos
        private int _idEmpleado;
        string _numCarnet;

        //Constructor Vacio
        public EntidadEmpleados() : base()
        {
            _idEmpleado = 0;
            _numCarnet = string.Empty;
        }

        //Constructor con Parámetros
        public EntidadEmpleados(string numCedula, string nombre, string apellido01, string apellido02, string pais, string provincia, string sexo, DateTime? fNacimiento, string estadoCivil, string correoElectronico, string numTelefono, string estado, bool existe, int idEmpleado, string numCarnet) : base(numCedula, nombre, apellido01, apellido02, pais, provincia, sexo, fNacimiento, estadoCivil, correoElectronico, numTelefono, estado, existe)
        {
            this._idEmpleado = idEmpleado;
            this._numCarnet = numCarnet;
        }

        //Métodos de acceso
        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public string NumCarnet { get => _numCarnet; set => _numCarnet = value; }

        //Set
        public void SetIdEmpleado(int idEmpleado) { this._idEmpleado = idEmpleado; }
        public void SetNumCarnet(string numCarnet) { this._numCarnet = numCarnet; }
        
        //Get
        public int GetIdEmpleado() { return _idEmpleado; }
        public string GetNumCarnet() { return _numCarnet; }

    }//Fin clase EntidadEmpleados
}//Fin namespace
