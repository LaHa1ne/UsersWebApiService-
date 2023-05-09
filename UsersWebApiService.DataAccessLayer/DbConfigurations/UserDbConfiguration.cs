using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using UsersWebApiService.DataLayer.Entities;

namespace UsersWebApiService.DataAccessLayer.DbConfigurations
{
    public class UserDbConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {

            entity.ToTable("users");

            entity.HasKey(u => u.Id);
            entity.HasIndex(u => u.Login).IsUnique();
            entity.Property(u => u.Login).IsRequired();
            entity.Property(u => u.Password).IsRequired();


            entity
                .HasOne(u => u.User_group)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.User_group_id)
                .HasPrincipalKey(g => g.Id);

            entity
                .HasOne(u => u.User_state)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.User_state_id)
                .HasPrincipalKey(s => s.Id);

        }
    }
}
