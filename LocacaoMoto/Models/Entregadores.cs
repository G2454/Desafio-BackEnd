using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.EntityFrameworkCore;

namespace LocacaoMoto.Models
{
    [Collection ("entregadores")]
    public class Entregadores
    {
        //Unique ID generated for MongoDB (not returned in API calls) 
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        // Identifier for the delivery worker (returned in API calls)
        [Required(ErrorMessage = "You must provide an identifier")]
        public string? Identificador { get; set; }

        [Required(ErrorMessage = "You must provide a name ")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "You must provide the cnpj ")]
        public string? Cnpj { get; set; }

        [Required(ErrorMessage = "You must provide the birthdate")]
        public string? Data_nascimento { get; set; }

        [Required(ErrorMessage = "You must provide the cnh identifier")]
        public string? Numero_cnh { get; set; }

        [Required(ErrorMessage = "You must provide the cnh type")]
        public string? Tipo_cnh { get; set; }
        [Required(ErrorMessage = "You must provide the cnh image path")]
        public string? Imagem_cnh { get; set; } // Ex: "/uploads/cnh/xxx.png"
    }
}
