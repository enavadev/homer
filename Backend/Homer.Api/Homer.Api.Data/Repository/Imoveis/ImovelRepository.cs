using Homer.Api.Data.Context;
using Homer.Api.Domain.Entities.Imoveis;
using Homer.Api.Domain.Interface.Repository.Imoveis;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

namespace Homer.Api.Data.Repository.Imoveis
{
    
    public class ImovelRepository : BaseContext, IImovelRepository
    {
        public ImovelRepository(IHttpContextAccessor iHttpContextAccessor) : base(iHttpContextAccessor) { }

        public async Task<IEnumerable<Imovel>> ListaDeImoveis()
        {
            try
            {
                using (var conn = OpenConnection())
                {

                    var ret = await conn.GetAllAsync<Imovel>();

                    return ret;

                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return null;
        }

        public async Task<IEnumerable<Imovel>> ObterTodos()
        {
            IEnumerable<Imovel> Retorno = null;
            try
            {
                using (var db = OpenConnection())
                {
                    string sql = @"select * from Imovel i
                                   left join ImovelImagem ii 
	                                    on (i.Id = ii.ImovelId)";

                    var imovelDic = new Dictionary<int, Imovel>();

                    Retorno = (await db.QueryAsync<Imovel, ImovelImagem, Imovel>(sql,
                        (_I, _Ii) =>
                        {
                            Imovel imovel;
                            if (!imovelDic.TryGetValue(_I.Id, out imovel))
                            {
                                imovel = _I;
                                imovel.Imagens = new List<ImovelImagem>();
                                imovelDic.Add(imovel.Id, imovel);
                            }
                            imovel.Imagens.Add(_Ii);
                            return imovel;
                        }, new { }, splitOn: "Id")).Distinct().ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}", e.Message); 
            }
            return Retorno;
        }

    }
}
