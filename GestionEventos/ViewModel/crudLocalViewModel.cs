using GalaSoft.MvvmLight.Command;
using MvvmDialogs.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GestionEventos.Model;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestionEventos.ViewModel
{
    class crudLocalViewModel : IUserDialogViewModel, INotifyPropertyChanged
    {
        eventosEntities ctx = new eventosEntities();
        private string _titol;
        private string _okText;
        private bool _textEnabled;
        private Local _local;
        private List<TipoLocal> _tipoLocal;
        private List<string> _poblaciones;
        private Usuario _selectedUsuario;
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
        public string Titol {
            get
            {
                return _titol;
            }
            set
            {
                _titol = value;
            }
        }
        public string OkText
        {
            get
            {
                return _okText;
            }set
            {
                _okText = value;
            }
        }
        public bool TextEnabled
        {
            get
            {
                return _textEnabled;
            }
            set
            {
                _textEnabled = value;
            }
        }
        public Local Local
        {
            get
            {
                return _local;
            }
            set
            {
                _local = value;
            }
        }
        public List<TipoLocal> TipoLocal
        {
            get
            {return _tipoLocal;
            }
            set
            {
                _tipoLocal = value;
            }
        }
        public List<string> Poblaciones
        {
            get
            {
                return _poblaciones;
            }
            set
            {
                _poblaciones = value;            
            }
        }
        public crudLocalViewModel()
        {          
            TipoLocal = ctx.TipoLocals.ToList();
            Poblaciones = ctx.Direccions.Select(x => x.Población).Distinct().ToList();
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
        public virtual bool IsModal { get { return true; } }
        public virtual void RequestClose() { this.DialogClosing(this, null); }
        public virtual event EventHandler DialogClosing;

        public ICommand OkCommand { get { return new RelayCommand(Ok); } }
        protected virtual void Ok()
        {
            if (this.OnOk != null)
                this.OnOk(this);
            else
                Close();
        }

        public ICommand CancelCommand { get { return new RelayCommand(Cancel); } }
        protected virtual void Cancel()
        {
            if (this.OnCancel != null)
                this.OnCancel(this);
            else
                Close();
        }

        public void Close()
        {
            if (this.DialogClosing != null)
                this.DialogClosing(this, new EventArgs());
        }

        public Action<crudLocalViewModel> OnOk { get; set; }
        public Action<crudLocalViewModel> OnCancel { get; set; }
        public Action<crudLocalViewModel> OnCloseRequest { get; set; }
    }
}
