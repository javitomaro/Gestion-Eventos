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
    
    public partial class TipoLocal
    {
        public TipoLocal()
        {
            this.Local = new HashSet<Local>();
            this.Local1 = new HashSet<Local>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<Local> Local { get; set; }
        public virtual ICollection<Local> Local1 { get; set; }
    }
}
