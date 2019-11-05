using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [MetadataType(typeof(EntrepriseMetaData))]
    public partial class Entreprise
    {
        public string ConfirmPassword { get; set; }
    }
        public class EntrepriseMetaData
        {
        [Key]
        public int idEntreprise { get; set; }
        [Display(Name = "Entreprise Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
        public string name { get; set; }
        [Display(Name = "Email ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "more than 6 caracters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Phone Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
        public int telephone { get; set; }
        [Display(Name = "Entreprise Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
        public string introduction { get; set; }
        [Display(Name = "Number of Employees")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Champ NULL")]
        public int nbEmployee { get; set; }
        }
    }
