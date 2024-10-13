namespace StudentInformationSystem.Entity
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string AddressDetails { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
