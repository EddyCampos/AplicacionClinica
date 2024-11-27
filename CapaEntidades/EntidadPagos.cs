using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadPagos
    {
        //Atributos
        private int _idPago;
        private int _idPaciente;
        private decimal _monto;
        private string _metodoPago;
        private string _estado;
        private bool _existe;

        //Constructor Vacio
        public EntidadPagos()
        {
            _idPago = 0;
            _idPaciente = 0;
            _monto = 0;
            _metodoPago = string.Empty;
            _estado = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadPagos(int idPago, int idPaciente, decimal monto, string metodoPago, string estado, bool existe)
        {
            this._idPago = idPago;
            this._idPaciente = idPaciente;
            this._monto = monto;
            this._metodoPago = metodoPago;
            this._estado = estado;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdPago(int idPago) { this._idPago = idPago; }
        public void SetIdPaciente(int idPaciente) { this._idPaciente = idPaciente; }
        public void SetMonto(decimal monto) { this._monto = monto; }
        public void SetMetodoPago(string metodoPago) { this._metodoPago = metodoPago; }
        public void SetEstado(string estado) { this._estado = estado; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdPago() { return _idPago; }
        public int GetIdPaciente() { return _idPaciente; }
        public decimal GetMonto() { return _monto; }
        public string GetMetodoPago() { return _metodoPago; }
        public string GetEstado() { return _estado; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadPagos
}//Fin namespace
