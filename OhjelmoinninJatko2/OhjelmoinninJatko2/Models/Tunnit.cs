//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OhjelmoinninJatko2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tunnit
    {
        public int TuntiId { get; set; }
        public Nullable<int> Identity { get; set; }
        public Nullable<int> ProjektiId { get; set; }
        public Nullable<int> HenkiloId { get; set; }
        public Nullable<System.DateTime> Pvm { get; set; }
        public Nullable<decimal> ProjektinTunnit { get; set; }
    
        public virtual Henkilot Henkilot { get; set; }
        public virtual Projektit Projektit { get; set; }
    }
}
