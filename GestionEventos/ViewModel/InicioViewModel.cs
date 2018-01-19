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
using GestionEventos.Model;
using GestionEventos.View;
using System.Windows;

namespace GestionEventos.ViewModel
{
    class InicioViewModel : INotifyPropertyChanged
    {
        eventosEntities ctx = new eventosEntities();
        private List<Rol> _roles;
        private List<Usuario> _usuarios;
        private Rol _selectedRol;
        private Usuario _selectedUsuario;

        public List<Rol> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
                NotifyPropertyChanged();
            }
        }
        public List<Usuario> Usuarios
        {
            get
            {
                return _usuarios;            
            }
            set
            {
                _usuarios = value;
                NotifyPropertyChanged();
            }
        }
        public Rol SelectedRol
        {
            get
            {
                return _selectedRol;
            }
            set
            {
                _selectedRol = value;
                NotifyPropertyChanged();
            }
        }
        public Usuario SelectedUsuario
        {
            get
            {
                return _selectedUsuario;
            }
            set
            {
                _selectedUsuario = value;        
                NotifyPropertyChanged();
            }
        }
      
        public InicioViewModel()
        {

        }

        //private ObservableCollection<IDialogViewModel> _Dialogs = new ObservableCollection<IDialogViewModel>();
        //public System.Collections.ObjectModel.ObservableCollection<IDialogViewModel> Dialogs { get { return _Dialogs; } }
        //public void LogIn()
        //{
        //    this.Dialogs.Add(new homeLocalViewModel
        //    {
        //        Title = "Afegir Contacte",
        //        OkText = "Ok",
        //        TextEnabled = true,
        //        OnOk = (sender) => { sender.Close(); },
        //        OnCancel = (sender) => { sender.Close(); },
        //        OnCloseRequest = (sender) => { sender.Close(); }
        //    });
        //}

        public ICommand LogInCommand
        {
            get { return new RelayCommand(LogIn); }
        }
        public void LogIn()
        {
            homeLocal hl = new homeLocal();
            
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
