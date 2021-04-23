using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer.Api.CrossCutting.IOC
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeciesRepository(IServiceCollection serviceCollaction)
        {
            serviceCollaction.AddScoped(typeof(Homer.Api.Domain.Interface.Repository.Imoveis.IImovelRepository),
                typeof(Homer.Api.Data.Repository.Imoveis.ImovelRepository));

            serviceCollaction.AddScoped(typeof(Homer.Api.Domain.Interface.Repository.Sistema.ILogSistemaRepository),
                typeof(Homer.Api.Data.Repository.Sistema.LogSistemaRepository));
        }
    }
}
