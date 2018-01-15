using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using GestionEventos.Model;
using System.Threading.Tasks;

namespace GestionEventos.ViewModel
{
    class InicioViewModel : INotifyPropertyChanged
    {
        gestioneventosEntities ctx = new gestioneventosEntities();
        private List<evento> _eventos;
        private List<local> _locales;
        private List<cliente> _clientes;
        private List<direccion> _direcciones;
        private List<estilo> _estilos;
        private List<flyer> _flyer;
        private List<listaevento> _listaeventos;
        private List<listafavorito> _listafavoritos;
        private List<tipoevento> _tipoeventos;
        private List<tipolocal> _tipolocales;        
        private evento _selectedEvento;
        private local _selectedLocal;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
