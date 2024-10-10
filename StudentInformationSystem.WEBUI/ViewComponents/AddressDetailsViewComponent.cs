using Microsoft.AspNetCore.Mvc;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class AddressDetailsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); //goes to Views/Components/AddressDetails/Default.cshtml
        }
    }
}
