using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravel.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string UserName { get; set; } // Full Name
        public string Title { get; set; } // Örn: CEO of Red Button
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }
}