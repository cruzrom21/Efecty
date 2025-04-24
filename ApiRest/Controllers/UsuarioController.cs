using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using UsuarioServices;
using UsuarioServices.Interface;

namespace ApíPruebaEfecty.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private IUsuariosServices _usuarioServices;

		public UsuarioController(IUsuariosServices usuarioServices)
		{
			_usuarioServices = usuarioServices;
		}

		[HttpGet]
		public ActionResult<List<Usuario>> AllUsers()
		{
			try
			{
				return _usuarioServices.AllUsers();
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpPost]
		public ActionResult<bool> CrearUser(UsuarioDTO usuario)
		{
			try
			{
				return _usuarioServices.CrearUser(usuario);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpPut]
		public ActionResult<bool> EditarUser(UsuarioDTO usuario)
		{
			try
			{
				return _usuarioServices.EditarUser(usuario);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public ActionResult<bool> Delete(int id)
		{
			try
			{
				return _usuarioServices.EliminarUser(id);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(ex.Message);
			}
		}
	}
}
