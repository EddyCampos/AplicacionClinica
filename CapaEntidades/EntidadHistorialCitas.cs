using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades
{
    public class EntidadHistorialCitas
    {
        //Atributos
        private int _idHistorialCita;
        private int _idExpediente;
        private DateTime? _fecha;
        private DateTime? _hora;
        private int _idMedicoResponsable;
        private string _motivo;
        private bool _existe;

        //Constructor Vacio
        public EntidadHistorialCitas()
        {
            _idHistorialCita = 0;
            _idExpediente = 0;
            _fecha = Convert.ToDateTime("01/01/1900");
            _hora = Convert.ToDateTime("01/01/1900");
            _idMedicoResponsable = 0;
            _motivo = string.Empty;
            _existe = false;
        }

        //Constructor con Parámetros
        public EntidadHistorialCitas(int idHistorialCita, int idExpediente, DateTime? fecha, DateTime? hora, int idMedicoResponsable, string motivo, bool existe)
        {
            this._idHistorialCita = idHistorialCita;
            this._idExpediente = idExpediente;
            this._fecha = fecha;
            this._hora = hora;
            this._idMedicoResponsable = idMedicoResponsable;
            this._motivo = motivo;
            this._existe = existe;
        }

        //Métodos de acceso
        //Set
        public void SetIdHistorialCita(int idHistorialCita) { this._idHistorialCita = idHistorialCita; }
        public void SetIdExpediente(int idExpediente) { this._idExpediente = idExpediente; }
        public void SetFecha(DateTime? fecha) { this._fecha = fecha; }
        public void SetHora(DateTime? hora) { this._hora = hora; }
        public void SetIdMedicoResponsable(int idMedicoResponsable) { this._idMedicoResponsable = idMedicoResponsable; }
        public void SetMotivo(string motivo) { this._motivo = motivo; }
        public void SetExiste(bool existe) { this._existe = existe; }

        //Get
        public int GetIdHistorialCita() { return _idHistorialCita; }
        public int GetIdExpediente() { return _idExpediente; }
        public DateTime? GetFecha() { return _fecha; }
        public DateTime? GetHora() { return _hora; }
        public int GetIdMedicoResponsable() { return _idMedicoResponsable; }
        public string GetMotivo() { return _motivo; }
        public bool GetExiste() { return _existe; }


    }//Fin EntidadHistorialCitas
}//Fin namespace
