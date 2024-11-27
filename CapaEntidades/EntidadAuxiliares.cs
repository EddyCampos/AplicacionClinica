using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadAuxiliares
    {
        //Atributos
        private int _idAuxiliar;
        private int _idEmpleado;
        private string _area;
        private bool _existe;

        //Constructor vacio
        public EntidadAuxiliares()
        {
            _idAuxiliar = 0;
            _idEmpleado = 0;
            _area = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadAuxiliares(int idAuxiliar, int idEmpleado, string area, bool existe)
        {
            this._idAuxiliar = idAuxiliar;
            this._idEmpleado = idEmpleado;
            this._area = area;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdAuxiliar(int idAuxiliar) { this._idAuxiliar = idAuxiliar; }
        public void SetIdEmpleado(int idEmpleado) { this._idEmpleado = idEmpleado; }
        public void SetArea(string area) { this._area = area; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdAuxiliar() { return _idAuxiliar; }
        public int GetIdEmpleado() { return _idEmpleado; }
        public string GetArea() { return _area; }
        public bool GetExiste() { return _existe; }

    }//Fin clase EntidadAuxiliares
}//Fin namespace
