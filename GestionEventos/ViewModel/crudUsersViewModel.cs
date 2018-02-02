using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEventos.Model;
using System.Collections.ObjectModel;
using MvvmDialogs.ViewModels;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace GestionEventos.ViewModel
{
    class crudUsersViewModel : IUserDialogViewModel
    {
        eventosEntities ctx = new eventosEntities();
        private string _titol;
        private string _okText;
        private bool _textEnabled;
        private bool _rolEnabled;
        private Usuario _usuario;
        private List<Rol> _roles;
        public bool RolEnabled
        {
            get
            {
                return _rolEnabled;
            }
            set
            {
                _rolEnabled = value;
            }
        }
        public string Titol
        {
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
            }
            set
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
        public Usuario Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
            }
        }       
        public List<Rol> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }
        
        public crudUsersViewModel()
        {
            CargarRoles();
        }
        public void CargarRoles()
        {
            Roles = ctx.Rols.ToList();
        }

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

        public Action<crudUsersViewModel> OnOk { get; set; }
        public Action<crudUsersViewModel> OnCancel { get; set; }
        public Action<crudUsersViewModel> OnCloseRequest { get; set; }
    }
}
