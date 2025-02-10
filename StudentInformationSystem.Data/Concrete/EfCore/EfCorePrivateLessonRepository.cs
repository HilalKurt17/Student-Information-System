using Microsoft.EntityFrameworkCore;
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
            List<Assignment> assignments = _context.Assignments.Where(i => i.privateLessonID == id).ToList();
            if (privateLesson != null)
            {
                _context.StudentTeachers.Remove(privateLesson);
            }
            if (assignments.Count > 0)
            {
                foreach (Assignment assignment in assignments)
                {
                    _context.Assignments.Remove(assignment);
                }
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
            _context.Entry(updatedEntity).State = EntityState.Detached;

            StudentTeacher oldEntity = _context.StudentTeachers.FirstOrDefault(i => i.PrivateLessonID == updatedEntity.PrivateLessonID)!;

            if (updatedEntity.StudentID != null && updatedEntity.StudentID != oldEntity.StudentID)
            {
                oldEntity.StudentID = updatedEntity.StudentID;
            }
            if (updatedEntity.ELClassification != null && updatedEntity.ELClassification != oldEntity.ELClassification)
            {
                oldEntity.ELClassification = updatedEntity.ELClassification;
            }
            if (updatedEntity.LessonMode != null && updatedEntity.LessonMode != oldEntity.LessonMode)
            {
                oldEntity.LessonMode = updatedEntity.LessonMode;
            }
            if (updatedEntity.LessonDate != null && updatedEntity.LessonDate != oldEntity.LessonDate)
            {
                oldEntity.LessonDate = updatedEntity.LessonDate;
            }
            if (updatedEntity.LessonName != null && updatedEntity.LessonName != oldEntity.LessonName)
            {
                oldEntity.LessonName = updatedEntity.LessonName;
            }
            if (updatedEntity.LessonEndDate != null && updatedEntity.LessonEndDate != oldEntity.LessonEndDate)
            {
                oldEntity.LessonEndDate = updatedEntity.LessonEndDate;
            }
            if (updatedEntity.LessonStartDate != null && updatedEntity.LessonStartDate != oldEntity.LessonStartDate)
            {
                oldEntity.LessonStartDate = updatedEntity.LessonStartDate;
            }
            if (updatedEntity.LessonEndTime != null && updatedEntity.LessonEndTime != oldEntity.LessonEndTime)
            {
                oldEntity.LessonEndTime = updatedEntity.LessonEndTime;
            }
            if (updatedEntity.LessonStartTime != null && updatedEntity.LessonStartTime != oldEntity.LessonStartTime)
            {
                oldEntity.LessonStartTime = updatedEntity.LessonStartTime;
            }
            if (updatedEntity.LessonDetails != null && updatedEntity.LessonDetails != oldEntity.LessonDetails)
            {
                oldEntity.LessonDetails = updatedEntity.LessonDetails;
            }
            if (updatedEntity.LessonPrice != null && updatedEntity.LessonPrice != oldEntity.LessonPrice)
            {
                oldEntity.LessonPrice = updatedEntity.LessonPrice;
            }
            oldEntity.GetScoreComment = updatedEntity.GetScoreComment;

            _context.StudentTeachers.Update(oldEntity);
            _context.SaveChanges();
        }



    }
}
