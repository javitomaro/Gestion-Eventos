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
        #region User
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
        #endregion
        #region Local
        public ICommand AddLocalCommand { get { return new RelayCommand(AddLocal); } }
        private void AddLocal()
        {
            Local local_aux = new Local();
            this.Dialogs.Add(new crudLocalViewModel()
            {
                Titol = "Añadir un Evento",
                OkText = "Añadir",
                TextEnabled = true,
                Local = local_aux,
                OnOk = (sender) =>
                {
                    try
                    {

                        sender.Close();                                          
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.StackTrace);
                    }
                },

                OnCancel = (sender) => { sender.Close(); },
            });
        }
        #endregion
        #region Evento
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
        public ICommand AddEventCommand { get { return new RelayCommand(AddEvent); } }
        private void AddEvent()
        {
            Evento evento_aux = new Evento();
            Flyer flyer_aux = new Flyer();
            Direccion direccion_aux = new Direccion();
            Direccion nuevaDir_aux = new Direccion();
            Local local_aux = SelectedLocal;
            evento_aux.IdLocal = SelectedLocal.Id;
            bool correcto = false;
            this.Dialogs.Add(new crudEventoViewModel()
            {
                Title = "Añadir un Evento",
                evento = evento_aux,
                flyer = flyer_aux,
                local = local_aux,
                selectedDireccion = direccion_aux,
                direccion = direccion_aux,
                NuevaDireccion = nuevaDir_aux,
                OkText = "Añadir",
                TextEnabled = true,
                OnOk = (sender) =>
                {
                    try
                    {
                        if (nuevaDir_aux.Población != null && nuevaDir_aux.Calle != null && nuevaDir_aux.CodigoPostal != null)
                        {
                            ctx.Direccions.Add(nuevaDir_aux);
                            ctx.SaveChanges();
                            evento_aux.IdDireccion = nuevaDir_aux.Id;
                            correcto = true;
                        }
                        else if (direccion_aux != null)
                        {
                            evento_aux.IdDireccion = direccion_aux.Id;
                            correcto = true;
                        }
                        else
                        {
                            MessageBox.Show("Direccion erronea");
                            correcto = false;
                        }

                        if (correcto)
                        {
                            evento_aux.IdLocal = local_aux.Id;
                            ctx.Eventoes.Add(evento_aux);
                            ctx.SaveChanges();
                            CargarEventos(SelectedLocal.Id);
                            sender.Close();
                        }
                        //flyer_aux.IdEvento = evento_aux.Id;
                        //ctx.Flyers.Add(flyer_aux);
                        //ctx.SaveChanges();                                           
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.StackTrace);
                    }
                },

                OnCancel = (sender) => { sender.Close(); },
            });
        }

        public ICommand EditEventCommand { get { return new RelayCommand(EditEvent); } }
        private void EditEvent()

        {
            if (SelectedEvento != null)
            {
                Local local_aux = SelectedLocal;
                //Flyer flyer_aux = new Flyer();
                Evento evento_aux = SelectedEvento;
                evento_aux.Id = SelectedEvento.Id;
                evento_aux.Descripcion = SelectedEvento.Descripcion;
                evento_aux.Aforo = SelectedEvento.Aforo;
                evento_aux.TipoEvento = SelectedEvento.TipoEvento;
                evento_aux.Estilo = SelectedEvento.Estilo;                
                evento_aux.Direccion = SelectedEvento.Direccion;
                //Flyer axFlyer = ctx.Flyers.Where(x => x.IdEvento == SelectedEvento.Id).FirstOrDefault();
                //String seletedFlyer = axFlyer.Flyer1;
                evento_aux.Fecha = SelectedEvento.Fecha;
                evento_aux.Local = SelectedEvento.Local;
                String title = "Editar Evento";
                this.Dialogs.Add(new crudEventoViewModel(title, evento_aux)
                {
                    //selectedFlyer = seletedFlyer,
                    evento = evento_aux,
                    //flyer = flyer_aux,
                    OkText = "Guardar",
                    Title = title,
                    TextEnabled = true,
                    OnOk = (sender) =>
                    {
                        try
                        {
                            ctx.SaveChanges();
                            //flyer_aux.IdEvento = evento_aux.Id;
                            //ctx.Flyers.Add(flyer_aux);

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        sender.Close();
                    },
                    OnCancel = (sender) => { sender.Close(); },
                });
            }
        }
        #endregion
    }
}
