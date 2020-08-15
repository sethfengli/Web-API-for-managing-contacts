using System.Collections.Generic;

namespace code_test_contacts_api.Application.Contact.Queries
{
    public class ContactVm
    {
        public IList<GenderDto> Gender { get; set; }

        public IList<ContactDto> Contacts { get; set; }
    }
}
