using GalaSoft.MvvmLight;
using MvvmDialogs.ViewModels;
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
    class crudEventoViewModel : ViewModelBase, IUserDialogViewModel
    {
        eventosEntities1 ctx = new eventosEntities1();

        private List<TipoEvento> _TipoEvento;


        public List<TipoEvento> TipoEvento
        {
            get
            {
                return _TipoEvento;
            }
            set
            {
                _TipoEvento = value;
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
        public virtual bool IsModal { get { return true; } }
        public virtual void RequestClose() { this.DialogClosing(this, null); }
        public virtual event EventHandler DialogClosing;
    }
}
