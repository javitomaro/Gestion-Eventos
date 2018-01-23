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
        #region VIEWMODEL
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
            FillUsuarios();
        }
        public void FillUsuarios()
        {
            Usuarios =  ctx.Usuario
                .Select(x => x).ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        public void LogIn()
        {



            //if (_selectedUsuario.IdRol==1)
            //{
            //    homeAdmin homeA = new homeAdmin();
            //    homeA.Show();
            //}
            //else if (SelectedUsuario.IdRol==2)
            //{
            //    homeLocal homeL = new homeLocal();
            //    homeL.Show();
            //}
        }

        public ICommand LogInCommand
        {
            get { return new RelayCommand(LogIn); }
        }

        private List<TipoEvento> _TipoEvento;


        public List<TipoEvento> TipoEventos
        {
            get
            {
                return _TipoEvento;
            }
            set
            {
                _TipoEvento = value;
                NotifyPropertyChanged();
            }
        }


        //#region DIALOGS
        //private ObservableCollection<IDialogViewModel> _Dialogs = new ObservableCollection<IDialogViewModel>();
        //public System.Collections.ObjectModel.ObservableCollection<IDialogViewModel> Dialogs { get { return _Dialogs; } }
        //public void LogIn()
        //{
        //    this.Dialogs.Add(new homeLocalViewModel{
        //        OnOk = (sender) => { sender.Close(); },
        //        OnCancel = (sender) => { sender.Close(); },
        //        OnCloseRequest = (sender) => { sender.Close(); },
        //        OnLogOut = (sender) => { sender.Close();  }
        //    });            
        //}

        //public ICommand LogInCommand
        //{
        //    get { return new RelayCommand(LogIn); }
        //}
        //#endregion


    }
}
