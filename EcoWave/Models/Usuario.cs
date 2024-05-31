using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoWave.Models
{
    public class Usuario
    {
        [Key]
        public int usuario_id { get; set; }
        [Required]
        [MaxLength(50)]
        public string nome_usuario { get; set; }
        [Required]
        [MaxLength(256)]
        public string senha_hash { get; set; }
        [Required]
        [MaxLength(100)]
        public string email { get; set; }
        public DateTime data_registro { get; set; } = DateTime.Now;
        [MaxLength(100)]
        public string localizacao { get; set; }
        [MaxLength(256)]
        public string foto_perfil { get; set; }

        public ICollection<ItemReciclado> ItensReciclados { get; set; }
        public ICollection<Recompensa> Recompensas { get; set; }
        public ICollection<Amigo> Amigos { get; set; }
        public ICollection<Amigo> AmigosDoUsuario { get; set; }
        public ICollection<ReconhecimentoItem> ReconhecimentoItens { get; set; }
        public ICollection<Configuracao> Configuracoes { get; set; }
    }
}
