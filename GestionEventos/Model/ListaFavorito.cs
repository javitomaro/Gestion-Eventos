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
    
    public partial class ListaFavorito
    {
        public int IdCliente { get; set; }
        public int IdLocal { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Cliente Cliente1 { get; set; }
        public virtual Local Local { get; set; }
        public virtual Local Local1 { get; set; }
    }
}
