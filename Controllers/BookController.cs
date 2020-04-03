using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrairiesBackend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers
{
    [Route("api/book/v1")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookLogic _logic;

        public BookController()
        {
            var repo = new EFGenericRepository<BookPoco>();
            _logic = new BookLogic(repo);
        }

        [HttpGet]
        [Route("book/{id}")]
        public ActionResult GetBook(Guid id)
        {
            BookPoco poco = _logic.Get(id);
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
        [Route("book")]
        public ActionResult GetAllBook()
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
        [Route("book")]
        public ActionResult PostBook(
            [FromBody] BookPoco[] appBookPocos)
        {
            _logic.Add(appBookPocos);
            return Ok();
        }

        [HttpPut]
        [Route("book")]

        public ActionResult PutBook(
            [FromBody] BookPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("book")]
        public ActionResult DeleteBook(
            [FromBody] BookPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}