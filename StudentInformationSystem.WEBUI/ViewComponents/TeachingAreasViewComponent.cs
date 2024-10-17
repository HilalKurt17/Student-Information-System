using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;
using StudentInformationSystem.WEBUI.ViewModels;

namespace StudentInformationSystem.WEBUI.ViewComponents
{
    public class TeachingAreasViewComponent : ViewComponent
    {
        private ILessonRepository _lessonRepository;

        public TeachingAreasViewComponent(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public IViewComponentResult Invoke(List<TeacherLesson> teacherLessons)
        {
            TeachingAreasDetailsViewModel viewModel = new TeachingAreasDetailsViewModel
            {
                lessons = _lessonRepository.GetAllT(),
                teacherLesson = teacherLessons
            };
            return View(viewModel);
        }
    }
}
