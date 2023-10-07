using Microsoft.AspNetCore.Mvc;
using SeeMeDataAccess.DBAdcess;
using SeeMeDataAccess.Models;
using SeeMeDataAccess;
using MongoDB.Driver;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly MyMongoDbContext _context;
    private readonly IMyMongoRepository _repository; // Use the interface type

    public UserController(MyMongoDbContext context, IMyMongoRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = _repository.GetAll();
        return Ok(users);
    }

    // GET: api/users/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(string id)
    {
        var user = await _context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    // POST: api/users
    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        _repository.Insert(user);
        return CreatedAtAction("GetUserById", new { id = user.Id }, user);
    }

    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, User user)
    {
        var existingUser = await _context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
        if (existingUser == null)
        {
            return NotFound();
        }

        user.Id = existingUser.Id;
        _repository.Update(user);
        return NoContent();
    }
}
