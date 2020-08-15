using code_test_contacts_api.Application.Contact.Queries;
using CsvHelper.Configuration;
using System.Globalization;

namespace code_test_contacts_api.Infrastructure.Files.Maps
{
    public class ContactRecordMap : ClassMap<ContactRecord>
    {
        public ContactRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            //Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
