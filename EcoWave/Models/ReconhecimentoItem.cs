using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class ReconhecimentoItem
    {
        [Key]
        public int ReconhecimentoId { get; set; }

        [Required, ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }

        [MaxLength(256)]
        public string UrlImagem { get; set; }

        [MaxLength(50)]
        public string TipoItem { get; set; }

        public DateTime DataReconhecimento { get; set; }

        [MaxLength(100)]
        public string Localizacao { get; set; }
    }
}
