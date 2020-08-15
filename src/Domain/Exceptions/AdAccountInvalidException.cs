using System;

namespace code_test_contacts_api.Domain.Exceptions
{
    public class AdAccountInvalidException : Exception
    {
        public AdAccountInvalidException(string adAccount, Exception ex)
            : base($"AD Account \"{adAccount}\" is invalid.", ex)
        {
        }

        public AdAccountInvalidException() : base()
        {
        }

        public AdAccountInvalidException(string message) : base(message)
        {
        }
    }
}
