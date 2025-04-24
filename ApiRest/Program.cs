
using DataBase;
using Microsoft.EntityFrameworkCore;
using UsuarioServices.Interface;
using UsuarioServices;

namespace PruebaEfecty
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<PruebaEfectyContext>(options =>
			   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins", builder =>
					builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			});

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IEstadoCivilServices, EstadoCivilServices>();
			builder.Services.AddScoped<ITipoDocumentoServices, TipoDocumentoServices>();
			builder.Services.AddScoped<IUsuariosServices, UsuariosServices>();

			var app = builder.Build();

			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseCors("AllowAllOrigins");

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
