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
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Collections.ObjectModel;
using GestionEventos.View;
using System.Windows;

namespace GestionEventos.ViewModel
{
    class crudEventoViewModel : IUserDialogViewModel, INotifyPropertyChanged
    {

        eventosEntities ctx = new eventosEntities();
        private String _title;
        private string _okText;
        private bool _textEnabled;

        //SELECTED
        private TipoEvento _selectedTipo;
        public TipoEvento seletedTipo
        {
            get { return _selectedTipo; }
            set { _selectedTipo = value; }
        }

        private Direccion _selectedDireccion;
        public Direccion selectedDireccion
        {
            get { return _selectedDireccion; }
            set { _selectedDireccion = value; }
        }

        private String _selectedFlyer;
        public String selectedFlyer
        {
            get { return _selectedFlyer; }
            set { _selectedFlyer = value; }
        }
        #region Direccion
        private Direccion _nuevaDireccion;
        private Direccion _direccion;
        public Direccion NuevaDireccion
        {
            get
            {
                return _nuevaDireccion;
            }
            set
            {
                _nuevaDireccion = value;
            }
        }
        public Direccion direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        #endregion

        #region Población
        private string _SelectedPoblacion;
        private List<String> _Poblacion;
        public String selectedPoblacion
        {
            get { return _SelectedPoblacion; }
            set
            {
                _SelectedPoblacion = value;
                loadCalle(value);
                NotifyPropertyChanged();
            }
        }
        public List<String> listPoblacion
        {
            get { return _Poblacion; }
            set { _Poblacion = value; }
        }

        #endregion

        #region Calle
        private Direccion _SelectedCalle;
        private List<Direccion> _listCalle;
        public Direccion SelectedCalle
        {
            get { return _SelectedCalle; }
            set { _SelectedCalle = value; }
        }
        public List<Direccion> listCalle
        {
            get { return _listCalle; }
            set { _listCalle = value; NotifyPropertyChanged(); }
        }

        private void loadCalle(String value)
        {
            listCalle = ctx.Direccions.OrderBy(x => x.Calle).Where(x => x.Población == value).ToList();

        }
        #endregion

        #region Flyer
        private Flyer _flyer;
        public Flyer flyer
        {
            get { return _flyer; }
            set { _flyer = value; }
        }
        #endregion

        #region Fecha
        private String _aux_fecha;
        public String aux_fecha
        {
            get { return _aux_fecha; }
            set
            {
                try
                {
                    evento.Fecha = Convert.ToDateTime(value);
                    _aux_fecha = value;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Vuelve a intentar poner la fecha" + e.Data);
                }

            }
        }
        #endregion

        #region Tipo
        private List<TipoEvento> _TipoEvento;
        public List<TipoEvento> TipoEventos
        {
            get { return _TipoEvento; }
            set { _TipoEvento = value; }
        }
        #endregion

        #region Estilo
        private List<Estilo> _EstiloEvento;
        public List<Estilo> EstiloEventos
        {
            get { return _EstiloEvento; }
            set { _EstiloEvento = value; }
        }
        #endregion

        #region Local
        private Local _local;
        public Local local
        {
            get { return _local; }
            set { _local = value; }
        }

        #endregion

        #region EVENTO
        private Evento _evento;
        public Evento evento
        {
            get { return _evento; }

            set
            {
                _evento = value;
                loadCalle(selectedPoblacion);
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public crudEventoViewModel()
        {
            ListaComboBoxsEvento();

        }

        public crudEventoViewModel(String title, Evento aux_evento)
        {
            ListaComboBoxsEvento();
            Update(aux_evento);
        }

        private void Update(Evento aux_evento)
        {
            if (evento != null)
            {
                Flyer flyer_aux = ctx.Flyers.Where(x => x.IdEvento == evento.Id).FirstOrDefault();
                local = ctx.Locals.Where(x => x.Id == 3).FirstOrDefault();

                flyer.Flyer1 = flyer_aux.Flyer1;

                string selectPoblacion = ctx.Direccions.Where(x => x.Id == evento.IdDireccion).Select(x => x.Población).ToString();
                selectedDireccion = ctx.Direccions.Where(x => x.Población == selectPoblacion).FirstOrDefault();
            }

        }

        public void ListaComboBoxsEvento()
        {
            TipoEventos = ctx.TipoEventoes.OrderBy(x => x.Nombre).ToList();
            EstiloEventos = ctx.Estiloes.OrderBy(x => x.Nombre).ToList();
            listPoblacion = ctx.Direccions.OrderBy(x => x.Población).Select(x => x.Población).Distinct().ToList();
        }
        #endregion

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public bool TextEnabled
        {
            get { return _textEnabled; }
            set { _textEnabled = value; }
        }

        public string OkText
        {
            get { return _okText; }
            set { _okText = value; }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


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
        public Action<crudEventoViewModel> OnOk { get; set; }
        public Action<crudEventoViewModel> OnCancel { get; set; }
        public Action<crudEventoViewModel> OnCloseRequest { get; set; }
        public virtual bool IsModal { get { return true; } }
        public virtual void RequestClose() { this.DialogClosing(this, null); }
        public virtual event EventHandler DialogClosing;






    }
}

