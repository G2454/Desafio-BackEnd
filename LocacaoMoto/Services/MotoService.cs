using Microsoft.EntityFrameworkCore;
using LocacaoMoto.Models;

namespace LocacaoMoto.Services
{
    public class MotoServices : IMotosService
    {
        private readonly ModelsContext _ModelsContext;

        public MotoServices(ModelsContext ModelsContext)
        {
            _ModelsContext = ModelsContext;
        }

        public void AddMoto(Motos motos)
        {
            if (string.IsNullOrEmpty(motos.Id))
                motos.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

            _ModelsContext.Motos.Add(motos);
            _ModelsContext.SaveChanges();
        }

        public void EditMotoByIdentificador(Motos updatedMoto)
        {
            var motoToUpdate = _ModelsContext.Motos.FirstOrDefault(c => c.identificador == updatedMoto.identificador);
            if (motoToUpdate == null)
                throw new ArgumentException("The motorcycle to update cannot be found");

            motoToUpdate.ano = updatedMoto.ano;
            motoToUpdate.modelo = updatedMoto.modelo;
            motoToUpdate.placa = updatedMoto.placa;

            _ModelsContext.Motos.Update(motoToUpdate);
            _ModelsContext.SaveChanges();
        }

        public void DeleteMotoByIdentificador(Motos motos)
        {
            var motosToDelete = _ModelsContext.Motos.FirstOrDefault(c => c.identificador == motos.identificador);
            if (motosToDelete == null)
                throw new ArgumentException("The motorcycle to delete cannot be found");

            _ModelsContext.Motos.Remove(motosToDelete);
            _ModelsContext.SaveChanges();
        }

        public IEnumerable<Motos> GetAllMotos()
        {
            return _ModelsContext.Motos
                .OrderBy(c => c.identificador)
                .Take(20)
                .AsNoTracking()
                .AsEnumerable();
        }

        public Motos? GetMotoByIdentificador(string identificador)
        {
            return _ModelsContext.Motos.FirstOrDefault(c => c.identificador == identificador);
        }
    }
}
