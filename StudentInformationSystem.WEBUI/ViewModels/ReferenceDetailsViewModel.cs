using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class ReferenceDetailsViewModel
    {
        public List<References> references { get; set; }
        public IFormFile? referenceLetter { get; set; }
    }
}
