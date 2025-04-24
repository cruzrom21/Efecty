namespace VistaPruebaEfecty.Models
{
    public class Usuario
    {
        public int IdUser { get; set; }

        public string NombreCompleto { get; set; } = null!;

        public string NumeroDocumento { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public decimal ValorGanar { get; set; }

        public int IdTipoDocumento { get; set; }

        public int IdEstadoCivil { get; set; }
    }
}
