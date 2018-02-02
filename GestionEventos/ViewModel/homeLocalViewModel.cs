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
using System.Collections.ObjectModel;
using MvvmDialogs.ViewModels;

namespace GestionEventos.ViewModel
{
    class homeLocalViewModel : INotifyPropertyChanged
    {
        eventosEntities ctx = new eventosEntities();
        private List<Evento> _eventos;
        private Evento _selectedEvento;
        private List<Local> _locales;
        private Local _selectedLocal;
        private Usuario _actualUsuario;

        public homeLocalViewModel()
        {
            CargarLocales(4);
        }
        public homeLocalViewModel(Usuario u)
        {
            ActualUsuario = u;

        }
        public List<Evento> Eventos
        {
            get
            {
                return _eventos;
            }
            set
            {
                _eventos = value;
                NotifyPropertyChanged();
            }
        }
        public Evento SelectedEvento
        {
            get
            {
                return _selectedEvento;
            }
            set
            {
                _selectedEvento = value;
                NotifyPropertyChanged();
                //RaisePropertyChanged("SelectedEvento");
            }
        }

        public List<Local> Locales
        {
            get
            {
                return _locales;
            }
            set
            {
                _locales = value;
                NotifyPropertyChanged();
            }
        }
        public Local SelectedLocal
        {
            get
            {
                return _selectedLocal;
            }
            set
            {
                _selectedLocal = value;
                CargarEventos(value.Id);

                NotifyPropertyChanged();
            }
        }
        public Usuario ActualUsuario
        {
            get
            {
                return _actualUsuario;
            }
            set
            {
                _actualUsuario = value;
                CargarLocales(value.Id);
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public void CargarLocales(int id)
        {
            Locales = ctx.Locals.Where(x => x.IdUsuario == id).Select(x => x).ToList();
        }
        public class View
        {
            public string Name { get; set; } = "";
        }
        private ObservableCollection<IDialogViewModel> _Dialogs = new ObservableCollection<IDialogViewModel>();
        public System.Collections.ObjectModel.ObservableCollection<IDialogViewModel> Dialogs { get { return _Dialogs; } }
        public ObservableCollection<object> ViewList { get; set; } = new ObservableCollection<object>();
        public void CargarEventos(int id)
        {

            Eventos = ctx.Eventoes.Where(x => x.IdLocal == id).Select(x => x).ToList();
        }

        public ICommand EditUserCommand { get { return new RelayCommand(EditUser); } }
        private void EditUser()
        {
            if (ActualUsuario != null)
            {
                Usuario user_aux = new Usuario();
                user_aux = ActualUsuario;
                string nombre = ActualUsuario.Usuario1;
                this.Dialogs.Add(new crudUsersViewModel
                {
                    Titol = "Modificar Usuari",
                    Usuario = user_aux,
                    OkText = "Modificar",
                    TextEnabled = true,
                    RolEnabled = false,
                    OnOk = (sender) =>
                    {
                        try
                        {
                            if (ctx.Usuarios.Where(x => x.Usuario1.Equals(user_aux.Usuario1)).Count() > 0 && !user_aux.Usuario1.Equals(nombre))
                            {
                                MessageBox.Show("Aquest nom d'usuari ja existeix posa un altre");
                            }
                            else if (user_aux.Password.Equals(""))
                            {
                                MessageBox.Show("Password incorrecte");
                            }
                            else
                            {
                                ctx.SaveChanges();
                                sender.Close();
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.StackTrace);
                        }
                    },
                    OnCancel = (sender) => { sender.Close(); },
                    OnCloseRequest = (sender) => { sender.Close(); }
                });
            }
        }
        public ICommand VerEventoCommand { get { return new RelayCommand(VerEvento); } }
        private void VerEvento()
        {
            if (SelectedEvento != null)
            {
                this.Dialogs.Add(new DetalleEventoViewModel
                {
                    eventoguay = SelectedEvento,               
                    OnOk = (sender) => { sender.Close(); },
                    OnCancel = (sender) => { sender.Close(); },
                    OnCloseRequest = (sender) => { sender.Close(); }
                });
            }
        }
    }
}
