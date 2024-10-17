using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface ILessonRepository
    {
        Lesson? GetById(int id);
        List<LessonDTO> GetAllT();
        void Add(Lesson entity);
        void Update(Lesson entity);
        void Delete(int id);
    }
}
