using code_test_contacts_api.Application.Contact.Commands;
using code_test_contacts_api.Application.Contact.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace code_test_contacts_api.WebUI.Controllers
{
    public class ContactsController : ApiController
    {
       
        [HttpGet]
        public async Task<ActionResult<ContactVm>> Get()
        {
            return await Mediator.Send(new GetContactQuery());
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportContactsQuery { Id = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateContactCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateContactCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteContactCommand { Id = id });

            return NoContent();
        }
    }
}

