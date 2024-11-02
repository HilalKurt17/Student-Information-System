using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCorePrivateLessonRepository : IPrivateLessonRepository
    {
        SISContext _context;
        public EfCorePrivateLessonRepository(SISContext context)
        {
            _context = context;
        }

        public void Add(StudentTeacher entity)
        {
            _context.StudentTeachers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            StudentTeacher? privateLesson = _context.StudentTeachers.FirstOrDefault(i => i.PrivateLessonID == id);
            if (privateLesson != null)
            {
                _context.StudentTeachers.Remove(privateLesson);
            }
        }

        public List<StudentTeacher> GetAllT()
        {
            return _context.StudentTeachers.ToList();
        }

        public StudentTeacher? GetById(int id)
        {
            return _context.StudentTeachers.FirstOrDefault(i => i.PrivateLessonID == id);
        }

        public void Update(StudentTeacher entity)
        {
            _context.StudentTeachers.Update(entity);
            _context.SaveChanges();
        }
    }
}
