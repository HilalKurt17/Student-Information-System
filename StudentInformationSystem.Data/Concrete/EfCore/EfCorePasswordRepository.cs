using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCorePasswordRepository : IPasswordRepository
    {
        private SISContext _context;
        public EfCorePasswordRepository(SISContext context)
        {
            _context = context;
        }

        public void Add(Passwords entity)
        {
            _context.Passwords.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Passwords password = _context.Passwords.FirstOrDefault(i => i.PasswordsID == id);
            _context.Passwords.Remove(password);
            _context.SaveChanges();
        }

        public List<Passwords> GetAllT()
        {
            return _context.Passwords.ToList();
        }

        public Passwords? GetById(int id)
        {
            return _context.Passwords.FirstOrDefault(i => i.PasswordsID == id);
        }

        public void Update(Passwords entity)
        {
            Passwords password = _context.Passwords.FirstOrDefault(i => i.PasswordsID == entity.PasswordsID);
            password.Password = entity.Password;
            _context.SaveChanges();
        }
    }
}
