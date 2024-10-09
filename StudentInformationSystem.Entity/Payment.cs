namespace StudentInformationSystem.Entity
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVVSecurityCode { get; set; }
    }
}
