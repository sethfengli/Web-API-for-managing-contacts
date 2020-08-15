using code_test_contacts_api.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace code_test_contacts_api.Domain.Entities
{
    public class Email : AuditableEntity
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public int ContactId { get; set; }

        public Contact Person { get; set; }

    }
}
