//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HocamNerede
{
    using System;
    using System.Collections.Generic;
    
    public partial class poolBolumDers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public poolBolumDers()
        {
            this.tblHvz = new HashSet<tblHvz>();
        }
    
        public int Id { get; set; }
        public int FpoolfakultebolumID { get; set; }
        public int FDersID { get; set; }
        public string Sınıf { get; set; }
        public string VideoUrl { get; set; }
        public Nullable<int> FHocaID { get; set; }
    
        public virtual poolFakulteBolum poolFakulteBolum { get; set; }
        public virtual tblDersler tblDersler { get; set; }
        public virtual tblHocalar tblHocalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHvz> tblHvz { get; set; }
    }
}