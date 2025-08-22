using System.ComponentModel.DataAnnotations;

namespace LocacaoMoto.Models
{
    public class CreateEntregadorDto
    {
        [Required(ErrorMessage = "You must provide an identifier")]
        public string Identificador { get; set; }

        [Required(ErrorMessage = "You must provide a name")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "You must provide the license plate")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "You must provide the date of birth")]
        public string Data_nascimento { get; set; }

        [Required(ErrorMessage = "You must provide the date of birth")]
        public string Numero_cnh { get; set; }

        [Required(ErrorMessage = "You must provide the cnh type")]
        public string? Tipo_cnh { get; set; }
        [Required(ErrorMessage = "You must provide the cnh image path")]
        public string? Imagem_cnh { get; set; } // Ex: "/uploads/cnh/xxx.png"

    }
}
