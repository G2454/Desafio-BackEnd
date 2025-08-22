using System.ComponentModel.DataAnnotations;

namespace LocacaoMoto.Models
{
    public class CreateMotoDto
    {
        [Required(ErrorMessage = "You must provide an identifier")]
        public string identificador { get; set; }

        [Required(ErrorMessage = "You must provide the year")]
        [Range(1900, 2100)]
        public int ano { get; set; }

        [Required(ErrorMessage = "You must provide the motorcycle model")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "You must provide the license plate")]
        public string placa { get; set; }
    }
}
