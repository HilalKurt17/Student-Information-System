using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        public void SubmitAssignment(Assignment assignment);

        public void GradeAssignment(Assignment assignment);
    }
}
