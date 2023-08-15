using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormModel
    {
        public string LastName { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Review given (Possible values: O or N)
        /// </summary>
        public string OpinionGiven { get; set; }
        /// <summary>
        /// Sexe (Possible values : Man, Woman, Other)
        /// </summary>
        public string Sexe { get; set; }
        public string Address { get; set; }
        
        
        [RegularExpression(@"^\d{5}$")]
        public string Zipcode { get; set; }
        public string Town { get; set; }
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public string TrainingType { get; set; }
        public string CobolTraining { get; set; }
        public string CSTraining { get; set; }
    }
}
