using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homer.Api.CrossCutting.IOC
{
    public class ConfigureService
    {
        public static void ConfigureDependeciesService(IServiceCollection serviceCollaction)
        {
            serviceCollaction.AddTransient<Homer.Api.Domain.Service.Imoveis.IImovelService,
                Homer.Api.Service.Imoveis.ImovelService>();

            serviceCollaction.AddTransient< Homer.Api.Domain.Service.Sistema.ILogSistemaService,
                Homer.Api.Service.Sistema.LogSistemaService>();
        }
    }
}
