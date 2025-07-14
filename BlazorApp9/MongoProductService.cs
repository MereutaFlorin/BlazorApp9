using MongoDB.Driver;

public class MongoProductService
{
    private readonly IMongoCollection<Product> _products;

    public MongoProductService(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        var db = client.GetDatabase("MyAppDb");
        _products = db.GetCollection<Product>("Products");
    }

    public async Task<List<Product>> GetAllAsync() => await _products.Find(_ => true).ToListAsync();
    public async Task<Product> GetByIdAsync(Guid id) => await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Product product) => await _products.InsertOneAsync(product);
    public async Task UpdateAsync(Product product) => await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
    public async Task DeleteAsync(Guid id) => await _products.DeleteOneAsync(p => p.Id == id);
}