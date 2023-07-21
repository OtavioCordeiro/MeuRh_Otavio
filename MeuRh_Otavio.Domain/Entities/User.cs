namespace MeuRh_Otavio.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<UserCompany> Companies { get; set; }
    }
}
