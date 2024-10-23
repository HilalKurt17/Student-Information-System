using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class ReferenceDetailsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<References> referenceModel, IFormFile? referenceUploadFile)
        {
            if (referenceModel.Count == 0 || referenceModel == null)
            {
                referenceModel = new List<References> { new References()
            };
            }

            ReferenceDetailsViewModel referenceDetails = new ReferenceDetailsViewModel
            {
                references = referenceModel,
                referenceLetter = referenceUploadFile
            };

            return View(referenceDetails); // Views/Shared/Components/ReferenceDetails/Default.cshtml
        }
    }
}
