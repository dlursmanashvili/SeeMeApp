using MongoDB.Driver;
using SeeMeDataAccess;
using SeeMeDataAccess.DBAdcess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Read the configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
builder.Services.AddScoped<IMyMongoRepository, MyMongoRepository>();

// Add MongoDB database context
builder.Services.AddSingleton(sp => new MongoClient(configuration.GetConnectionString("MongoDB")));
builder.Services.AddScoped(sp => new MyMongoDbContext(configuration));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
