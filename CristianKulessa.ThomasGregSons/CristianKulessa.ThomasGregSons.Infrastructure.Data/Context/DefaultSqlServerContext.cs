using CristianKulessa.ThomasGregSons.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CristianKulessa.ThomasGregSons.Infrastructure.Data.Context
{
    public partial class DefaultSqlServerContext : DbContext
    {
        public DefaultSqlServerContext() { }
        public DefaultSqlServerContext(DbContextOptions<DefaultSqlServerContext> options) : base(options) { }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Logradouro> Logradouros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=ThomasGregSonsCristianRichardKulessa;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Cliente");

                entity.HasIndex(e => e.Email)
                    .HasName("UX_Cliente_Email")
                    .IsUnique();
                entity.HasIndex(e => e.Nome)
                    .HasName("IX_Cliente_Nome");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValue("('')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValue("('')");

                entity.Property(e => e.Logotipo)
                    .IsRequired()
                    .HasColumnName("Logotipo")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValue("('')");

            });

            modelBuilder.Entity<Logradouro>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_Logradouro");

                entity.HasIndex(e => e.Nome)
                    .HasName("IX_Logradouro_Nome");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValue("('')");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("Numero")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValue("('')");

                entity.Property(e => e.Complemento)
                    .HasColumnName("Complemento")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("Bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValue("('')");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("Cidade")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValue("('')");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("Estado")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValue("('')");

                entity.HasOne(p => p.Cliente)
                    .WithMany()
                    //.HasForeignKey(c => c.ClienteId)
                    .HasConstraintName("FK_Logradouro_Cliente");

            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
