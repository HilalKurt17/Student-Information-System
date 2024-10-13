using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Entity
{
    public class References
    {
        [Key]
        public int ReferencesID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string CurrentPosition { get; set; }
        public bool IsApproved { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

    }
}
