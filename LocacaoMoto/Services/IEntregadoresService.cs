using LocacaoMoto.Models;

namespace LocacaoMoto.Services
{
    public interface IEntregadoresService
    {
        Entregadores? GetEntregadorByIdentificador(string identificador);

        void AddEntregadores(Entregadores newEntregadores);

        void AddCNHPhotoEntregadores(string identificador, byte[] cnhPhoto);
    }
}
