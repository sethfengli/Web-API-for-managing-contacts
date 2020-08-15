namespace code_test_contacts_api.Application.Contact.Queries
{
    public class ExportContactVm
    {
        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}