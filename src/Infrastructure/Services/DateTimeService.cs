using code_test_contacts_api.Application.Common.Interfaces;
using System;

namespace code_test_contacts_api.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
