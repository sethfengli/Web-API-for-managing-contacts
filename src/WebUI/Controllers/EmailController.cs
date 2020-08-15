using code_test_contacts_api.Application.Emails.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace code_test_contacts_api.WebUI.Controllers
{
    public class EmailController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateEmailCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateEmailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateEmailDetailCommand command)
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
            await Mediator.Send(new DeleteEmailCommand { Id = id });

            return NoContent();
        }
    }
}
