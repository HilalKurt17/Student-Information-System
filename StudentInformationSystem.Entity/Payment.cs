namespace StudentInformationSystem.Entity
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int CVVSecurityCode { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
