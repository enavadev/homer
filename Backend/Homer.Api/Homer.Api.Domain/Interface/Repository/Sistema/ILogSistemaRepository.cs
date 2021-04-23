using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer.Api.Domain.Interface.Repository.Sistema
{
    public interface ILogSistemaRepository
    {
        void GravarLogErro(Exception errorModel);
    }
}
