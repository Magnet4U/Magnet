using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
        [MetadataType(typeof(UserMetaData))]
        public partial class User
        {
            public string ConfirmPassword { get; set; }
        }

        public class UserMetaData
        {
            [Key]
           public int idUser { get; set; }

        [Display(Name = "First Name")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
            public string firstname { get; set; }

        [Display(Name = "Last Name")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
             public string lastname { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> DateofBirth { get; set; }

        [Display(Name = "Cin")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
        public int cin { get; set; }


        [Display(Name = "Telephone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
        public int telephone { get; set; }

        [Display(Name = "Email")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
            [DataType(DataType.EmailAddress)]
             public string email { get; set; }

            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "CHouaia setta")]
             public string password { get; set; }

            [Display(Name = "Confirm Password")]
            [DataType(DataType.Password)]
            [Compare("password", ErrorMessage = "do not match")]
            public string ConfirmPassword { get; set; }
        
    }
    
}
