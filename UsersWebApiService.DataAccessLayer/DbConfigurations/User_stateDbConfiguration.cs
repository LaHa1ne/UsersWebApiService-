using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersWebApiService.DataLayer.Entities;

namespace UsersWebApiService.DataAccessLayer.DbConfigurations
{
    public class User_stateDbConfiguration : IEntityTypeConfiguration<User_state>
    {
        public void Configure(EntityTypeBuilder<User_state> entity)
        {

            entity.ToTable("user_states");

            entity.HasKey(s => s.Id);

            entity.Property(s => s.Code).IsRequired();
            entity.Property(s => s.Description).HasDefaultValue("");

        }
    }
}
