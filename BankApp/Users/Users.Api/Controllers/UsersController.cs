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
    [Route("getUser/{id}")]
    public async Task<ActionResult> GetUser(Guid id)
    {
        var user = await _repository.GetUser(id);
        return Ok(user);
    }

    [HttpPost]
    [Route("populate")]
    public async Task<ActionResult> Populate()
    {
        await _repository.Populate();
        return Ok();
    }

    [HttpGet]
    [Route("getUsers")]
    public ActionResult GetUsers()
    {
        var users = _repository.GetUsers();
        return Ok(users);
    }

    [HttpDelete]
    [Route("deleteUser")]
    public Task<ActionResult> DeleteUser()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("changeUser")]
    public async Task<ActionResult> ChangeUser(User user)
    {
        await _repository.ChangeUser(user);
        return Ok();
    }

    [HttpPost]
    [Route("addUser")]
    public async Task<ActionResult> AddUser(User user)
    {
        await _repository.AddUser(user);
        return Ok();
    }
}