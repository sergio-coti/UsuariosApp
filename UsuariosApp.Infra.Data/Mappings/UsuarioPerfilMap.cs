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
    /// Classe de mapeamento da entidade associativa do banco de dados
    /// </summary>
    public class UsuarioPerfilMap : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            //nome da tabela
            builder.ToTable("USUARIO_PERFIL");

            //chave primária composta
            builder.HasKey(up => new { up.UsuarioId, up.PerfilId });

            //mapeamento do campo 'UsuarioId'
            builder.Property(up => up.UsuarioId)
                .HasColumnName("USUARIO_ID");

            //mapeamento do campo 'PerfilId'
            builder.Property(up => up.PerfilId)
                .HasColumnName("PERFIL_ID");

            //chave estrangeira para a tabela de usuário
            builder.HasOne(up => up.Usuario) //1 Usuário
                .WithMany(u => u.Perfis) //Tem MUITOS Perfis
                .HasForeignKey(up => up.UsuarioId) //chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //não permite excluir se houverem vinculos

            //chave estrangeira para a tabela de perfil
            builder.HasOne(up => up.Perfil) //1 Perfil
                .WithMany(p => p.Usuarios) //Tem MUITOS Usuários
                .HasForeignKey(up => up.PerfilId) //chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //não permite excluir se houverem vinculos
        }
    }
}
