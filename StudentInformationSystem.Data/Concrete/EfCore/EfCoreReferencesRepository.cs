using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCoreReferencesRepository : IReferencesRepository
    {
        SISContext _context;
        public EfCoreReferencesRepository(SISContext context)
        {
            _context = context;
        }
        public void AddReference(References reference)
        {
            _context.TeacherReferences.Add(reference);
        }

        public void DeleteReference(References reference)
        {
            _context.TeacherReferences.Remove(reference);
        }

        public void UpdateReference(References reference)
        {
            _context.TeacherReferences.Update(reference);
        }
    }
}
