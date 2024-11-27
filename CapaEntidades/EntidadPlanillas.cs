using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadPlanillas
    {
        //Atributos
        private int _idPlanilla;
        private int _idEmpleado;
        private decimal _salarioBruto;
        private decimal _extras;
        private decimal _deducciones;
        private decimal _salarioTotal;
        private bool _existe;

        //Constructor Vacio
        public EntidadPlanillas()
        {
            _idPlanilla = 0;
            _idEmpleado = 0;
            _salarioBruto = 0;
            _extras = 0;
            _deducciones = 0;
            _salarioTotal = 0;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadPlanillas(int idPlanilla, int idEmpleado, decimal salarioBruto, decimal extras, decimal deducciones, decimal salarioTotal, bool existe)
        {
            this._idPlanilla = idPlanilla;
            this._idEmpleado = idEmpleado;
            this._salarioBruto = salarioBruto;
            this._extras = extras;
            this._deducciones = deducciones;
            this._salarioTotal = salarioTotal;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdPlanilla(int idPlanilla) { this._idPlanilla = idPlanilla; }
        public void SetIdEmpleado(int idEmpleado) { this._idEmpleado = idEmpleado; }
        public void SetSalarioBruto(decimal salarioBruto) { this._salarioBruto = salarioBruto; }
        public void SetExtras(decimal extras) { this._extras = extras; }
        public void SetDeducciones(decimal deducciones) { this._deducciones = deducciones; }
        public void SetSalarioTotal(decimal salarioTotal) { this._salarioTotal = salarioTotal; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdPlanilla() { return _idPlanilla; }
        public int GetIdEmpleado() { return _idEmpleado; }
        public decimal GetSalarioBruto() { return _salarioBruto; }
        public decimal GetExtras() { return _extras; }
        public decimal GetDeducciones() { return _deducciones; }
        public decimal GetSalarioTotal() { return _salarioTotal; }
        public bool GetExiste() { return _existe; }

    }//Fin clase EntidadPlanillas
}//Fin namespace
