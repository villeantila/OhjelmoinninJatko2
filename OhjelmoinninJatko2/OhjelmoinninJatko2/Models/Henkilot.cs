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
    
    public partial class Henkilot
    {
        public int HenkiloId { get; set; }
        public Nullable<int> Identity { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Osoite { get; set; }
        public Nullable<int> Esimies { get; set; }
    }
}
