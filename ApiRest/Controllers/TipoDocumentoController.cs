using Domain;
using Microsoft.AspNetCore.Mvc;
using UsuarioServices.Interface;

namespace ApíPruebaEfecty.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoDocumentoController : ControllerBase
	{
		private ITipoDocumentoServices _tipoDocumentoServices;

		public TipoDocumentoController(ITipoDocumentoServices tipoDocumentoServices)
		{
			_tipoDocumentoServices = tipoDocumentoServices;
		}

		[HttpGet]
		public ActionResult<List<TipoDocumento>> AllTipos()
		{
			try
			{
				return _tipoDocumentoServices.AllTipos();
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}
	}
}
