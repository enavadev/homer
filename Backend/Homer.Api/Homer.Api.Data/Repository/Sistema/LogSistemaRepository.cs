using Homer.Api.Data.Context;
using Homer.Api.Domain.Interface.Repository.Sistema;
using Microsoft.AspNetCore.Http;
using System;


namespace Homer.Api.Data.Repository.Sistema
{
    public class LogSistemaRepository : BaseContext, ILogSistemaRepository
    {
        public LogSistemaRepository(IHttpContextAccessor iHttpContextAccessor) : base(iHttpContextAccessor) { }

        public void GravarLogErro(Exception errorModel)
        {
            //implemente aqui log de erros

            throw new NotImplementedException();
        }
    }
}
