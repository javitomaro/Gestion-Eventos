//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionEventos.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipolocal
    {
        public tipolocal()
        {
            this.locals = new HashSet<local>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<local> locals { get; set; }
    }
}
