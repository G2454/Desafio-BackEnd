using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using LocacaoMoto.Models;
using LocacaoMoto.Services;

namespace LocacaoMoto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly IMotosService _MotosService;

        public MotosController(IMotosService MotoServices)
        {
            _MotosService = MotoServices;
        }
    [HttpGet]
        public IActionResult GetAll()
        {
            var motos = _MotosService.GetAllMotos()
                .Select(m => new MotosResponseDto
                {
                    identificador = m.identificador,
                    ano = m.ano,
                    modelo = m.modelo,
                    placa = m.placa
                });

            return Ok(motos);
        }

    [HttpGet("{identificador}")]
    public ActionResult<MotosResponseDto> GetByIdentificador(string identificador)
    {
    var moto = _MotosService.GetMotoByIdentificador(identificador);
         if (moto == null) return NotFound(new { message = "Moto não encontrada." });
    var response = new MotosResponseDto
        {
        identificador = moto.identificador,
        ano = moto.ano,
        modelo = moto.modelo,
        placa = moto.placa
        };

        return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateMotoDto dto)
        {
            var moto = new Motos
            {
                Id = ObjectId.GenerateNewId().ToString(),
                identificador = dto.identificador,
                ano = dto.ano,
                modelo = dto.modelo,
                placa = dto.placa
            };

            _MotosService.AddMoto(moto);
            return CreatedAtAction(nameof(GetByIdentificador), new { identificador = moto.identificador }, moto);
        }

        [HttpDelete("{identificador}")]
        public IActionResult Delete(string identificador)
        {
            var existing = _MotosService.GetMotoByIdentificador(identificador);
            if (existing == null) return NotFound();
            _MotosService.DeleteMotoByIdentificador(existing);
            return NoContent();
        }

        [HttpPut("{identificador}")]
        public IActionResult Update(string identificador, CreateMotoDto dto)
        {
            var existing = _MotosService.GetMotoByIdentificador(identificador);
            if (existing == null) return NotFound();

            var updatedMoto = new Motos
            {
                Id = existing.Id,
                identificador = existing.identificador,
                ano = dto.ano,
                modelo = dto.modelo,
                placa = dto.placa
            };

            _MotosService.EditMotoByIdentificador(updatedMoto);
            return NoContent();
        }
    }
}
