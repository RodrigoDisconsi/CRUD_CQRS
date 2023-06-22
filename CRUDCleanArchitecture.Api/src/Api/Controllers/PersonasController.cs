using CRUDCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CRUDCleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using CRUDCleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems.Responses;
using CRUDCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Controllers;
using CRUDCleanArchitecture.Application.Personas.Queries.GetPersonas.Responses;
using CRUDCleanArchitecture.Application.Personas.Queries.GetPersonas;
using CRUDCleanArchitecture.Application.Personas.Commands.CreatePersona;
using CRUDCleanArchitecture.Application.Personas.Commands.DeletePersona;

namespace API.Controllers;
public class PersonasController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPersonasResponse))]
    public async Task<ActionResult<GetPersonasResponse>> GetPrestadoresAsync([FromQuery] GetPersonasRequest request)
    {
        return await Mediator.Send(request);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePersonaCommand command)
    {
        return await Mediator.Send(command);
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
    //{
    //    if (id != command.Id)
    //    {
    //        return BadRequest();
    //    }

    //    await Mediator.Send(command);

    //    return NoContent();
    //}

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeletePersonaCommand(id));

        return NoContent();
    }
}
