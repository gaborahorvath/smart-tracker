using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SmartTracker.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// MongoDB konfiguráció
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoClient>(sp => 
    new MongoClient(builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString")));

builder.Services.AddScoped(sp => {
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName).GetCollection<TodoTask>("Tasks");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

// Minimal API CRUD Végpontok
app.MapGet("/api/tasks", async (IMongoCollection<TodoTask> col) => 
    await col.Find(_ => true).ToListAsync());

app.MapPost("/api/tasks", async (IMongoCollection<TodoTask> col, TodoTask task) => {
    await col.InsertOneAsync(task);
    return Results.Created($"/api/tasks/{task.Id}", task);
});

app.MapPut("/api/tasks/{id}", async (IMongoCollection<TodoTask> col, string id, TodoTask task) => {
    await col.ReplaceOneAsync(t => t.Id == id, task);
    return Results.NoContent();
});

app.MapDelete("/api/tasks/{id}", async (IMongoCollection<TodoTask> col, string id) => {
    await col.DeleteOneAsync(t => t.Id == id);
    return Results.NoContent();
});

app.Run();

// Segédosztály a konfigurációhoz
public class MongoDbSettings {
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}