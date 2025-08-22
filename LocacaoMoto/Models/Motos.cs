using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LocacaoMoto.Models
{
    [Collection("motos")]
    public class Motos
    {
        //Unique ID generated for MongoDB (not returned in API calls) 
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        //Motorcycle identifier (returned in API calls)
        [Required(ErrorMessage = "You must provide an identifier")]
        public string? identificador { get; set; }

        [Required(ErrorMessage = "You must provide the year")]
        [Range(2015, 2100, ErrorMessage = "Year must be between 2015 and 2100")]
        public int ano { get; set; }

        [Required(ErrorMessage = "You must provide the motorcycle model")]
        public string? modelo { get; set; }

        [Required(ErrorMessage = "You must provide the license plate")]
        public string? placa { get; set; }
    }
}
