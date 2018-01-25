using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEventos.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        public Cliente SelectedCliente {
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
            Locales = ctx.Locals.Select(x => x).ToList();
            Clientes = ctx.Clientes.Select(x => x).ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}

