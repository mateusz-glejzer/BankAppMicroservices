using Microsoft.AspNetCore.Mvc;
using Users.Core.Entities;
using Users.Core.Repositories;

namespace Users.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("getUser")]
    public async Task<ActionResult> GetUser([FromForm] Guid id)
    {
        var user = await _repository.GetUser(id);
        return Ok(user);
    }


    [HttpGet]
    [Route("getUsers")]
    public string GetUsers()
    {
        //var users = _repository.GetUsers();
        return "test";
    }

    [HttpDelete]
    [Route("deleteUser")]
    public Task<ActionResult> DeleteUser()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("changeUser")]
    public async Task<ActionResult> ChangeUser([FromForm] User user)
    {
        await _repository.ChangeUser(user);
        return Ok();
    }

    [HttpPost]
    [Route("addUser/{user}")]
    public async Task<ActionResult> AddUser([FromBody] User user)
    {
        await _repository.AddUser(user);
        return Ok();
    }
}