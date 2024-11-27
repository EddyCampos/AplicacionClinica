using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadConsultas
    {
        //Atributos
        private int _idConsulta;
        private int _idMedico;
        private int _idPaciente;
        private DateTime? _dia;
        private DateTime? _hora;
        private string _motivo;
        private bool _existe;

        //Constructor vacio
        public EntidadConsultas()
        {
            _idConsulta = 0;
            _idMedico = 0;
            _idPaciente = 0;
            _dia = Convert.ToDateTime("01/01/1900");
            _hora = Convert.ToDateTime("01/01/1900");
            _motivo = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadConsultas(int idConsulta, int idMedico, int idPaciente, DateTime? dia, DateTime? hora, string motivo, bool existe)
        {
            this._idConsulta = idConsulta;
            this._idMedico = idMedico;
            this._idPaciente = idPaciente;
            this._dia = dia;
            this._hora = hora;
            this._motivo = motivo;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdConsulta(int idConsulta) { this._idConsulta = idConsulta; }
        public void SetIdMedico(int idMedico) { this._idMedico = idMedico; }
        public void SetIdPaciente(int idPaciente) { this._idPaciente = idPaciente; }
        public void SetDia(DateTime? dia) { this._dia = dia; }
        public void SetHora(DateTime? hora) { this._hora = hora; }
        public void SetMotivo(string motivo) { this._motivo = motivo; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdConsulta() { return _idConsulta; }
        public int GetIdMedico() { return _idMedico; }
        public int GetIdPaciente() { return _idPaciente; }
        public DateTime? GetDia() { return _dia; }
        public DateTime? GetHora() { return _hora; }
        public string GetMotivo() { return _motivo; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadConsultas
}//Fin namespace
