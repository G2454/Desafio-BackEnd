using LocacaoMoto.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoMoto.Services
{
    public class EntregadoresService : IEntregadoresService
    {
        private readonly ModelsContext _ModelsContext;
        private readonly string _cnhFolderPath;

        public EntregadoresService(ModelsContext modelsContext)
        {
            _ModelsContext = modelsContext;

            _cnhFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "cnh");
            if (!Directory.Exists(_cnhFolderPath))
                Directory.CreateDirectory(_cnhFolderPath);
        }

        public void AddEntregadores(Entregadores newEntregadores)
        {
            if (string.IsNullOrEmpty(newEntregadores.Id))
                newEntregadores.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

            _ModelsContext.Entregadores.Add(newEntregadores);
            _ModelsContext.SaveChanges();
        }

        public void AddCNHPhotoEntregadores(string identificador, byte[] cnhPhoto)
        {
            var entregador = _ModelsContext.Entregadores.FirstOrDefault(e => e.Identificador == identificador);
            if (entregador == null)
                throw new ArgumentException("Entregador não encontrado");

            if (cnhPhoto == null || cnhPhoto.Length == 0)
                throw new ArgumentException("Arquivo da CNH inválido");

            var fileName = $"{Guid.NewGuid()}.png";
            var filePath = Path.Combine(_cnhFolderPath, fileName);
            File.WriteAllBytes(filePath, cnhPhoto);

            entregador.Imagem_cnh = $"/uploads/cnh/{fileName}";

            _ModelsContext.Entregadores.Update(entregador);
            _ModelsContext.SaveChanges();
        }

        public Entregadores? GetEntregadorByIdentificador(string identificador)
        {
            return _ModelsContext.Entregadores
                .AsNoTracking() // evita tracking para leitura
                .FirstOrDefault(e => e.Identificador == identificador);
        }
    }
}
