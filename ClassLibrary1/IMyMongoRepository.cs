using SeeMeDataAccess.Models;

namespace SeeMeDataAccess
{
    public interface IMyMongoRepository
    {
        void Insert(User document);
        void Update(User document);
        List<User> GetAll();
    }
}
