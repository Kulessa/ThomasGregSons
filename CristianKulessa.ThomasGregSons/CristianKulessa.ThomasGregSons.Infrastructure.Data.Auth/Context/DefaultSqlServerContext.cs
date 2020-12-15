using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CristianKulessa.ThomasGregSons.Infrastructure.Data.Auth.Context
{
    public class DefaultSqlServerContext : IdentityDbContext<Usuario>
    {
        public DefaultSqlServerContext(DbContextOptions<DefaultSqlServerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());
        }
    }
}
