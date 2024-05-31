using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoWave.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required, MaxLength(50)]
        public string NomeUsuario { get; set; }
        [Required, MaxLength(256)]
        public string SenhaHash { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.Now;
        [MaxLength(100)]
        public string Localizacao { get; set; }
        [MaxLength(256)]
        public string FotoPerfil { get; set; }

        public ICollection<ItemReciclado> ItensReciclados { get; set; }
        public ICollection<Recompensa> Recompensas { get; set; }
        public ICollection<Amigo> Amigos { get; set; }
        public ICollection<Amigo> AmigosDoUsuario { get; set; }
        public ICollection<ReconhecimentoItem> ReconhecimentoItens { get; set; }
        public ICollection<Configuracao> Configuracoes { get; set; }
    }
}
