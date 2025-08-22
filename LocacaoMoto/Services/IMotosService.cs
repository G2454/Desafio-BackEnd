using LocacaoMoto.Models;

namespace LocacaoMoto.Services
{
    public interface IMotosService
    {
        IEnumerable<Motos> GetAllMotos();
        Motos? GetMotoByIdentificador(string identificador);
        void AddMoto(Motos newMoto);
        void EditMotoByIdentificador(Motos updateMoto);
        void DeleteMotoByIdentificador(Motos deleteMoto);
    }
}
