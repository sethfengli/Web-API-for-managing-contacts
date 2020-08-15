using AutoMapper;
using code_test_contacts_api.Application.Common.Mappings;
using code_test_contacts_api.Application.Contact.Queries;
using code_test_contacts_api.Domain.Entities;
using NUnit.Framework;
using System;

namespace code_test_contacts_api.Application.UnitTests.Common.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
        
        [Test]
        [TestCase(typeof(Domain.Entities.Contact), typeof(ContactDto))]
        [TestCase(typeof(Phone), typeof(PhoneDto))]
        [TestCase(typeof(Email), typeof(EmailDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            _mapper.Map(instance, source, destination);
        }
    }
}
