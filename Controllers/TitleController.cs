using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookShop.IServices;
using BookShop.Models;
using AutoMapper;
using BookShop.MappingProfile;
using Microsoft.AspNetCore.JsonPatch;

namespace BookShop.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitles titles;
        private readonly IMapper _mapper;

        public TitleController(ITitles titles ,IMapper mapper )
        {
            this.titles = titles;
            _mapper = mapper;
        }
        // GET: api/Title
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Title/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<BooksInfo> Get(string id)
        {
            var books = titles.GetById(id);
            BooksInfo item = _mapper.Map<BooksInfo>(books);

            if (item != null)
            {
                return Ok(item);
            }
            else return NoContent();

        }

        // POST: api/Title
        [HttpPost(Name = nameof(NewBook))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult NewBook([FromBody] BookInsert books)
        {
            if (books != null)
            {
                Titles book = _mapper.Map<Titles>(books);
                titles.InsertBook(book);
                return Ok();
            }
            else return NoContent();
        }

        // PUT: api/Title/5
        [HttpPut("{id}")]
        public ActionResult UpdateBook(string id, [FromBody] BookUpdate books)
        {
            TryValidateModel(books);
           
            var book = titles.GetById(id);
            _mapper.Map(books, book);
            if (book == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                titles.GetBookUpdate(book);
            }
            return Ok();
        }

        // [HttpPatch]
        [HttpPatch("PartiallyUpdateBook/{id}", Name = "PartiallyUpdateBook")]
        public ActionResult PartiallyUpdateBook(string id, [FromBody] JsonPatchDocument<BookUpdate> books)
        {
            var book = titles.GetById(id);
            BookUpdate bookUpdateDto = _mapper.Map<BookUpdate>(book);
            TryValidateModel(bookUpdateDto);
            if (book == null)
            {
                return NotFound();
            }
            books.ApplyTo(bookUpdateDto);
            if (ModelState.IsValid)
            {
                _mapper.Map(bookUpdateDto, book);
                titles.GetBookUpdate(book);
            }
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
