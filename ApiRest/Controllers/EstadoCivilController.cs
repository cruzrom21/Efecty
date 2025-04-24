using Domain;
using Microsoft.AspNetCore.Mvc;
using UsuarioServices.Interface;

namespace ApíPruebaEfecty.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstadoCivilController : Controller
	{
		private IEstadoCivilServices _estadoCivilServices;

		public EstadoCivilController(IEstadoCivilServices estadoCivilServices)
		{
			_estadoCivilServices = estadoCivilServices;
		}

		[HttpGet]
		public ActionResult<List<EstadoCivil>> AllEstados()
		{
			try
			{
				return _estadoCivilServices.AllEstados();
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}
	}
}
