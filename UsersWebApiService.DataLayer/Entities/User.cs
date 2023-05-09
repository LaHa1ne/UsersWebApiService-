namespace UsersWebApiService.DataLayer.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Created_date { get; set; }
        public int User_group_id { get; set; }
        public int User_state_id { get; set; }

        public User_group User_group { get; set; } = null!;
        public User_state User_state { get; set; } = null!;


    }
}
