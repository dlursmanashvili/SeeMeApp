using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SeeMeDataAccess.Models;

public class User
{
    [BsonId]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("HeightCm")]
    public int HeightCm { get; set; }
}
