using System.Collections.Generic;
using MFA_Training;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MFATraining_Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private UserContext _db;
        private UserDatabaseInteraction _UDI;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _db = new UserContext();
            _UDI = new UserDatabaseInteraction(_db);
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _UDI.GetUsersList();
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            
            _UDI.CreateUser(user.username, user.password);
        }

        [HttpPut]
        public void Put([FromBody] User user)
        {
            _UDI.updateUser(user.userID, user.username, user.password);
        }
        
        [HttpDelete]
        public void Delete([FromBody] User user)
        {
            _UDI.removeUser(user.userID);
        }
    }
}