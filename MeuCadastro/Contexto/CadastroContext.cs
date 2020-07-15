using MeuCadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuCadastro.Contexto
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {

        }

        //tabelas que serao criadas
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Rnc> Rnc { get; set; }


    }
}
