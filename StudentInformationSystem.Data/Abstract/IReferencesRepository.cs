using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface IReferencesRepository
    {
        void AddReference(References reference);
        void UpdateReference(References reference);
        void DeleteReference(References reference);
    }
}
