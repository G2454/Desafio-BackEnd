using System.ComponentModel.DataAnnotations;

namespace LocacaoMoto.Models
{
    public class EntregadorResponse
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Data_nascimento { get; set; }
        public string Numero_cnh { get; set; }
        public string? Tipo_cnh { get; set; }
        public string? Imagem_cnh { get; set; }
    }
}