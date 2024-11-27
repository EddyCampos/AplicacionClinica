using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadSecretarios
    {
        //Atributos
        private int _idSecretario;
        private int _idEmpleado;
        private bool _existe;

        //Constructor Vacio
        public EntidadSecretarios()
        {
            _idSecretario = 0;
            _idEmpleado = 0;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadSecretarios(int idSecretario, int idEmpleado, bool existe)
        {
            this._idSecretario = idSecretario;
            this._idEmpleado = idEmpleado;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdSecretario (int idSecretario) { this._idSecretario = idSecretario; }
        public void SetIdEmpleado (int idEmpleado) { this._idEmpleado = idEmpleado; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdSecretario() { return _idSecretario; }
        public int GetIdEmpleado() { return _idEmpleado; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadSecretarios
}//Fin namespace
