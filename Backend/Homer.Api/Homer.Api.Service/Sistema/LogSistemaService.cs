using Homer.Api.Domain.Interface.Repository.Sistema;
using Homer.Api.Domain.Service.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer.Api.Service.Sistema
{
    public class LogSistemaService : ILogSistemaService
    {
        private readonly ILogSistemaRepository _iLogSistemaRepository;
        public LogSistemaService(ILogSistemaRepository iLogSistemaRepository)
        {
            _iLogSistemaRepository = iLogSistemaRepository;
        }
        public void GravarLogErro(Exception errorModel)
        {
            _iLogSistemaRepository.GravarLogErro(errorModel);
        }
    }
}
