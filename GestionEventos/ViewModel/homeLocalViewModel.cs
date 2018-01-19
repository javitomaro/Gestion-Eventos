using System;
using System.Windows.Input;
using MvvmDialogs.ViewModels;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

namespace GestionEventos.ViewModel
{
    class homeLocalViewModel : ViewModelBase , IDialogViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}



        #region PRUEBA DIALOGO
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
        public ICommand LogOutCommand { get { return new RelayCommand(LogOut); } }
        protected virtual void LogOut()
        {
            if (this.OnLogOut != null)
                this.OnLogOut(this);
            Close();
        }

        public Action<homeLocalViewModel> OnOk { get; set; }
        public Action<homeLocalViewModel> OnCancel { get; set; }
        public Action<homeLocalViewModel> OnCloseRequest { get; set; }
        public Action<homeLocalViewModel> OnLogOut { get; set; }
        #endregion
    }
}
