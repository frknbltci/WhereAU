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
    
    public partial class tblHocalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHocalar()
        {
            this.poolBolumDers = new HashSet<poolBolumDers>();
        }
    
        public int HocaID { get; set; }
        public string HocaName { get; set; }
        public string HocaSurname { get; set; }
        public string HocaMail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<poolBolumDers> poolBolumDers { get; set; }
    }
}