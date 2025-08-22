using LocacaoMoto.Models;
using LocacaoMoto.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocacaoMoto.Controllers
{
   [ApiController]
[Route("api/[controller]")]
public class EntregadoresController : ControllerBase
{
    private readonly IEntregadoresService _entregadoresService;

    public EntregadoresController(IEntregadoresService entregadoresService)
    {
        _entregadoresService = entregadoresService;
    }

    [HttpPost]
    public IActionResult AddEntregador([FromBody] CreateEntregadorDto dto)
    {
        var entregador = new Entregadores
        {
            Identificador = dto.Identificador,
            Nome = dto.Nome,
            Cnpj = dto.Cnpj,
            Data_nascimento = dto.Data_nascimento,
            Numero_cnh = dto.Numero_cnh,
            Tipo_cnh = dto.Tipo_cnh,
            Imagem_cnh = dto.Imagem_cnh
        };

        _entregadoresService.AddEntregadores(entregador);

        var response = new EntregadorResponse
        {
            Identificador = entregador.Identificador,
            Nome = entregador.Nome,
            Cnpj = entregador.Cnpj,
            Data_nascimento = entregador.Data_nascimento,
            Numero_cnh = entregador.Numero_cnh,
            Tipo_cnh = entregador.Tipo_cnh,
            Imagem_cnh = entregador.Imagem_cnh
        };

        return Created($"/api/entregadores/{dto.Identificador}", response);
    }

        // Create new delivery worker (POST request)    
    [HttpPost("{identificador}/cnh")]
    [Consumes("multipart/form-data")]
    public IActionResult UploadCnh(string identificador, [FromForm] UploadCnhDto dto)
    {
        if (dto.CnhPhoto == null || dto.CnhPhoto.Length == 0)
            return BadRequest("A foto da CNH é obrigatória.");

    using var ms = new MemoryStream();
    dto.CnhPhoto.CopyTo(ms);
    var cnhBytes = ms.ToArray();

    _entregadoresService.AddCNHPhotoEntregadores(identificador, cnhBytes);

    return Ok("CNH enviada com sucesso.");
}


    [HttpGet("interno/{identificador}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult GetInterno(string identificador)
    {
        var entregador = _entregadoresService.GetEntregadorByIdentificador(identificador);
        if (entregador == null)
            return NotFound();

        var response = new EntregadorResponse
        {
            Identificador = entregador.Identificador,
            Nome = entregador.Nome,
            Cnpj = entregador.Cnpj,
            Data_nascimento = entregador.Data_nascimento,
            Numero_cnh = entregador.Numero_cnh,
            Tipo_cnh = entregador.Tipo_cnh,
            Imagem_cnh = entregador.Imagem_cnh
        };

        return Ok(response);
    }
}

}
