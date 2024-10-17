using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{

    public class EfCoreStudentRepository : IStudentRepository
    {
        private SISContext _context;

        public EfCoreStudentRepository(SISContext context)
        {
            _context = context;
        }

        public void Add(Student entity) // add new student
        {
            _context.Students.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(int id) // delete student
        {
            Student? student = _context.Students.FirstOrDefault(i => i.StudentID == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public List<Student> GetAllT() // list all student
        {
            return _context.Students.ToList();
        }

        public Student? GetById(int id) // get student by id
        {
            return _context.Students.FirstOrDefault(i => i.StudentID == id);
        }

        public void Update(Student entity) // update student
        {
            _context.Students.Update(entity);
        }
    }
}
