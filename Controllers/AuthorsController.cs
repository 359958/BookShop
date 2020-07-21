using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookShop.IServices;
using BookShop.Models;
using BookShop.MappingProfile;
using BookShop.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthors _authors;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthors authors , IMapper mapper)
        {
            this._authors = authors;
            this._mapper = mapper;
        }

        // GET: api/Authors/5
        [HttpGet("{id}", Name = nameof(GetAuthor))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult GetAuthor(string id)
        {
            if (id != null)
            {
                var authors = _authors.GetAuthor(id);

                AuthorsInfo authorsInfo = _mapper.Map<AuthorsInfo>(authors);

                return Ok(authorsInfo);
            }
            else return NoContent();
        }

        // POST: api/Authors
        [HttpPost(Name = "PostAuthor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult PostAuthor([FromBody] AuthorsInfo PostauthorsInfo)
        {
            TryValidateModel(PostauthorsInfo);
            Authors Postauthors = _mapper.Map<Authors>(PostauthorsInfo);
            _authors.AddAuthor(Postauthors);
            return Ok();
            
        }

        // PUT: api/Authors/5
        [HttpPut("{id}", Name = "updateAuthor")]
        public ActionResult updateAuthor(string id, [FromBody] AuthorsUpdate updateauthors)
        {
            var author = _authors.GetAuthor(id);
            if (author != null)
            {
                Authors tobeauthor = _mapper.Map(updateauthors, author);
                _authors.updateAuthor(id,tobeauthor);
                return CreatedAtRoute(nameof(GetAuthor), new {id = "A1"}, _mapper.Map<AuthorsUpdate>(tobeauthor));
            }
            else return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
