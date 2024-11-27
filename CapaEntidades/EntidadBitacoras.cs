using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadBitacoras
    {
        //Atributos
        private int _idBitacora;
        private string _accion;
        private DateTime? _dia;
        private bool _existe;

        //Constructor vacio
        public EntidadBitacoras()
        {
            _idBitacora = 0;
            _accion = string.Empty;
            _dia = Convert.ToDateTime("01/01/1900");
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadBitacoras(int idBitacora, string accion, DateTime? dia, bool existe)
        {
            this._idBitacora = idBitacora;
            this._accion = accion;
            this._dia = dia;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdBitacora(int idBitacora) { this._idBitacora = idBitacora; }
        public void SetAccion(string accion) { this._accion = accion; }
        public void SetDia(DateTime? dia) { this._dia = dia; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdBitacora() { return _idBitacora; }
        public string GetAccion() { return _accion; }
        public DateTime? GetDia() { return _dia; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadBitacoras
}//Fin namespace
