
using Docket_Eagle.Models;
using Docket_Eagle.Repositories;
using MongoDB.Driver;

public class UserRepository :IUserRepository
{
    private readonly IMongoCollection<User> _collection;

    public UserRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<User>("User");
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<User> GetByIdAsync(string id)
    {
        return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _collection.Find(e => e.Email == email).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(User entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, User entity)
    {
        await _collection.ReplaceOneAsync(e => e.Id == id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(e => e.Id == id);
    }
    public async Task MarkAsPaid(string id)
    {
        var update = Builders<User>.Update.Set(u => u.PaymentStatus, true);
        await _collection.UpdateOneAsync(e => e.Id == id, update);
    }
    public async Task ActivateUser(string id)
    {
        var update = Builders<User>.Update.Set(u => u.Status,true);
        await _collection.UpdateOneAsync(e => e.Id == id, update);
    }

    public async Task DeactivateUser(string id)
    {
        var update = Builders<User>.Update.Set(u => u.Status, false);
        await _collection.UpdateOneAsync(e => e.Id == id, update);
    }
}