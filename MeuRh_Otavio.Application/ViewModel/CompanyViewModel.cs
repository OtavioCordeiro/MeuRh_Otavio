using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRh_Otavio.Application.ViewModel
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        public string AdministratorName { get; set; }
        public string AdministratorNameCPF { get; set; }
        public string AdministratorNameEmail { get; set; }
        public string AdministratorNamePhone { get; set; }
    }
}
