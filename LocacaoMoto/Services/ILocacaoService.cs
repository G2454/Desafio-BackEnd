using MongoDB.Bson;
using LocacaoMoto.Models;

namespace LocacaoMoto.Services
{
    public interface ILocacaoService
    {
        Locacao? GetLocacaoByIdentificador(string identificador);

        void AddLocacao(Locacao newLocacao);

        void ReturnLocacao(string identificador, byte[] data_devolucao);

    }
}