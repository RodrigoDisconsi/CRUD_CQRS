using Controllers;
using Microsoft.AspNetCore.Mvc;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems.Responses;
using CRUDCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CRUDCleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CRUDCleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;

namespace CRUDCleanArchitecture.Api.Controllers
{
    public class TodoItemsController: ApiControllerBase
    {
        [HttpGet("GetTodoItems")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTodoItemsResponse))]
        public async Task<ActionResult<GetTodoItemsResponse>> GetPrestadoresAsync([FromQuery] GetTodoItemsRequest request)
        {
            return await Mediator.Send(request);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
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
            await Mediator.Send(new DeleteTodoItemCommand(id));

            return NoContent();
        }
    }
}
