using Redis.OM;
using RedisOM.Model;

// Connect to Redis 
var provider = new RedisConnectionProvider("redis://localhost:6379");

// Initialize Bob
var bob = new CustomerRedis
{
    Age = 35,
    Email = "foo@bar.com",
    FirstName = "Bob",
    LastName = "Smith"
};

// Create the index
provider.Connection.CreateIndex(typeof(CustomerRedis));

// Add a customer
var customers = provider.RedisCollection<CustomerRedis>();
var customerId = await customers.InsertAsync(bob);

// Reading data out of Redis with an Id
var alsoBob = await customers.FindByIdAsync(customerId);

// Reading data out of Redis by Value
var bobsRedisOm = customers.Where(x => x.FirstName == "Bob");
var under65RedisOm = customers.Where(x => x.Age < 65);

// Updating objects in Redis
foreach (var customer in customers)
{
    customer.Age += 1;
}
await customers.SaveAsync();

// Deleting indexed items
provider.Connection.Unlink(customerId);
