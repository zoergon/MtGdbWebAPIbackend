namespace MtGdbWebAPIbackend.Models
{
    public class LoggedUser
    {
        public string Username { get; set; }
        public int LoginId { get; set; }
        public int AccesslevelId { get; set; }
        public string? Token { get; set; }
    }
}
