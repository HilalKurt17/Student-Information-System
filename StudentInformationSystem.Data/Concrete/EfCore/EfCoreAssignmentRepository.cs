using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCoreAssignmentRepository : IAssignmentRepository
    {
        SISContext _context;
        public EfCoreAssignmentRepository(SISContext context)
        {
            _context = context;
        }
        public void Add(Assignment entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id) // delete the assignment
        {
            Assignment assignment = _context.Assignments.FirstOrDefault(i => i.AssignmentID == id)!;
            _context.Assignments.Remove(assignment);
            _context.SaveChanges();
        }

        public List<Assignment> GetAllT()
        {
            return _context.Assignments.ToList();
        }

        public Assignment? GetById(int id)
        {
            return _context.Assignments.FirstOrDefault(i => i.AssignmentID == id);
        }

        public void Update(Assignment entity)
        {
            Assignment oldAssignment = _context.Assignments.FirstOrDefault(i => i.AssignmentID == entity.AssignmentID)!;
            if (entity.Type != oldAssignment.Type)
            {
                oldAssignment.Type = entity.Type;
            }
            if (entity.StudentID != oldAssignment.StudentID)
            {
                oldAssignment.StudentID = entity.StudentID;
            }
            if (entity.privateLessonID != oldAssignment.privateLessonID)
            {
                oldAssignment.privateLessonID = entity.privateLessonID;
            }
            if (entity.Subject != oldAssignment.Subject)
            {
                oldAssignment.Subject = entity.Subject;
            }
            if (entity.Explanation != oldAssignment.Explanation)
            {
                oldAssignment.Explanation = entity.Explanation;
            }
            if (entity.DueDate != oldAssignment.DueDate)
            {
                oldAssignment.DueDate = entity.DueDate;
            }
            if (entity.DueTime != oldAssignment.DueTime)
            {
                oldAssignment.DueTime = entity.DueTime;
            }
            if (entity.TeacherAssignmentFilePath != oldAssignment.TeacherAssignmentFilePath && entity.TeacherAssignmentFilePath != null && entity.TeacherAssignmentFilePath != "")
            {
                oldAssignment.TeacherAssignmentFilePath = entity.TeacherAssignmentFilePath;
            }
            oldAssignment.UpdatedDate = entity.UpdatedDate;
            oldAssignment.UpdatedTime = entity.UpdatedTime;
            _context.SaveChanges();
        } // update required fields in an assignment 

        // update assignment when student submit the assignment solution
        public void SubmitAssignment(Assignment assignment)
        {
            Assignment oldAssignment = GetById(assignment.AssignmentID)!;

            if (assignment.StudentAssignmentFilePath != null && assignment.StudentAssignmentFilePath != "")
            {
                oldAssignment.StudentAssignmentFilePath = assignment.StudentAssignmentFilePath;
            }
            if (assignment.SubmittedDate != null && assignment.SubmittedDate != oldAssignment.SubmittedDate && assignment.SubmittedDate != "")
            {
                oldAssignment.SubmittedDate = assignment.SubmittedDate;
            }
            if (assignment.SubmittedTime != null && assignment.SubmittedTime != oldAssignment.SubmittedTime && assignment.SubmittedDate != "")
            {
                oldAssignment.SubmittedTime = assignment.SubmittedTime;
            }
            oldAssignment.IsCompleted = true;
            _context.SaveChanges();

        }

        // update assignment when teacher grade it 
        public void GradeAssignment(Assignment assignment)
        {
            Assignment oldAssignment = GetById(assignment.AssignmentID)!;
            oldAssignment.Grade = assignment.Grade;
            oldAssignment.FailedTopics = assignment.FailedTopics;
            oldAssignment.IsGraded = true;
            _context.SaveChanges();
        }
    }
}
