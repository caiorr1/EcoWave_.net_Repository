using System.ComponentModel.DataAnnotations;

namespace EcoWave.Models
{
    public class Localizacao
    {
        [Key]
        public int localizacao_id { get; set; }
        [Required]
        [MaxLength(100)]
        public string nome_localizacao { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        [MaxLength(256)]
        public string descricao { get; set; }
    }
}
