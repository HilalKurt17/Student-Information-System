using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class ReferenceDetailsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<References> referenceModel)
        {
            if (referenceModel.Count == 0 || referenceModel == null)
            {
                referenceModel = new List<References> { new References()
            };
            }

            return View(referenceModel); // Views/Shared/Components/ReferenceDetails/Default.cshtml
        }
    }
}
