namespace FARSOUND.Application.Models
{
    public class InsertUpdateUser
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

        public String? SecurityAnswer { get; set; }

        public String? SecurityQuestion { get; set; }
    }
}
