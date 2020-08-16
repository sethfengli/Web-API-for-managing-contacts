using AutoMapper;
using code_test_contacts_api.Application.Common.Mappings;
using code_test_contacts_api.Domain.Entities;
using code_test_contacts_api.Domain.Enums;
using System;
using System.Linq;

namespace code_test_contacts_api.Application.Contact.Queries
{
    public class ContactRecord : IMapFrom<Domain.Entities.Contact>
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Note { get; set; }

        public Gender Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Phones { get; set; }

        public string Emails { get; set; }


    }
}
