using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadAgendas
    {
        //Atributos
        private int _idAgenda;
        private int _idMedico;
        private string _dia;
        private DateTime? _hEntrada;
        private DateTime? _hSalida;
        private bool _existe;

        //Constructor vacio
        public EntidadAgendas()
        {
            _idAgenda = 0;
            _idMedico = 0;
            _dia = string.Empty;
            _hEntrada = Convert.ToDateTime("01/01/1900"); ;
            _hSalida = Convert.ToDateTime("01/01/1900"); ;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadAgendas(int idAgenda, int idMedico, string dia, DateTime? hEntrada, DateTime? hSalida, bool existe)
        {
            this._idAgenda = idAgenda;
            this._idMedico = idMedico;
            this._dia = dia;
            this._hEntrada = hEntrada;
            this._hSalida = hSalida;
            this._existe = existe;
        }

        //Metodos de acceso
        //Set
        public void SetIdAgenda(int idAgenda) { this._idAgenda = idAgenda; }
        public void SetIdMedico(int idMedico) { this._idMedico = idMedico; }
        public void SetDia(string dia) { this._dia = dia; }
        public void SetHEntrada(DateTime? hEntrada) { this._hEntrada = hEntrada; }
        public void SetHSalida(DateTime? hSalida) { this._hSalida = hSalida; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdAgenda() { return _idAgenda; }
        public int GetIdMedico() { return _idMedico; }
        public string GetDia() { return _dia; }
        public DateTime? GetHEntrada() { return _hEntrada; }
        public DateTime? GetHSalida() { return _hSalida; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadAgendas
}//Fin namespace
