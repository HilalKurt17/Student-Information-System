using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface IWorkExperienceRepository
    {
        void AddWorkExperience(WorkExperience workExperience);
        void DeleteWorkExperience(WorkExperience workExperience);
        void UpdateWorkExperience(WorkExperience workExperience);
    }
}
