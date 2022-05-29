using Microsoft.AspNetCore.Mvc;
using Users.Application.Services;
using Users.Core.Entities;

namespace Users.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserService _service;

    public UsersController(UserService service)
    {
        _service=service;
    }

    [HttpGet]
    [Route("getUser/{id}")]
    public ActionResult GetUser(Guid id)
    {
        var user = _service.GetUser(id);
        return Ok(user);
    }

    [HttpPost]
    [Route("populate")]
    public async Task<ActionResult> Populate()
    {
        await _service.Populate();
        return Ok();
    }

    [HttpGet]
    [Route("getUsers")]
    public ActionResult GetUsers()
    {
        var users =_service.GetUsers();
        return Ok(users);
    }

    [HttpDelete]
    [Route("deleteUser")]
    public async Task<ActionResult> DeleteUser()
    {
        throw new NotImplementedException();
        return Ok();
    }

    [HttpPut]
    [Route("changeUser")]
    public async Task<ActionResult> ChangeUser(User user)
    {
        await _service.ChangeUser(user);
        return Ok();
    }

    [HttpPost]
    [Route("addUser")]
    public async Task<ActionResult> AddUser(User user)
    {
        await _service.AddUser(user);
        return Ok();
    }
}