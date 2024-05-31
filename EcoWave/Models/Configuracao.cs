using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class Configuracao
    {
        [Key]
        public int configuracao_id { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public int usuario_id { get; set; }
        [Required]
        [MaxLength(50)]
        public string nome_configuracao { get; set; }
        [MaxLength(100)]
        public string valor_configuracao { get; set; }

        public Usuario Usuario { get; set; }
    }
}
