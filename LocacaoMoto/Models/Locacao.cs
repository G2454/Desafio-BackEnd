using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LocacaoMoto.Models
{
    [Collection("locacao")]
    public class Locacao
    {
        //Unique ID generated for MongoDB (not returned in API calls) 
        [BsonId]         
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        // Identifier for the delivery worker (returned in API calls)
        [Required(ErrorMessage = "You must provide an identifier")]
        public string? entregador_id { get; set; }

        [Required(ErrorMessage = "You must provide the motorcycle identifier")]
        public string? moto_id { get; set; }

        [Required(ErrorMessage = "You must provide the start date")]
        public string? data_inicio { get; set; }

        [Required(ErrorMessage = "You must provide the end date")]
        public string? data_termino { get; set; }

        [Required(ErrorMessage = "You must provide the expected end date")]
        public string? data_previsao_termino { get; set; }

        [Required(ErrorMessage = "You must provide the plan")]
        public string? plano { get; set; }
    }
}
