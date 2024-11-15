using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCoreAssignmentRepository : IAssignmentRepository
    {
        SISContext _context;
        public EfCoreAssignmentRepository(SISContext context)
        {
            _context = context;
        }
        public void Add(Assignment entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Assignment? assignment = _context.Assignments.FirstOrDefault(i => i.AssignmentID == id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
            }
        }

        public List<Assignment> GetAllT()
        {
            return _context.Assignments.ToList();
        }

        public Assignment? GetById(int id)
        {
            return _context.Assignments.FirstOrDefault(i => i.AssignmentID == id);
        }

        public void Update(Assignment entity)
        {
            _context.Assignments.Update(entity);
        }
    }
}
