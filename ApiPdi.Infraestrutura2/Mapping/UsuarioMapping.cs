using ApiPdi.Application2.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPdi.Infraestrutura2.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);   
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Sobrenome).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Endereco).HasMaxLength(100);
            builder.Property(u => u.Numero);
            builder.Property(u => u.Telefone).HasMaxLength(20);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

            builder.ToTable("usuarios", schema:"porjeto_labs");
        }
    }
}
