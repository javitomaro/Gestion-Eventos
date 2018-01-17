using System;
using System.Windows.Input;
using MvvmDialogs.ViewModels;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

namespace GestionEventos.ViewModel
{
    class homeLocalViewModel : ViewModelBase, IUserDialogViewModel
    {
        private string _okText;
        private bool _textEnabled;
        private string _title;

        public string OkText
        {
            get { return _okText; }
            set { _okText = value; }
        }
        public bool TextEnabled
        {
            get { return _textEnabled; }
            set { _textEnabled = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }     
        public virtual bool IsModal { get { return true; } }
        public virtual void RequestClose() { this.DialogClosing(this, null); }
        public virtual event EventHandler DialogClosing;      
        //public event PropertyChangedEventHandler PropertyChanged;           

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
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

        public Action<homeLocalViewModel> OnOk { get; set; }
        public Action<homeLocalViewModel> OnCancel { get; set; }       
        public Action<homeLocalViewModel> OnCloseRequest { get; set; }
    }
}
