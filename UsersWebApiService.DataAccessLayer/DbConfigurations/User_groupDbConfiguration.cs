using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersWebApiService.DataLayer.Entities;

namespace UsersWebApiService.DataAccessLayer.DbConfigurations
{
    public class User_groupDbConfiguration : IEntityTypeConfiguration<User_group>
    {
        public void Configure(EntityTypeBuilder<User_group> entity)
        {

            entity.ToTable("user_groups");

            entity.HasKey(g => g.Id);

            entity.Property(g => g.Code).IsRequired();
            entity.Property(g => g.Description).HasDefaultValue("");

        }
    }
}
