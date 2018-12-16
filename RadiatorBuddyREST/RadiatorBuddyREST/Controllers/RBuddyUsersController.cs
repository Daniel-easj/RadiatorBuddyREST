using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using RadiatorBuddyREST.DbUtil;

namespace RadiatorBuddyREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RBuddyUsersController : ControllerBase
    {
        private static ManageRBuddyUser rBuddyUserManager = new ManageRBuddyUser();

        // GET: api/RBuddyUsers
        [HttpGet]
        public List<RBuddyUser> Get()
        {
            return rBuddyUserManager.GetAllUserData();
        }


        // PUT: api/RBuddyUsers/
        [HttpPut]
        public void Put([FromBody] RBuddyUser user)
        {
            rBuddyUserManager.UpdateRoomData(user);
        }
    }
}
