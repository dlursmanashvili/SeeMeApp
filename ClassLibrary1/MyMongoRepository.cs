using MongoDB.Driver;
using SeeMeDataAccess.DBAdcess;
using SeeMeDataAccess.Models;
using SeeMeDataAccess;

public class MyMongoRepository : IMyMongoRepository
{
    private readonly MyMongoDbContext _context;

    public MyMongoRepository(MyMongoDbContext context)
    {
        _context = context;
    }

    public void Insert(User document)
    {
        document.Id = Guid.NewGuid().ToString();
        _context.Users.InsertOne(document);
    }

    public void Update(User document)
    {
        var filter = Builders<User>.Filter.Eq(x => x.Id, document.Id);
        _context.Users.ReplaceOne(filter, document);
    }

    public List<User> GetAll()
    {
        return _context.Users.Find(_ => true).ToList();
    }
}
