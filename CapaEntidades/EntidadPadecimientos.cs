using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadPadecimientos
    {
        //Atributos
        private int _idPadecimiento;
        private int _idExpediente;
        private string _nombre;
        private string _descripcion;
        private string _estado;
        private bool _existe;

        //Constructor Vacio
        public EntidadPadecimientos()
        {
            _idPadecimiento = 0;
            _idExpediente = 0;
            _nombre = string.Empty;
            _descripcion = string.Empty;
            _estado = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadPadecimientos(int idPadecimiento, int idExpediente, string nombre, string descripcion, string estado, bool existe)
        {
            this._idPadecimiento = idPadecimiento;
            this._idExpediente = idExpediente;
            this._nombre = nombre;
            this._descripcion = descripcion;
            this._estado = estado;
            this._existe = existe;
        }

        //Metodos de acceso
        //Set
        public void SetIdPadecimiento(int idPadecimiento) { this._idPadecimiento = idPadecimiento; }
        public void SetIdExpediente(int idExpediente) { this._idExpediente = idExpediente; }
        public void SetNombre(string nombre) { this._nombre = nombre; }
        public void SetDescripcion(string descripcion) { this._descripcion = descripcion; }
        public void SetEstado(string estado) { this._estado = estado; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdPadecimiento() { return _idPadecimiento; }
        public int GetIdExpediente() { return _idExpediente; }
        public string GetNombre() { return _nombre; }
        public string GetDescripcion() { return _descripcion; }
        public string GetEstado() { return _estado; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadPadecimientos
}//Fin namespace
