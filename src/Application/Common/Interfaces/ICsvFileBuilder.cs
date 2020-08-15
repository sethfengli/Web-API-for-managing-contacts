using code_test_contacts_api.Application.Contact.Queries;
using System.Collections.Generic;

namespace code_test_contacts_api.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildContactFile(IEnumerable<ContactRecord> records);
    }
}
