using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface IAddressRepository
    {
        void AddAddress(Address address);
        void UpdateAddress(Address address);

    }
}
