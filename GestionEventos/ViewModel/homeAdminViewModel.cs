using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEventos.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using MvvmDialogs.ViewModels;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace GestionEventos.ViewModel
{
    class homeAdminViewModel : INotifyPropertyChanged
    {
        eventosEntities ctx = new eventosEntities();
        private List<Usuario> _usuarios;
        private List<Local> _locales;
        private List<Cliente> _clientes;
        private Usuario _selectedUsuario;
        private Local _selectedLocal;
        private Cliente _selectedCliente;

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
        public List<Cliente> Clientes
        {
            get
            {
                return _clientes;
            }
            set
            {
                _clientes = value;
                NotifyPropertyChanged();
            }
        }
        public Usuario SelectedUser
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
        public Local SelectedLocal
        {
            get
            {
                return _selectedLocal;
            }
            set
            {
                _selectedLocal = value;
                NotifyPropertyChanged();
            }
        }
        public Cliente SelectedCliente
        {
            get
            {
                return _selectedCliente;
            }
            set
            {
                _selectedCliente = value;
                NotifyPropertyChanged();
            }
        }

        public homeAdminViewModel()
        {
            CargarUsuarios();
        }
        public void CargarUsuarios()
        {
            Usuarios = ctx.Usuarios.ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<IDialogViewModel> _Dialogs = new ObservableCollection<IDialogViewModel>();
        public System.Collections.ObjectModel.ObservableCollection<IDialogViewModel> Dialogs { get { return _Dialogs; } }


        public ICommand AddCommand
        {
            get { return new RelayCommand(Add); }
        }

        public void Add()
        {
            Usuario user_aux = new Usuario();
            user_aux.Id = ((int)ctx.Usuarios.Select(x => x.Id).Max())+1;
            this.Dialogs.Add(new crudUsersViewModel
            {
                Titol = "Añadir Usuario",
                Usuario = user_aux,
                OkText = "Añadir",
                TextEnabled = true,
                OnOk = (sender) =>
                {
                    try
                    {
                        if (ctx.Usuarios.Where(x => x.Usuario1.Equals(user_aux.Usuario1)).Count() > 0)
                        {
                            MessageBox.Show("Aquest nom d'usuari ja existeix posa un altre");
                        }
                        else
                        {
                            ctx.Usuarios.Add(user_aux);
                            ctx.SaveChanges();
                            sender.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("El password o el rol son incorrectes");
                    }
                },
                OnCancel = (sender) => { sender.Close(); },
                OnCloseRequest = (sender) => { sender.Close(); }
            });
            CargarUsuarios();
        }


        public ICommand UpdCommand
        {
            get { return new RelayCommand(Upd); }
        }

        public void Upd()
        {
            if (SelectedUser != null)
            {
                Usuario user_aux = new Usuario();
                user_aux = SelectedUser;
                this.Dialogs.Add(new crudUsersViewModel
                {
                    Titol = "Modificar Usuario",
                    Usuario = user_aux,
                    OkText = "Modificar",
                    TextEnabled = true,
                    OnOk = (sender) =>
                    {
                        SelectedUser = user_aux;
                        try
                        {
                            ctx.SaveChanges();
                            CargarUsuarios();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        sender.Close();
                    },
                    OnCancel = (sender) => { sender.Close(); },
                    OnCloseRequest = (sender) => { sender.Close(); }
                });
            }
            //}
            #region CRUD LOCAL
            //public ICommand AddLocalCommand
            //{
            //    get { return new RelayCommand(AddLocal); }
            //}

            //public void AddLocal()
            //{
            //    Local local_aux = new Local();
            //    this.Dialogs.Add(new crudLocalViewModel
            //    {
            //        Titol = "Añadir Local",
            //        Local = local_aux,
            //        OkText = "Añadir",
            //        TextEnabled = true,
            //        SelectedUsuario = ctx.Usuarios.Where(x => x.Id == local_aux.IdUsuario).Select(x=> x).SingleOrDefault(),
            //        OnOk = (sender) =>
            //        {
            //            ctx.Locals.Add(local_aux);
            //            try
            //            {
            //                ctx.SaveChanges();
            //                CargarLocales();
            //            }
            //            catch (Exception e)
            //            {
            //                MessageBox.Show(e.ToString());
            //            }
            //            sender.Close();
            //        },
            //        OnCancel = (sender) => { sender.Close(); },
            //        OnCloseRequest = (sender) => { sender.Close(); }
            //    });
            //}

            //public ICommand UpdLocalCommand
            //{
            //    get { return new RelayCommand(UpdLocal); }
            //}

            //public void UpdLocal()
            //{
            //    if (SelectedLocal != null)
            //    {
            //        Local local_aux = new Local();
            //        local_aux = SelectedLocal;
            //        this.Dialogs.Add(new crudLocalViewModel
            //        {
            //            Titol = "Modificar Local",
            //            Local = local_aux,
            //            OkText = "Modificar",
            //            TextEnabled = true,
            //            OnOk = (sender) =>
            //            {
            //                SelectedLocal = local_aux;
            //                try
            //                {
            //                    ctx.SaveChanges();
            //                    CargarLocales();
            //                }
            //                catch (Exception e)
            //                {
            //                    MessageBox.Show(e.ToString());
            //                }
            //                sender.Close();
            //            },
            //            OnCancel = (sender) => { sender.Close(); },
            //            OnCloseRequest = (sender) => { sender.Close(); }
            //        });
            //    }
            //}

            //public ICommand DelLocalCommand
            //{
            //    get { return new RelayCommand(DelLocal); }
            //}

            //public void DelLocal()
            //{
            //    if (SelectedLocal != null)
            //    {
            //        Local local_aux = new Local();
            //        local_aux = SelectedLocal;
            //        this.Dialogs.Add(new crudLocalViewModel
            //        {
            //            Titol = "Borrar Local",
            //            Local = local_aux,
            //            OkText = "Borrar",
            //            TextEnabled = false,
            //            OnOk = (sender) =>
            //            {
            //                try
            //                {
            //                    ctx.Locals.Remove(SelectedLocal);
            //                    ctx.SaveChanges();
            //                    CargarLocales();
            //                }
            //                catch (Exception e) { MessageBox.Show(e.ToString()); }

            //                sender.Close();
            //            },
            //            OnCancel = (sender) => { sender.Close(); },
            //            OnCloseRequest = (sender) => { sender.Close(); }
            //        });
            //    }
            //}
            #endregion
        }
    }
}

