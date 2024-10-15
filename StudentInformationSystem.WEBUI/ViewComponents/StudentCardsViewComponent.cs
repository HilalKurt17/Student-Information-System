using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class StudentCardsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(StudentViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
