using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadConsultorios
    {
        //Atributos
        private int _idConsultorio;
        private int _idConsulta;
        private int _pabellon;
        private string _area;
        private string _estado;
        private bool _existe;

        //Constructor Vacio
        public EntidadConsultorios()
        {
            _idConsultorio = 0;
            _idConsulta = 0;
            _pabellon = 0;
            _area = string.Empty;
            _estado = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadConsultorios(int idConsultorio, int idConsulta, int pabellon, string area, string estado, bool existe)
        {
            this._idConsultorio = idConsultorio;
            this._idConsulta = idConsulta;
            this._pabellon = pabellon;
            this._area = area;
            this._estado = estado;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdConsultorio(int idConsultorio) { this._idConsultorio = idConsultorio; }
        public void SetIdConsulta(int idConsulta) { this._idConsulta = idConsulta; }
        public void SetPabellon(int pabellon) { this._pabellon = pabellon; }
        public void SetArea(string area) { this._area = area; }
        public void SetEstado(string estado) { this._estado = estado; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdConsultorio() { return _idConsultorio; }
        public int GetIdConsulta() { return _idConsulta; }
        public int GetPabellon() { return _pabellon; }
        public string GetArea() { return _area; }
        public string GetEstado() { return _estado; }
        public bool GetExiste() { return _existe; }

    }//Fin clase EntidadConsultorios
}//Fin namespace
