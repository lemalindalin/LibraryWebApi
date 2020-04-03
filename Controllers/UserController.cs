using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrairiesBackend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserLogic _logic;

        public UserController()
        {
            var repo = new EFGenericRepository<UserPoco>();
            _logic = new UserLogic(repo);
        }

        [HttpGet]
        [Route("user/{id}")]
        public ActionResult GetUser(Guid id)
        {
            UserPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpGet]
        [Route("user")]
        public ActionResult GetAllUser()
        {
            var books = _logic.GetAll();
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(books);
            }
        }


        [HttpPost]
        [Route("user")]
        public ActionResult PostUser(
            [FromBody] UserPoco[] appBookPocos)
        {
            _logic.Add(appBookPocos);
            return Ok();
        }

        [HttpPut]
        [Route("user")]

        public ActionResult PutUser(
            [FromBody] UserPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("user")]
        public ActionResult DeleteUser(
            [FromBody] UserPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}