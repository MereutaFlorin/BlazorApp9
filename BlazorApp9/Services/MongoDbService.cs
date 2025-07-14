using MongoDB.Driver;

public class MongoDbService
{
    private readonly IMongoCollection<User> _users;

    public MongoDbService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
        var database = client.GetDatabase("MyAppDb");
        _users = database.GetCollection<User>("Users");
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _users.Find(_ => true).ToListAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _users.InsertOneAsync(user);
    }
}