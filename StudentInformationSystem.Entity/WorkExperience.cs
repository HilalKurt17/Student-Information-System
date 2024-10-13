namespace StudentInformationSystem.Entity
{
    public class WorkExperience
    {
        public int WorkExperienceID { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string JobDetails { get; set; }
        public bool IsApproved { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }


    }
}
