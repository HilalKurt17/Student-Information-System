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
            return _context.Teachers
                .Include(t => t.TeacherLessons)
                .ToList();
        }

        public Teacher? GetById(int id) // get teacher by id
        {
            Teacher? teacher = _context
                                .Teachers
                                .Include(t => t.TeacherLessons)
                                .FirstOrDefault(i => i.TeacherID == id);
            if (teacher.TeacherLessons == null || teacher.TeacherLessons.Count() == 0)
            {
                List<TeacherLesson> tl = new List<TeacherLesson>
                {
                    new TeacherLesson{ TeacherID = teacher.TeacherID, LessonID=1,IsChecked=false},
                    new TeacherLesson{ TeacherID = teacher.TeacherID, LessonID=2, IsChecked=false },
                    new TeacherLesson{TeacherID = teacher.TeacherID, LessonID=3, IsChecked=false },
                    new TeacherLesson{TeacherID = teacher.TeacherID, LessonID=4, IsChecked=false },
                    new TeacherLesson{TeacherID = teacher.TeacherID, LessonID=5, IsChecked=false },
                    new TeacherLesson{TeacherID = teacher.TeacherID, LessonID=6, IsChecked=false },
                    new TeacherLesson{TeacherID = teacher.TeacherID, LessonID=7, IsChecked=false },
                    new TeacherLesson{TeacherID = teacher.TeacherID, LessonID=8, IsChecked=false }
                };
                teacher.TeacherLessons.AddRange(tl);
            }
            return teacher;

        }

        public void Update(Teacher entity) // update teacher
        {
            Teacher? existingTeacher = _context
                .Teachers
                .Include(t => t.TeacherLessons)
                .FirstOrDefault(t => t.TeacherID == entity.TeacherID);
            if (existingTeacher.TeacherLessons == null || existingTeacher.TeacherLessons.Count() == 0)
            {
                existingTeacher.TeacherLessons.AddRange(entity.TeacherLessons);
            }
            else
            {
                foreach (TeacherLesson lesson in existingTeacher.TeacherLessons)
                {
                    int lessonID = lesson.LessonID;
                    TeacherLesson entityTeacherLesson = entity.TeacherLessons.FirstOrDefault(t => t.LessonID == lessonID);
                    if (lesson.IsChecked != entityTeacherLesson.IsChecked)
                    {
                        lesson.IsChecked = entityTeacherLesson.IsChecked;
                    }
                }
            }
            var isModified = _context.Entry(entity);
            if (isModified.State == EntityState.Modified)
            {
                _context.Teachers.Update(entity);
            }

            _context.SaveChanges();
        }
    }
}
