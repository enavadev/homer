using System.Collections.Generic;
using System.Threading.Tasks;
using Homer.Api.Domain.Entities.Imoveis;

namespace Homer.Api.Domain.Interface.Repository.Imoveis
{

    public interface IImovelRepository
    {
        Task<IEnumerable<Imovel>> ListaDeImoveis();
        Task<IEnumerable<Imovel>> ObterTodos();
    }
}
