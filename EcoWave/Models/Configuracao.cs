using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class Configuracao
    {
        [Key]
        public int ConfiguracaoId { get; set; }

        [Required, ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Required, MaxLength(50)]
        public string NomeConfiguracao { get; set; }

        [MaxLength(100)]
        public string ValorConfiguracao { get; set; }
    }
}
