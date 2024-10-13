using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCoreAddressRepository : IAddressRepository
    {
        SISContext _context;
        public EfCoreAddressRepository(SISContext context)
        {
            _context = context;
        }
        public void AddAddress(Address address)
        {
            _context.Addresses.Add(address);
        }


        public void UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
        }
    }
}
