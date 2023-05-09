using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UsersWebApiService.DataAccessLayer;
using UsersWebApiService.DataLayer.Entities;
using UsersWebApiService.DataLayer.Enums;
using UsersWepApiService.DataLayer.Helpers;

namespace UsersWebApiService.Tests2
{
    public class ApplicationDbContextFactory
    {
        private static object _customerContextLock = new object();

        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase($"database{Guid.NewGuid()}", new InMemoryDatabaseRoot())
                .Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            context.Users.RemoveRange(context.Users);
            context.User_groups.RemoveRange(context.User_groups);
            context.User_states.RemoveRange(context.User_states);
            context.Database.EnsureCreated();

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
                new User() { Id = Guid.Parse("2ecd3e0c-4dde-499d-8edb-b17bf4ea7221"), Login = "Alex", Password = HashPasswordHelper.GetHashPassword("Alex"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.Parse("e07f8954-a8e4-406c-898d-8770db4b1c8a"), Login = "Mary", Password = HashPasswordHelper.GetHashPassword("Mary"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.Parse("d326dd3c-55c0-4f71-b339-852e0a3f8223"), Login = "John", Password = HashPasswordHelper.GetHashPassword("John"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.Parse("b2daf1a1-e6a4-4f28-81d5-83dfe599c713"), Login = "Jane", Password = HashPasswordHelper.GetHashPassword("Jane"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.Parse("73afc898-2838-4d31-a36a-72556a8be38c"), Login = "Jesse", Password = HashPasswordHelper.GetHashPassword("Jesse"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.Parse("92a8955a-1940-4026-ba7d-dbe8c436d9b9"), Login = "Kate", Password = HashPasswordHelper.GetHashPassword("Kate"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.Parse("abb87168-3896-4e3a-bec6-eb5bd74575e6"), Login = "Ann", Password = HashPasswordHelper.GetHashPassword("Ann"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
                new User() { Id = Guid.Parse("212a6bea-3764-4abc-8ba1-3563f4fff6e5"), Login = "Wendy", Password = HashPasswordHelper.GetHashPassword("Wendy"), Created_date = DateTime.Now, User_group_id = 2, User_state_id = 1 },
            };
            //lock (_customerContextLock)
            //{
            var item_count=context.Users.Count();
            Console.WriteLine(item_count);
            /*context.User_groups.AddRange(User_groups);
            context.SaveChanges();

            context.User_states.AddRange(User_states);
            context.SaveChanges();


            context.Users.AddRange(Users);
            context.SaveChanges();*/

            //}
            /*context.User_groups.AddRange(User_groups);
        context.User_states.AddRange(User_states);
        context.Users.AddRange(Users);
        context.SaveChanges();*/
            return context;

        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.ChangeTracker
            .Entries()
            .ToList()
            .ForEach(e => e.State = EntityState.Detached);
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
