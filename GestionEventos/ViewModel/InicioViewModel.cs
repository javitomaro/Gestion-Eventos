using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
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
            SelectedUsuario = new Usuario();
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
            if (ctx.Usuarios.Select(x => x.Usuario1).ToList().Contains(SelectedUsuario.Usuario1) && SelectedUsuario.Usuario1 != null)
            {
                Usuario u = ctx.Usuarios.Where(x => x.Usuario1.Equals(SelectedUsuario.Usuario1)).FirstOrDefault();
                if (u.Password.Equals(SelectedUsuario.Password))
                {
                    if (u.IdRol.Equals(1))
                    {
                        homeAdmin ha = new homeAdmin();
                        ha.Show();
                    }
                    else if (u.IdRol.Equals(2))
                    {
                        //homeLocal hl = new homeLocal();
                        homeLocal hl = new homeLocal(){ DataContext = new homeLocalViewModel(u) };
                        hl.Show();
                    }
                    else {
                        MessageBox.Show("Este usuario no tiene permiso para usar la aplicacion desktop");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Password incorrecto");
                }
            }
            else
            {
                MessageBox.Show("Usuario incorrecto");
            }
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
