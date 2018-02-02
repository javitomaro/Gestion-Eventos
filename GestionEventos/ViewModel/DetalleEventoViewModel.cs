using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEventos.ViewModel;
using GestionEventos.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs.ViewModels;

namespace GestionEventos.ViewModel
{
    class DetalleEventoViewModel : IUserDialogViewModel
    {
        eventosEntities db = new eventosEntities();
        private Evento _eventoguay;   
        public Evento eventoguay
        {
            get
            {
                return _eventoguay;
            }
            set
            {
                _eventoguay = value;
            }
        }       
        public DetalleEventoViewModel() { }
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

        public Action<DetalleEventoViewModel> OnOk { get; set; }
        public Action<DetalleEventoViewModel> OnCancel { get; set; }
        public Action<DetalleEventoViewModel> OnCloseRequest { get; set; }
    }
}
