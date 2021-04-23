using Homer.Api.Domain.Entities.Imoveis;
using Homer.Api.Domain.Entities.Sistema;
using Homer.Api.Domain.Service.Imoveis;
using Homer.Api.Domain.Service.Sistema;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Homer.Api.App.Controllers
{
    [EnableCors("PolicyCORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : BaseController
    {
        private readonly ILogSistemaService _iLogSistemaService;
        private readonly IImovelService _ImovelService;
        private ResponseResult<Imovel> _response = new ResponseResult<Imovel>();
        public ImoveisController(IHttpContextAccessor iHttpContextAccessor, ILogSistemaService iLogSistemaService, IImovelService ImovelService)
             : base(iHttpContextAccessor, iLogSistemaService)
        {
            _ImovelService = ImovelService;
            _iLogSistemaService = iLogSistemaService;
        }
        [HttpPost("ListaDosImoveis")]
        public async Task<IActionResult> ListaDosImoveis()
        {
            try
            {
                var retorno = await _ImovelService.ListaDeImoveis();
                
                _response.ListEntities = retorno;
                _response.Success = true;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = "Não foi possível obter a lista dos imoveis, devido a um erro interno do servidor. Contate o suporte p/maiores informações.";
            }

            return Ok(_response);
        }
        [HttpPost("ObterTodos")]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var retorno = await _ImovelService.ObterTodos();

                _response.ListEntities = retorno;
                _response.Success = true;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = "Não foi possível obter todos os imoveis, devido a um erro interno do servidor. Contate o suporte p/maiores informações.";
            }

            return Ok(_response);
        }
    }
}
