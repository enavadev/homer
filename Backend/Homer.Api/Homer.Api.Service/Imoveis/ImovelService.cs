using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Homer.Api.Domain.Service.Imoveis;
using Homer.Api.Domain.Interface.Repository.Imoveis;
using Homer.Api.Domain.Entities.Imoveis;

namespace Homer.Api.Service.Imoveis
{
    public class ImovelService: IImovelService
    {
        private IImovelRepository _imovelRepository;

        public ImovelService(IImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }
        public async Task<IEnumerable<Imovel>> ListaDeImoveis() =>
            await _imovelRepository.ListaDeImoveis();

        public async Task<IEnumerable<Imovel>> ObterTodos() =>
            await _imovelRepository.ObterTodos();
    }
}
