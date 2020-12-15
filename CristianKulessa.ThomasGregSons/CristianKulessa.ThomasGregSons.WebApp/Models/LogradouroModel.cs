namespace CristianKulessa.ThomasGregSons.WebApp.Models
{
    public class LogradouroModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
