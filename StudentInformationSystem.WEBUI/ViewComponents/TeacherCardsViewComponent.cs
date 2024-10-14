using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class TeacherCardsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(TeacherViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
