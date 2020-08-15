using AutoMapper;
using code_test_contacts_api.Application.Common.Mappings;
using code_test_contacts_api.Domain.Entities;

namespace code_test_contacts_api.Application.Contact.Queries
{
    public class EmailDto : IMapFrom<Email>
    {
        public int Id { get; set; }

        public int ContactID { get; set; }

        public string EmailAddress { get; set; }
    }
}
