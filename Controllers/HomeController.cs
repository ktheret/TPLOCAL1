using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.IO;
using TPLOCAL1.Models;


//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        // Get path to the XML File to get Opinion
                        string directory = Directory.GetCurrentDirectory();
                        string filePath = directory + @"\XlmFile\DataAvis.xml";
                        OpinionList opinion = new OpinionList();
                        List<Opinion> opinionList = opinion.GetAvis(filePath);
                        return View(id, opinionList);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        FormModel formModel = new FormModel();
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationFormulaire(FormModel formModel)
        {
            //Manage errors of format
            if (formModel.Sexe.Equals(FormModel.Sexes.First()))
            {
                ModelState.AddModelError("Sexe", "Selectionnez un genre");
            }

            if (formModel.StartDate > DateTime.Parse("01/01/2021"))
            {
                ModelState.AddModelError("StartDate", "La doit commencer avant le 01/01/2021");
            }

            //Manage errors of format - depends on the Training Selected
            if (formModel.TrainingType.Equals(FormModel.Trainings.First()))
            {
                ModelState.AddModelError("TrainingType", "Selectionnez une formation");
            }
            else if (formModel.TrainingType.Equals(FormModel.Trainings.ElementAt(1)) && formModel.CobolTraining == null)
            {
                ModelState.AddModelError("CobolTraining", "Vous avez choisi la formation Cobol : Donnez un avis pour cette formation");
            }
            else if (formModel.TrainingType.Equals(FormModel.Trainings.ElementAt(2)) && formModel.CSTraining == null)
            {
                ModelState.AddModelError("CSTraining", "Vous avez choisi la formation Cobol : Donnez un avis pour cette formation");
            }
            else if (formModel.TrainingType.Equals(FormModel.Trainings.ElementAt(3)) && (formModel.CobolTraining == null || formModel.CSTraining == null))
            {
                ModelState.AddModelError("CobolTraining", "Donnez un avis pour les deux formations.");
            }


            //Check if model has errors to return the proper view
            if (!ModelState.IsValid)
            {
                return View("Form", formModel);
            }


            return View(nameof(ValidationFormulaire), formModel);
         
        }
    }
}