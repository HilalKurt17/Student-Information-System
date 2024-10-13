using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class EfCorePaymentDetailsRepository : IPaymentDetailsRepository
    {
        SISContext _context;
        public EfCorePaymentDetailsRepository(SISContext context)
        {
            _context = context;
        }
        public void AddCreditCard(Payment entity)
        {
            _context.PaymentDetails.Add(entity);
        }

        public void UpdateCreditCard(Payment entity)
        {
            _context.PaymentDetails.Update(entity);
        }
    }
}
