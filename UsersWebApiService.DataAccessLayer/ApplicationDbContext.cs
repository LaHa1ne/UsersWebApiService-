using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersWebApiService.DataAccessLayer.DbConfigurations;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;
using UsersWepApiService.DataLayer.Helpers;

namespace UsersWebApiService.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../UsersWebApiService"))
                    .AddJsonFile("appsettings.json", optional: true).Build();
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<User_group> User_groups { get; set; } = null!;
        public virtual DbSet<User_state> User_states { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<group_code>();
            modelBuilder.HasPostgresEnum<state_code>();
            modelBuilder.ApplyConfiguration(new UserDbConfiguration());
            modelBuilder.ApplyConfiguration(new User_groupDbConfiguration());
            modelBuilder.ApplyConfiguration(new User_stateDbConfiguration());

            var User_groups = new List<User_group>()
            { 
                new User_group() { Id = 1, Code = group_code.Admin, Description = "Администратор"},
                new User_group() { Id = 2, Code = group_code.User, Description = "Пользователь"},
            };
            var User_states = new List<User_state>()
            {
                new User_state() { Id = 1, Code = state_code.Active, Description = "Активный"},
                new User_state() { Id = 2, Code = state_code.Blocked, Description = "Заблокированный"},
            };

            var Users = new List<User>()
            {
                new User() { Id = Guid.NewGuid(), Login = "Alex", Password = HashPasswordHelper.GetHashPassword("Alex"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Mary", Password = HashPasswordHelper.GetHashPassword("Mary"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 2 },
                new User() { Id = Guid.NewGuid(), Login = "John", Password = HashPasswordHelper.GetHashPassword("John"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Jane", Password = HashPasswordHelper.GetHashPassword("Jane"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Jesse", Password = HashPasswordHelper.GetHashPassword("Jesse"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 2 },
                new User() { Id = Guid.NewGuid(), Login = "Kate", Password = HashPasswordHelper.GetHashPassword("Kate"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Ann", Password = HashPasswordHelper.GetHashPassword("Ann"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Wendy", Password = HashPasswordHelper.GetHashPassword("Wendy"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Gwen", Password = HashPasswordHelper.GetHashPassword("Gwen"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 2 },
                new User() { Id = Guid.NewGuid(), Login = "Joan", Password = HashPasswordHelper.GetHashPassword("Joan"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Oliver", Password = HashPasswordHelper.GetHashPassword("Oliver"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Jacob", Password = HashPasswordHelper.GetHashPassword("Jacob"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 2 },
                new User() { Id = Guid.NewGuid(), Login = "Thomas", Password = HashPasswordHelper.GetHashPassword("Thomas"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "George", Password = HashPasswordHelper.GetHashPassword("George"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.NewGuid(), Login = "Oscar", Password = HashPasswordHelper.GetHashPassword("Oscar"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
            }; 

            modelBuilder.Entity<User_group>().HasData(User_groups);
            modelBuilder.Entity<User_state>().HasData(User_states);
            modelBuilder.Entity<User>().HasData(Users);

        }
    }
}
