using Microsoft.EntityFrameworkCore;
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
            Student? student = _context.Students
                .Include(i => i.Address)
                .Include(i => i.PaymentDetails)
                .Include(i => i.StudentTeachers)
                .FirstOrDefault(i => i.StudentID == id);
            return student;
        }

        public void Update(Student entity) // update student profile information
        {

            Student? studentEntity = _context.Students
                .Include(s => s.Address)
                .Include(s => s.PaymentDetails)
                .FirstOrDefault(i => i.StudentID == entity.StudentID);

            if (entity.Phone != null && entity.Phone != studentEntity.Phone)
            {
                studentEntity.Phone = studentEntity.Phone;
            }
            if (entity.ParentPhone != null && entity.ParentPhone != studentEntity.ParentPhone)
            {
                studentEntity.ParentPhone = studentEntity.ParentPhone;
            }
            if (entity.EducationLevel != null && entity.EducationLevel != studentEntity.EducationLevel)
            {
                studentEntity.EducationLevel = entity.EducationLevel;
            }
            if (entity.Address != null && studentEntity.Address != entity.Address) // update student Address
            {
                if (studentEntity.Address == null)
                {
                    studentEntity.Address = new Address
                    {
                        Country = entity.Address.Country,
                        City = entity.Address.City,
                        ZipCode = entity.Address.ZipCode,
                        AddressDetails = entity.Address.AddressDetails,
                        StudentID = entity.StudentID
                    };
                }
                else
                {
                    if (entity.Address.Country != null && entity.Address.Country != studentEntity.Address.Country)
                    {
                        studentEntity.Address.Country = entity.Address.Country;
                    }
                    if (entity.Address.City != null && entity.Address.City != studentEntity.Address.City)
                    {
                        studentEntity.Address.City = entity.Address.City;
                    }
                    if (entity.Address.ZipCode != studentEntity.Address.ZipCode && entity.Address.ZipCode != 0)
                    {
                        studentEntity.Address.ZipCode = entity.Address.ZipCode;
                    }
                    if (entity.Address.AddressDetails != null && entity.Address.AddressDetails != studentEntity.Address.AddressDetails)
                    {
                        studentEntity.Address.AddressDetails = entity.Address.AddressDetails;
                    }
                }

            }
            if (entity.PaymentDetails != null && studentEntity.PaymentDetails != entity.PaymentDetails) // update payment details
            {
                if (studentEntity.PaymentDetails == null)
                {
                    studentEntity.PaymentDetails = new Payment
                    {
                        CardholderName = entity.PaymentDetails.CardholderName,
                        CardNumber = entity.PaymentDetails.CardNumber,
                        CVVSecurityCode = entity.PaymentDetails.CVVSecurityCode,
                        ExpirationDate = entity.PaymentDetails.ExpirationDate,
                        StudentID = entity.StudentID
                    };
                }
                else
                {
                    if (entity.PaymentDetails.CardholderName != null && entity.PaymentDetails.CardholderName != studentEntity.PaymentDetails.CardholderName)
                    {
                        studentEntity.PaymentDetails.CardholderName = entity.PaymentDetails.CardholderName;
                    }
                    if (entity.PaymentDetails.CardNumber != null && entity.PaymentDetails.CardNumber != studentEntity.PaymentDetails.CardNumber)
                    {
                        studentEntity.PaymentDetails.CardNumber = entity.PaymentDetails.CardNumber;
                    }
                    if (entity.PaymentDetails.CVVSecurityCode != studentEntity.PaymentDetails.CVVSecurityCode)
                    {
                        studentEntity.PaymentDetails.CVVSecurityCode = entity.PaymentDetails.CVVSecurityCode;
                    }


                    if (entity.PaymentDetails.ExpirationDate != null && entity.PaymentDetails.ExpirationDate != studentEntity.PaymentDetails.ExpirationDate)
                    {
                        studentEntity.PaymentDetails.ExpirationDate = entity.PaymentDetails.ExpirationDate;
                    }
                    studentEntity.PaymentDetails.StudentID = entity.StudentID;
                }

            }
            _context.SaveChanges();
        }


    }
}
