using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public abstract class EntidadPersona
    {
        //Atributos
        private string _numCedula;
        private string _nombre;
        private string _apellido01;
        private string _apellido02;
        private string _pais;
        private string _provincia;
        private string _sexo;
        private DateTime? _fNacimiento;
        private string _estadoCivil;
        private string _correoElectronico;
        private string _numTelefono;
        private string _estado;
        private bool _existe;

        //Constructor Vacio
        public EntidadPersona()
        {
            _numCedula = string.Empty;
            _nombre = string.Empty;
            _apellido01 = string.Empty;
            _apellido02 = string.Empty;
            _pais = string.Empty;
            _provincia = string.Empty;
            _sexo = string.Empty;
            _fNacimiento = Convert.ToDateTime("01/01/1900");
            _estadoCivil = string.Empty;
            _correoElectronico = string.Empty;
            _numTelefono = string.Empty;
            _estado = string.Empty;
            _existe = false;
        }

        //Constructor con parámetros
        public EntidadPersona(string numCedula, string nombre, string apellido01, string apellido02, string pais, string provincia, string sexo, DateTime? fNacimiento, string estadoCivil, string correoElectronico, string numTelefono, string estado, bool existe)
        {
            this._numCedula = numCedula;
            this._nombre = nombre;
            this._apellido01 = apellido01;
            this._apellido02 = apellido02;
            this._pais = pais;
            this._provincia = provincia;
            this._sexo = sexo;
            this._fNacimiento = fNacimiento;
            this._estadoCivil = estadoCivil;
            this._correoElectronico = correoElectronico;
            this._numTelefono = numTelefono;
            this._estado = estado;
            this._existe = existe;
        }

        //Métodos de acceso
        public string NumCedula { get => _numCedula; set => _numCedula = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido01 { get => _apellido01; set => _apellido01 = value; }
        public string Apellido02 { get => _apellido02; set => _apellido02 = value; }
        public string Pais { get => _pais; set => _pais = value; }
        public string Provincia { get => _provincia; set => _provincia = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public DateTime? FNacimiento { get => _fNacimiento; set => _fNacimiento = value; }
        public string EstadoCivil { get => _estadoCivil; set => _estadoCivil = value; }
        public string CorreoElectronico { get => _correoElectronico; set => _correoElectronico = value; }
        public string NumTelefono { get => _numTelefono; set => _numTelefono = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public bool Existe { get => _existe; set => _existe = value; }

        //Set
        public void SetNumCedula(string numCedula) { this._numCedula = numCedula; }
        public void SetNombre(string nombre) { this._nombre = nombre; }
        public void SetApellido01(string apellido01) { this._apellido01 = apellido01; }
        public void SetApellido02(string apellido02) { this._apellido02 = apellido02; }
        public void SetPais(string pais) { this._pais = pais; }
        public void SetProvincia(string provincia) { this._provincia = provincia; }
        public void SetSexo(string sexo) { this._sexo = sexo; }
        public void SetFechaNacimiento(DateTime? fNacimiento) { this._fNacimiento = fNacimiento; }
        public void SetEstadoCivil(string estadoCivil) { this._estadoCivil = estadoCivil; }
        public void SetCorreoElectronico(string correoElectronico) { this._correoElectronico = correoElectronico; }
        public void SetNumTelefono(string numTelefono) { this._numTelefono = numTelefono; }
        public void SetEstado(string estado) { this._estado = estado; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public string GetNumCedula() { return _numCedula; }
        public string GetNombre() { return _nombre; }
        public string GetApellido01() { return _apellido01; }
        public string GetApellido02() { return _apellido02; }
        public string GetPais() { return _pais; }
        public string GetProvincia() { return _provincia; }
        public string GetSexo() { return _sexo; }
        public DateTime? GetFNacimiento() { return _fNacimiento; }
        public string GetEstadoCivil() { return _estadoCivil; }
        public string GetCorreoElectronico() { return _correoElectronico; }
        public string GetNumTelefono() { return _numTelefono; }
        public string GetEstado() { return _estado; }
        public bool GetExiste() { return _existe; }


    }//Fin clase EntidadPersona
}//Fin namespace
