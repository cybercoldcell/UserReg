using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegAPI.Entities;

namespace UserRegAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetUserList()
        {
            try
            {
                List<Users> objUsers = new List<Users>();

                using (userregisterContext objContext = new userregisterContext(DBConnection.DBConnectionString()))
                {
                    objUsers = objContext.Users.ToList();
                }

                return Ok(objUsers);
            }
            catch (Exception ex)
            {

                throw ex;
            }
      
        }

        [HttpPost]
        public ActionResult AddUser([FromBody]Users objUsers)
        {
            try
            {
                using (userregisterContext objContext = new userregisterContext(DBConnection.DBConnectionString()))
                {
                    objContext.Add(objUsers);
                    objContext.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}