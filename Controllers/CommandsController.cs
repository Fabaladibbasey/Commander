using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ICommanderRepo _db;
    private readonly IMapper _mapper;

    // private readonly MockCommanderRepo _db = new MockCommanderRepo();
    public CommandsController(ICommanderRepo db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    // GET: api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
        var commands = _db.GetAllCommands();
        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
    }


    [HttpGet("{id}", Name = "GetCommandById")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
        var commandItem = _db.GetCommandById(id);
        if (commandItem == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(Command command)
    {
        if (command == null)
        {
            return BadRequest();
        }

        var commandModel = _mapper.Map<Command>(command);
        _db.CreateCommand(commandModel);
        _db.SaveChanges();
        var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
        return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpt)
    {
        var commandFromDb = _db.GetCommandById(id);
        if (commandFromDb == null)
        {
            return NotFound();
        }
        _mapper.Map(commandUpt, commandFromDb);
        _db.UpdateCommand(commandFromDb);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult partialUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
    {

        var commandFromDb = _db.GetCommandById(id);
        if (commandFromDb == null)
        {
            return NotFound();
        }

        var commandToPatch = _mapper.Map<CommandUpdateDto>(commandFromDb);
        patchDoc.ApplyTo(commandToPatch, ModelState);

        if (!TryValidateModel(commandToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(commandToPatch, commandFromDb);

        _db.UpdateCommand(commandFromDb);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCommand(int id)
    {
        var commandItem = _db.GetCommandById(id);
        if (commandItem == null)
        {
            return NotFound();
        }
        _db.DeleteCommand(commandItem);
        _db.SaveChanges();
        return NoContent();
    }

}
