using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer.Api.Domain.Service.Sistema
{
    public interface ILogSistemaService
    {
        void GravarLogErro(Exception errorModel);
    }
}
