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
                .Include(r => r.References)
                .Include(t => t.TeacherLessons)
                .ToList();
        }

        public Teacher? GetById(int id) // get teacher by id
        {
            Teacher? teacher = _context
                                .Teachers
                                .Include(r => r.References)
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
            if (teacher.References == null || teacher.References.Count() == 0)
            {
                teacher.References.Add(new References());
            }

            return teacher;

        }

        public void Update(Teacher entity) // update teacher
        {
            Teacher? existingTeacher = _context
                .Teachers
                .Include(t => t.TeacherLessons)
                .Include(r => r.References)
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
            if ((existingTeacher.References == null || existingTeacher.References.Count() == 0))
            {
                existingTeacher.References.Add(entity.References[0]);
            }
            else
            {
                foreach (References reference in existingTeacher.References)
                {
                    int index = existingTeacher.References.IndexOf(reference);
                    existingTeacher.References[index] = entity.References[index];
                }
            }
            // update surname
            if (entity.Surname != null && entity.Surname != existingTeacher.Surname)
            {
                existingTeacher.Surname = entity.Surname;
            }
            // update mail
            if (entity.Mail != null && entity.Mail != existingTeacher.Mail)
            {
                existingTeacher.Mail = entity.Mail;
            }
            // update phone
            if (entity.Phone != null && entity.Phone != existingTeacher.Phone)
            {
                existingTeacher.Phone = entity.Phone;
            }
            // update education level
            if (entity.EducationLevel != existingTeacher.EducationLevel)
            {
                existingTeacher.EducationLevel = entity.EducationLevel;
            }
            // update IBAN
            if (entity.IBAN != null && entity.IBAN != existingTeacher.IBAN)
            {
                existingTeacher.IBAN = entity.IBAN;
            }
            // update Teacher score
            if (entity.TeacherScore != null && entity.TeacherScore != existingTeacher.TeacherScore)
            {
                existingTeacher.TeacherScore = entity.TeacherScore;
            }
            // update cv file path if there is no existing cv for the teacher and new cv filepath is not null
            if (entity.CVFilePath != null && existingTeacher.CVFilePath == null)
            {
                existingTeacher.CVFilePath = entity.CVFilePath;
            }
            //update details of teacher
            if (entity.Details != null && existingTeacher.Details != entity.Details)
            {
                existingTeacher.Details = entity.Details;
            }
            // update approvement status of teacher
            if (entity.IsApproved != existingTeacher.IsApproved && existingTeacher.IsApproved == false)
            {
                existingTeacher.IsApproved = entity.IsApproved;
            }
            // update unenrollment state of the teacher
            if (entity.UnenrollmentState != existingTeacher.UnenrollmentState)
            {
                existingTeacher.UnenrollmentState = entity.UnenrollmentState;
            }


            _context.SaveChanges();
        }
    }
}
