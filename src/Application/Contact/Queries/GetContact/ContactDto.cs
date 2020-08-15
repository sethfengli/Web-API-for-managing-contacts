using AutoMapper;
using code_test_contacts_api.Application.Common.Mappings;
using code_test_contacts_api.Domain.Entities;
using System;
using System.Collections.Generic;

namespace code_test_contacts_api.Application.Contact.Queries
{
    public class ContactDto : IMapFrom<Domain.Entities.Contact>
    {

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Note { get; set; }

        public string Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IList<PhoneDto> Phones { get; set; }

        public IList<EmailDto> Emails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Contact, ContactDto>()
                .ForMember(d => d.Sex, opt => opt.MapFrom(s => (int)s.Sex));
        }
    }
}
