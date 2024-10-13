using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCoreWorkExperienceRepository : IWorkExperienceRepository
    {
        SISContext _context;
        public EfCoreWorkExperienceRepository(SISContext context)
        {
            _context = context;
        }
        public void AddWorkExperience(WorkExperience workExperience)
        {
            _context.WorkExperiences.Add(workExperience);
        }

        public void DeleteWorkExperience(WorkExperience workExperience)
        {
            _context.WorkExperiences.Remove(workExperience);
        }

        public void UpdateWorkExperience(WorkExperience workExperience)
        {
            _context.WorkExperiences.Update(workExperience);
        }
    }
}
