using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
//using GestionEventos.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MvvmDialogs.ViewModels;
using GalaSoft.MvvmLight.Command;
using GestionEventos.ViewModel;

namespace GestionEventos.ViewModel
{
    class InicioViewModel : INotifyPropertyChanged
    {
        //gestioneventosEntities ctx = new gestioneventosEntities();
        //private List<evento> _eventos;
        //private List<local> _locales;
        //private List<cliente> _clientes;
        //private List<direccion> _direcciones;
        //private List<estilo> _estilos;
        //private List<flyer> _flyer;
        //private List<listaevento> _listaeventos;
        //private List<listafavorito> _listafavoritos;
        //private List<tipoevento> _tipoeventos;
        //private List<tipolocal> _tipolocales;        
        //private evento _selectedEvento;
        //private local _selectedLocal;

        private ObservableCollection<IDialogViewModel> _Dialogs = new ObservableCollection<IDialogViewModel>();
        public System.Collections.ObjectModel.ObservableCollection<IDialogViewModel> Dialogs { get { return _Dialogs; } }
        
        public ICommand LogInCommand
        {
            get { return new RelayCommand(LogIn); }
        }
        public void LogIn()
        {
            this.Dialogs.Add(new homeLocalViewModel
            {
                Title = "Afegir Contacte",                
                OkText = "Ok",
                TextEnabled = true,
                OnOk = (sender) => { sender.Close(); },

                OnCancel = (sender) => { sender.Close(); },
                OnCloseRequest = (sender) => { sender.Close(); }
            });
        }
        
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
