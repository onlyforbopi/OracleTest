//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OracleTest10.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UNDEL_CAUSE
    {
        public UNDEL_CAUSE()
        {
            this.MAINs = new HashSet<MAIN>();
        }
    
        public string ID { get; set; }
        public string DESCR { get; set; }
    
        public virtual ICollection<MAIN> MAINs { get; set; }
    }
}
