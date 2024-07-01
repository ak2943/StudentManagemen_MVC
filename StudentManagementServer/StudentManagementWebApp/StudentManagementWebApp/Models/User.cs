namespace StudentManagementWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class Token
    {
        //jwt token value
        public string value { get; set; }
    }
}
