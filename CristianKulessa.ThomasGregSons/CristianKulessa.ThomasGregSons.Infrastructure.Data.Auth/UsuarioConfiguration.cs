using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CristianKulessa.ThomasGregSons.Infrastructure.Data.Auth
{
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(new Usuario
            {
                UserName = "admin",
                Email = "admin@kultech.com.br",
                PasswordHash = "AQAAAAEAACcQAAAAED0tb8N23CW0B1uLCmdSzL1kfJKD1NqSU6VxzkJ/ATsHW8awVv+bBSmNiACpNR9Iqw=="
            });
        }
    }
}
