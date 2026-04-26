using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartTracker.Api.Models;

public class TodoTask
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = "Todo"; // Todo, InProgress, Done
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}