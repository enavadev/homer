using Homer.Api.Domain.Entities.Imoveis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homer.Api.Domain.Service.Imoveis
{
    public interface IImovelService
    {
        Task<IEnumerable<Imovel>> ListaDeImoveis();
        Task<IEnumerable<Imovel>> ObterTodos();
    }
}
