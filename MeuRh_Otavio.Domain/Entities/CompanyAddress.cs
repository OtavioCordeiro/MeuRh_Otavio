namespace MeuRh_Otavio.Domain.Entities
{
    public class CompanyAddress
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
    }
}
