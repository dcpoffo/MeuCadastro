using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeuCadastro.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código do Cliente")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(70)")]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }
    }
}
