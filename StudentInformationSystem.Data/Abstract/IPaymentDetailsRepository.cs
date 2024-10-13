using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface IPaymentDetailsRepository
    {
        void AddCreditCard(Payment entity);
        void UpdateCreditCard(Payment entity);
    }
}
