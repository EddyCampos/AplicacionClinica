using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadExpedientes
    {
        //Atributos
        private int _idExpediente;
        private int _idPaciente;
        private DateTime? _fCreacion;
        private bool _existe;

        //Constructor vacio
        public EntidadExpedientes()
        {
            _idExpediente = 0;
            _idPaciente = 0;
            _fCreacion = Convert.ToDateTime("01/01/1900");
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadExpedientes(int idExpediente, int idPaciente, DateTime? fCreacion, bool existe)
        {
            this._idExpediente = idExpediente;
            this._idPaciente = idPaciente;
            this._fCreacion = fCreacion;
            this._existe = existe;
        }

        //Metodos de acceso
        //Set
        public void SetIdExpediente(int idExpediente) { this._idExpediente = idExpediente; }
        public void SetIdPaciente(int idPaciente) { this._idPaciente = idPaciente; }
        public void SetFCreacion(DateTime? fCreacion) { this._fCreacion = fCreacion; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdExpediente() => _idExpediente;
        public int GetIdPaciente() => _idPaciente;
        public DateTime? GetFCreacion() => _fCreacion;
        public bool GetExiste() => _existe;

    }//Fin clase EntidadExpediente
}//Fin namespace
