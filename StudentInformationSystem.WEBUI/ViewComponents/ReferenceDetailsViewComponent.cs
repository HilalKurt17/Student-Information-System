using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class ReferenceDetailsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Views/Shared/Components/ReferenceDetails/Default.cshtml
        }
    }
}
