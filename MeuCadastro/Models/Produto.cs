using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCadastro.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código do Produto")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [Display(Name = "Descrição do Produto")]
        public string Descricao { get; set; }
    }
}
