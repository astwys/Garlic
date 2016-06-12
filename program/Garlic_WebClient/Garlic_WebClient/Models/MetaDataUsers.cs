using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garlic_WebClient.Models
{
    [MetadataType(typeof(MetaDataUsers))]
    public partial class schueler { }

    public class MetaDataUsers
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must have at least 3 characters and a maximum of 20 characters.")]
        public string u_username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string u_password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string u_email { get; set; }
    }
}