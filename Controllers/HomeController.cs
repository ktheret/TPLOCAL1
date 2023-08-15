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
                        //TODO : code reading of the xml files provide
                        OpinionList opinion = new OpinionList();
                        string directory = Directory.GetCurrentDirectory();
                        string file = directory + @"\XlmFile\DataAvis.xml";
                        List<Opinion> opinionList = opinion.GetAvis(file);
                        return View(id, opinionList);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationFormulaire([Bind("LastName, FirstName, Zipcode")]FormModel formModel)
        {
            //TODO : test if model's fields are set
            //if not, display an error message and stay on the form page
            //else, call ValidationForm with the datas set by the user
            if(formModel.Zipcode == null)
            {
                ModelState.AddModelError("", "Format du ZipCode non valide");
                return RedirectToAction("Index/Form");
            }
            return View(formModel);

        }
    }
}