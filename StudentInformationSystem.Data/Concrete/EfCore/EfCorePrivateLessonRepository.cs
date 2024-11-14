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

        public void Add(StudentTeacher entity) // add new private lesson
        {
            _context.StudentTeachers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id) // delete private lesson by id
        {
            StudentTeacher? privateLesson = _context.StudentTeachers.FirstOrDefault(i => i.PrivateLessonID == id);
            if (privateLesson != null)
            {
                _context.StudentTeachers.Remove(privateLesson);
            }
            _context.SaveChanges();
        }

        public List<StudentTeacher> GetAllT() // get all private lessons
        {
            return _context.StudentTeachers.ToList();
        }

        public StudentTeacher? GetById(int id) // get private lesson by id
        {
            return _context.StudentTeachers.FirstOrDefault(i => i.PrivateLessonID == id);
        }
        public void NewEnrollment(StudentTeacher newEnrollment) // student enrollment
        {
            StudentTeacher oldEnrollment = GetById(newEnrollment.PrivateLessonID)!;
            oldEnrollment.StudentID = newEnrollment.StudentID;
            _context.SaveChanges();
        }

        public void Update(StudentTeacher updatedEntity) // update private lesson information
        {
            _context.StudentTeachers.Update(updatedEntity);
            _context.SaveChanges();
        }


    }
}
