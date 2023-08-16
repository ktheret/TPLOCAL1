using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        [Required (ErrorMessage = "Le champ 'Nom de famille' est requit")]
        [Display(Name = "Nom de famille")]
        public string LastName { get; set; }
 
        [Required(ErrorMessage = "Le champ 'Prénom' est requit")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Veuillez selectionner un genre")]
        [Display(Name = "Sexe")]
        public string Sexe { get; set; }

        [Required(ErrorMessage = "Le champ 'Adresse' est requit")]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Le champ 'Code Postal' est requit")]
        [Display(Name = "Code Postal")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le champ 'Code Postal' doit être composé de 5 chiffres")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Le champ 'Ville' est requit")]
        [Display(Name = "Ville")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Le champ 'Email' est requit")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Le format de l'adresse mail ne correspond pas")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ 'Date de Début' est requit")]
        [Display(Name = "Date de début")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Le champ 'Formation suivie' est requit")]
        [Display(Name = "Formation suivie")]
        public string TrainingType { get; set; }

        [Required(ErrorMessage = "Le champ 'Formation Cobol' est requit")]
        [Display(Name = "Formation Cobol")]
        public string CobolTraining { get; set; }

        [Required(ErrorMessage = "Le champ 'Formation C#' est requit")]
        [Display(Name = "Formation C#")]
        public string CSTraining { get; set; }
    }


}
