using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadMedicos
    {
        //Atributos
        private int _idMedico;
        private int _idEmpleado;
        private string _especialidad;
        private string _numCertificacion;
        private bool _existe;

        //Constructor Vacio
        public EntidadMedicos()
        {
            _idMedico = 0;
            _idEmpleado = 0;
            _especialidad = string.Empty;
            _numCertificacion = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadMedicos(int idMedico, int idEmpleado, string especialidad, string numCertificacion, bool existe)
        {
            this._idMedico = idMedico;
            this._idEmpleado = idEmpleado;
            this._especialidad = especialidad;
            this._numCertificacion = numCertificacion;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdMedico(int idMedico) { this._idMedico = idMedico; }
        public void SetIdEmpleado(int idEmpleado) { this._idEmpleado = idEmpleado; }
        public void SetEspecialidad(string especialidad) { this._especialidad = especialidad; }
        public void SetNumCertificacion(string numCertificacion) { this._numCertificacion = numCertificacion; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdMedico() { return _idMedico; }
        public int GetIdEmpleado() { return _idEmpleado; }
        public string GetEspecialidad() { return _especialidad; }
        public string GetNumCertificacion() { return _numCertificacion; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadMedicos
}//Fin namespace
