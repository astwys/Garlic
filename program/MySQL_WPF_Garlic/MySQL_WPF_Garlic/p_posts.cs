//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySQL_WPF_Garlic
{
    using System;
    using System.Collections.Generic;
    
    public partial class p_posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public p_posts()
        {
            this.v_votes = new HashSet<v_votes>();
            this.p_posts2 = new HashSet<p_posts>();
        }
    
        public int p_id { get; set; }
        public string p_content { get; set; }
        public System.DateTime p_date { get; set; }
        public string p_u_username { get; set; }
    
        public virtual a_articles a_articles { get; set; }
        public virtual u_users u_users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<v_votes> v_votes { get; set; }
        public virtual p_posts p_posts1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_posts> p_posts2 { get; set; }
    }
}
