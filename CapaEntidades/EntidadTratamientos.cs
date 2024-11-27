using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadTratamientos
    {
        //Atributos
        private int _idTratamiento;
        private int _idPadecimiento;
        private string _nombre;
        private string _dosis;
        private string _duracion;
        private string _estado;
        private bool _existe;

        //Constructor Vacio
        public EntidadTratamientos()
        {
            _idTratamiento = 0;
            _idPadecimiento = 0;
            _nombre = string.Empty;
            _dosis = string.Empty;
            _duracion = string.Empty;
            _estado = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadTratamientos(int idTratamiento, int idPadecimiento, string nombre, string dosis, string duracion, string estado, bool existe)
        {
            this._idTratamiento = idTratamiento;
            this._idPadecimiento = idPadecimiento;
            this._nombre = nombre;
            this._dosis = dosis;
            this._duracion = duracion;
            this._estado = estado;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdTratamiento(int idTratamiento) { this._idTratamiento = idTratamiento; }
        public void SetIdPadecimiento(int idPadecimiento) { this._idPadecimiento = idPadecimiento; }
        public void SetNombre(string nombre) { this._nombre = nombre; }
        public void SetDosis(string dosis) { this._dosis = dosis; }
        public void SetDuracion(string duracion) { this._duracion = duracion; }
        public void SetEstado(string estado) { this._estado = estado; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdTratamiento() { return _idTratamiento; }
        public int GetIdPadecimiento() { return _idPadecimiento; }
        public string GetNombre() { return _nombre; }
        public string GetDosis() { return _dosis; }
        public string GetDuracion() { return _duracion; }
        public string GetEstado() { return _estado; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadTratamientos
}//Fin namespace
