using code_test_contacts_api.Domain.Common;
using code_test_contacts_api.Domain.Enums;
using System;
using System.Collections.Generic;

namespace code_test_contacts_api.Domain.Entities
{
    public class Contact : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Note { get; set; }

        public Gender Sex { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IList<Phone> Phones { get; set; } = new List<Phone>();

        public IList<Email> Emails { get; set; } = new List<Email>();

    }
}
