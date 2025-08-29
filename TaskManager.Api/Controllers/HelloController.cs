using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return "Hello world!";
    }
}
