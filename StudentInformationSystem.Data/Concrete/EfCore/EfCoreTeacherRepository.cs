using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCoreTeacherRepository : ITeacherRepository
    {
        private SISContext _context;

        public EfCoreTeacherRepository(SISContext context)
        {
            _context = context;
        }

        public void Add(Teacher entity) // add new teacher
        {
            _context.Teachers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id) // delete teacher
        {
            Teacher? teacher = _context.Teachers.FirstOrDefault(i => i.TeacherID == id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
        }

        public List<Teacher> GetAllT() // list all teachers
        {
            return _context.Teachers.ToList();
        }

        public Teacher? GetById(int id) // get teacher by id
        {
            Teacher? teacher = _context
                                .Teachers
                                .Include(t => t.TeacherLessons)
                                .FirstOrDefault(i => i.TeacherID == id);

            return teacher;

        }

        public void Update(Teacher entity) // update teacher
        {
            _context.Teachers.Update(entity);
            _context.SaveChanges();
        }
    }
}
