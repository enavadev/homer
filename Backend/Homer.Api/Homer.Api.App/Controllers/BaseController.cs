using Homer.Api.Domain.Service.Sistema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Homer.Api.App.Controllers
{
    public class BaseController : ControllerBase
    {
        ILogSistemaService _iLogSistemaService;

        public BaseController(IHttpContextAccessor httpContextAccessor, ILogSistemaService iLogSistemaService)
        {
            _iLogSistemaService = iLogSistemaService;
        }

        public ObjectResult RetornarErroInterno(Exception ex, string metodo)
        {
            string mensagemErro = ex.Message;

            _iLogSistemaService.GravarLogErro(ex); 

            return StatusCode((int)HttpStatusCode.InternalServerError, mensagemErro);
        }
    }
}
