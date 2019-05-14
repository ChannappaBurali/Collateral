using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory.Model;
using Inventory.IService;

namespace InventoryAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUser _iUser = null;
        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }
        [HttpPost]
        [Route("ValidateUser/{username}/{password}")]
        public IHttpActionResult ValidateUser(string username,string password)
        {
            string token = _iUser.ValidateUser(username, password);
            if (string.IsNullOrEmpty(token))
            {
                return NotFound();
            }
            return Ok(token);
        }
    }
}
