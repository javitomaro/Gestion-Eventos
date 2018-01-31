using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEventos.ViewModel;
using GestionEventos.Model;

namespace GestionEventos.ViewModel
{
    class DetalleEventoViewModel
    {
        eventosEntities db = new eventosEntities();
        private Evento _eventoguay;
        private string _f1;
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
        public string f1
        {
            get
            {
                return _f1;
            }
            set
            {
                _f1 = value;
            }
        }
        public DetalleEventoViewModel(object ev)
        {
            eventoguay = (Evento)ev;
            _f1 = db.Flyers.Where(x => x.IdEvento == eventoguay.Id).ToList().Select(x => x.Flyer1).FirstOrDefault();
        }
        public DetalleEventoViewModel() { }
    }
}
