//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sedas_Ticaret.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cariler
    {
        public int CariID { get; set; }
        public int StokID { get; set; }
        public int MusteriID { get; set; }
        public System.DateTime Tarih { get; set; }
        public string Miktar { get; set; }
        public decimal Tutar { get; set; }
    
        public virtual Musteriler Musteriler { get; set; }
        public virtual Stoklar Stoklar { get; set; }
    }
}
