//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Garlic_WebClient.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class csm_connectedsocialmedias
    {
        public string csm_sm_name { get; set; }
        public string csm_u_username { get; set; }
        public string csm_password { get; set; }
    
        public virtual sm_socialmedias sm_socialmedias { get; set; }
        public virtual u_users u_users { get; set; }
    }
}
