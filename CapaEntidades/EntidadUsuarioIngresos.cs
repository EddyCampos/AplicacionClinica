using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadUsuarioIngresos
    {
        //Atributos
        private int _idUsuario;
        private int _idPaciente;
        private string _correoElectronico;
        private string _contrasena;
        private bool _existe;

        //Constructor Vacio
        public EntidadUsuarioIngresos()
        {
            _idUsuario = 0;
            _idPaciente = 0;
            _correoElectronico = string.Empty;
            _contrasena = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadUsuarioIngresos(int idUsuario, int idPaciente, string correoElectronico, string contrasena, bool existe)
        {
            this._idUsuario = idUsuario;
            this._idPaciente = idPaciente;
            this._correoElectronico = correoElectronico;
            this._contrasena = contrasena;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdUsuario(int idUsuario) { this._idUsuario = idUsuario; }
        public void SetIdPaciente(int idPaciente) { this._idPaciente = idPaciente; }
        public void SetCorreoElectronico(string correoElectronico) { this._correoElectronico = correoElectronico; }
        public void SetContrasena(string contrasena) { this._contrasena = contrasena; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdUsuario() { return _idUsuario; }
        public int GetIdPaciente() { return _idPaciente; }
        public string GetCorreoElectronico() { return _correoElectronico; }
        public string GetContrasena() { return _contrasena; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadUsuarioIngresos
}//Fin namespace
