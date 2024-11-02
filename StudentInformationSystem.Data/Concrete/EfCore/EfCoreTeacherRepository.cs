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
                                .Include(st => st.StudentTeachers)
                                .FirstOrDefault(i => i.TeacherID == id);
            if (teacher.TeacherLessons == null || teacher.TeacherLessons.Count() == 0)
            {
                List<TeacherLesson> tl = new List<TeacherLesson>
                {
                    new TeacherLesson{TeacherID = teacher.TeacherID, LessonID=1,IsChecked=false},
                    new TeacherLesson{TeacherID = teacher.TeacherID, LessonID=2, IsChecked=false },
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

        public void ConfirmTeacher(Teacher entity)
        {
            Teacher? existingTeacher = _context
                                        .Teachers
                                        .FirstOrDefault(t => t.TeacherID == entity.TeacherID);
            existingTeacher.IsApproved = true;
            _context.SaveChanges();
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
                for (int index = 0; index < existingTeacher.References.Count(); index++)
                {
                    // update reference name if required
                    if (entity.References[index].Name != null && entity.References[index].Name != existingTeacher.References[index].Name)
                    {
                        existingTeacher.References[index].Name = entity.References[index].Name;
                    }
                    // update reference company if required
                    if (entity.References[index].CompanyName != null && entity.References[index].CompanyName != existingTeacher.References[index].CompanyName)
                    {
                        existingTeacher.References[index].CompanyName = entity.References[index].CompanyName;
                    }
                    // update reference mail if required
                    if (entity.References[index].Mail != null && entity.References[index].Mail != existingTeacher.References[index].Mail)
                    {
                        existingTeacher.References[index].Mail = entity.References[index].Mail;

                    }
                    // update reference current position if required (job title)
                    if (entity.References[index].CurrentPosition != null && entity.References[index].CurrentPosition != existingTeacher.References[index].CurrentPosition)
                    {
                        existingTeacher.References[index].CurrentPosition = entity.References[index].CurrentPosition;
                    }
                    // update reference phone if required
                    if (entity.References[index].Phone != null && entity.References[index].Phone != existingTeacher.References[index].Phone)
                    {
                        existingTeacher.References[index].Phone = entity.References[index].Phone;
                    }
                    // update reference letter file path if required
                    if (entity.References[index].ReferenceLetterFilePath != null && entity.References[index].ReferenceLetterFilePath != existingTeacher.References[index].ReferenceLetterFilePath)
                    {
                        existingTeacher.References[index].ReferenceLetterFilePath = entity.References[index].ReferenceLetterFilePath;
                    }

                }
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

            // update cv file path if required
            if (entity.CVFilePath != null && existingTeacher.CVFilePath != entity.CVFilePath)
            {
                existingTeacher.CVFilePath = entity.CVFilePath;
            }
            //update details of teacher
            if (entity.Details != null && existingTeacher.Details != entity.Details)
            {
                existingTeacher.Details = entity.Details;
            }


            _context.SaveChanges();
        }
    }
}
