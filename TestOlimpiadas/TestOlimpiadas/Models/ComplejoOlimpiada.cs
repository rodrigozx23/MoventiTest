namespace TestOlimpiadas.Models
{
    public class ComplejoOlimpiada
    {
        public int Id { get; set; }
        public int SedeId { get; set; }
        public int TipoComplejo { get; set; }
        public string Localizacion { get; set; }
        public string JefeOrganizacion { get; set; }
        public int AreaTotalOcupada { get; set; }
    }
}
