using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Models.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Perfil
    /// </summary>
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            //nome da tabela
            builder.ToTable("PERFIL");

            //chave primária
            builder.HasKey(p => p.Id);

            //mapeamento do campo 'Id'
            builder.Property(p => p.Id)
                .HasColumnName("ID");

            //mapeamento do campo 'Nome'
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            //definindo o campo 'Nome' como único
            builder.HasIndex(p => p.Nome)
                .IsUnique();
        }
    }
}
