using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCoreLessonRepository : ILessonRepository
    {
        private SISContext _context;
        public EfCoreLessonRepository(SISContext context)
        {
            _context = context;
        }

        public void Add(Lesson entity)
        {
            _context.Add(entity);
        }

        public void Delete(int id)
        {
            Lesson? lesson = _context.Lessons.FirstOrDefault(i => i.LessonID == id);
            if (lesson != null)
            {
                _context.Remove(lesson);
            }
        }

        // get all lessons from database

        public List<Lesson> GetAllT()
        {
            return _context.Lessons.ToList();
        }

        public Lesson? GetById(int id)
        {
            return _context.Lessons.FirstOrDefault(i => i.LessonID == id);
        }

        public void Update(Lesson entity)
        {
            _context.Lessons.Update(entity);
        }
    }
}
