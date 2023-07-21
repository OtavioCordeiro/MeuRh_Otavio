namespace MeuRh_Otavio.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CNPJ { get; set; }
        public CompanyAddress? Address { get; set; }
        public CompanyAdministrator Administrator { get; set; }
        public List<UserCompany> Users { get; set; }
    }
}
