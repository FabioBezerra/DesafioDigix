using Desafio.Domain.FamiliaDomain;
using Desafio.Domain.PessoaDomain;
using Desafio.Domain.RendaDomain;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.MockedData.Context
{
    public class DesafioDbContext : DbContext
    {
        public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options)
        {
        }

        public DbSet<Familia> Familia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnMapPessoa(modelBuilder);
            OnMapRenda(modelBuilder);
            OnMapFamilia(modelBuilder);
        }

        private void OnMapPessoa(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .Property(d => d.Id)
                .HasColumnType("nvarchar(900)")
                .IsRequired();
            modelBuilder.Entity<Pessoa>()
                .Property(d => d.Nome)
                .HasColumnType("nvarchar(500)")
                .IsRequired();
            modelBuilder.Entity<Pessoa>()
                .Property(d => d.DataDeNascimento)
                .HasColumnType("date");
            modelBuilder.Entity<Pessoa>()
                .HasOne(d => d.Familia)
                .WithMany(p => p.Pessoas)
                .HasForeignKey(t => t.FamiliaId)
                .HasPrincipalKey(d => d.Id);
            modelBuilder.Entity<Pessoa>()
                .HasOne(d => d.Renda)
                .WithOne(d => d.Pessoa)
                .HasForeignKey<Renda>(d => d.PessoaId)
                .HasPrincipalKey<Pessoa>(d => d.Id);
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
        }

        private void OnMapRenda(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Renda>()
                .Property(d => d.Id)
                .HasColumnType("nvarchar(900)")
                .IsRequired();
            modelBuilder.Entity<Renda>()
                .Property(d => d.Valor)
                .HasColumnType("decimal(9,2)");
            modelBuilder.Entity<Renda>()
                .HasOne(d => d.Familia)
                .WithMany(p => p.Rendas)
                .HasForeignKey(t => t.FamiliaId)
                .HasPrincipalKey(d => d.Id);
            modelBuilder.Entity<Renda>().ToTable("Renda");
        }

        private void OnMapFamilia(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Familia>()
                .Property(d => d.Id)
                .HasColumnType("nvarchar(900)")
                .IsRequired();
            modelBuilder.Entity<Familia>().ToTable("Familia");
        }
    }
}
