using code_test_contacts_api.Application.Common.Interfaces;
using code_test_contacts_api.Application.Contact.Queries;
using code_test_contacts_api.Infrastructure.Files.Maps;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace code_test_contacts_api.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildContactFile(IEnumerable<ContactRecord> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Configuration.RegisterClassMap<ContactRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
