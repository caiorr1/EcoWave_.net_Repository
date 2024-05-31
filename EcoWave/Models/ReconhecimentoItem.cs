using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class ReconhecimentoItem
    {
        [Key]
        public int reconhecimento_id { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public int usuario_id { get; set; }
        [MaxLength(256)]
        public string url_imagem { get; set; }
        [MaxLength(50)]
        public string tipo_item { get; set; }
        public DateTime data_reconhecimento { get; set; } = DateTime.Now;
        [MaxLength(100)]
        public string localizacao { get; set; }

        public Usuario Usuario { get; set; }
    }
}
