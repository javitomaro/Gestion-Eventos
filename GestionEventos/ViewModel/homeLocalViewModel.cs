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
        //public homeLocalViewModel(Usuario u)
        //{
        //    ActualUsuario = u;

        //}       
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
        public ObservableCollection<object> ViewList { get; set; } = new ObservableCollection<object>();
        public void CargarEventos(int id)
        {

            Eventos = ctx.Eventoes.Where(x => x.IdLocal == id).Select(x => x).ToList();            
        }

        #region DIALOG
        //#region PRUEBA DIALOGO
        //public virtual bool IsModal { get { return true; } }
        //public virtual void RequestClose() { this.DialogClosing(this, null); }
        //public virtual event EventHandler DialogClosing;

        //public ICommand OkCommand { get { return new RelayCommand(Ok); } }
        //protected virtual void Ok()
        //{
        //    if (this.OnOk != null)
        //        this.OnOk(this);
        //    else
        //        Close();
        //}

        //public ICommand CancelCommand { get { return new RelayCommand(Cancel); } }
        //protected virtual void Cancel()
        //{
        //    if (this.OnCancel != null)
        //        this.OnCancel(this);
        //    else
        //        Close();
        //}

        //public void Close()
        //{
        //    if (this.DialogClosing != null)
        //        this.DialogClosing(this, new EventArgs());
        ////}
        //public ICommand LogOutCommand { get { return new RelayCommand(LogOut); } }
        //protected virtual void LogOut()
        //{
        //    if (this.OnLogOut != null)
        //        this.OnLogOut(this);
        //    Close();
        //}
        //

        //public Action<homeLocalViewModel> OnOk { get; set; }
        //public Action<homeLocalViewModel> OnCancel { get; set; }
        //public Action<homeLocalViewModel> OnCloseRequest { get; set; }
        //public Action<homeLocalViewModel> OnLogOut { get; set; }
        //private ObservableCollection<IDialogViewModel> _Dialogs = new ObservableCollection<IDialogViewModel>();
        // public System.Collections.ObjectModel.ObservableCollection<IDialogViewModel> Dialogs { get { return _Dialogs; } }
        //#endregion
        //#region Añadir Evento

        //public ICommand addEventCommand { get { return new RelayCommand(addEvent); } }
        //  private void addEvent()
        //{
        //     this.Dialogs.Add(new crudEventoViewModel()
        //   {


        //     });   
        // }
        #endregion
    }
}
