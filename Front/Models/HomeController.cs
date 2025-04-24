using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using VistaPruebaEfecty.Models;

namespace VistaPruebaEfecty.Controllers
{
	public class HomeController : Controller
	{
		private HttpClient _httpClient;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
		{
			_logger = logger;
            _httpClient = httpClient;
        }

		public async Task<IActionResult> Index()
		{
            var responsetipoDocumento = await _httpClient.GetAsync("https://localhost:44382/api/TipoDocumento");
            var responseEstadoCivil = await _httpClient.GetAsync("https://localhost:44382/api/EstadoCivil");

            if (responsetipoDocumento.IsSuccessStatusCode)
            {
                var jsonTipo = responsetipoDocumento.Content.ReadAsStream();
                var jsonEstado = responseEstadoCivil.Content.ReadAsStream();

                var tipoDocumneto = JsonSerializer.Deserialize<List<TipoDocumento>>(jsonTipo, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var estadoCivil = JsonSerializer.Deserialize<List<EstadoCivil>>(jsonEstado, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var viewModel = new
                {
                    tipoDocumentos = tipoDocumneto,
                    estadoCivil = estadoCivil,
                };

                return View(viewModel);
            }

            return View();
		}

        public async Task<string> EnviarUsuario(Usuario usuario)
        {
            string json = JsonSerializer.Serialize(usuario); 

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var responseCrearUsuario = await _httpClient.PostAsync("https://localhost:44382/api/Usuario", content);

            if (responseCrearUsuario.IsSuccessStatusCode)
            {
                var jsonTipo = responseCrearUsuario.Content.ReadAsStringAsync();
            }

            return "Creado";
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
