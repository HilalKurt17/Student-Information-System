﻿using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class TeacherViewModel
    {
        // used in adminController to create all teacher cards
        // used in studentController to list all lessons of teachers(get private lessons through list of teachers)
        public List<Teacher> teachers { get; set; }
        public List<LessonDTO> lessons { get; set; }
    }
}
