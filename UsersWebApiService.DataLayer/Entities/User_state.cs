using UsersWebApiService.DataLayer.Enums;

namespace UsersWebApiService.DataLayer.Entities
{
    public class User_state
    {
        public int Id { get; set; }
        public state_code Code { get; set; }
        public string Description { get; set; } = null!;

        public List<User> Users { get; set; } = new List<User>();
    }
}
