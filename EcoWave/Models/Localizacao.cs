using System.ComponentModel.DataAnnotations;

namespace EcoWave.Models
{
    public class Localizacao
    {
        [Key]
        public int LocalizacaoId { get; set; }
        [Required, MaxLength(100)]
        public string NomeLocalizacao { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        [MaxLength(256)]
        public string Descricao { get; set; }
    }
}
