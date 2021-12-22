using AutoMapper;
using Library.Domain.Entities;
using Library.Services.Contracts;
using Library.Services.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace Library.API.Controllers
{
    [Route("api/autores")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpHead(Name = "AuthorsHead")]
        [HttpGet(Name = "GetAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorForPresentationDTO>>> Get(string fullName)
        {
            IEnumerable<Author> authors = await _service.GetAllAsync(fullName);
            return _mapper.Map<IEnumerable<AuthorForPresentationDTO>>(authors).ToList();
        }

        [HttpPost(Name = "CreateAuthor")]
        public async Task<ActionResult<AuthorForPresentationDTO>> Post([FromBody] AuthorForCreationDTO author)
        {
            Author authorToCreate = _mapper.Map<Author>(author);
            Author authorCreated = await _service.AddAsync(authorToCreate);

            return CreatedAtRoute("GetAuthor", new { authorCreated.Id }, _mapper.Map<AuthorForPresentationDTO>(authorCreated));
        }

        [HttpHead("{Id}", Name = "AuthorHead")]
        [HttpGet("{Id}", Name = "GetAuthor")]
        public async Task<ActionResult<AuthorForPresentationDTO>> Get(int id)
        {
            Author author = await _service.GetAsync(id);

            if (author == null) return NotFound();

            return _mapper.Map<AuthorForPresentationDTO>(author);
        }

        [HttpPut("{Id}", Name = "UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorForCreationDTO author)
        {
            if (!(await _service.ExistsAsync(id))) return NotFound();

            Author authorToUpdate = _mapper.Map<Author>(author);
            authorToUpdate.Id = id;

            await _service.UpdateAsync(authorToUpdate);

            return NoContent();
        }

        [HttpPatch("{Id}", Name = "PatchAuthor")]
        public async Task<IActionResult> PatchAuthor(int id, JsonPatchDocument<AuthorForCreationDTO> jsonPatchDocument)
        {
            Author author = await _service.GetAsync(id);

            if (author == null) return NotFound();

            AuthorForCreationDTO authorForCreation = _mapper.Map<AuthorForCreationDTO>(author);
            jsonPatchDocument.ApplyTo(authorForCreation);


            if (!TryValidateModel(authorForCreation))
            {
                return ValidationProblem(ModelState);
            }

            Author authorToUpdate = _mapper.Map<Author>(authorForCreation);
            authorToUpdate.Id = id;

            await _service.UpdateAsync(authorToUpdate);

            return NoContent();
        }

        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            IOptions<ApiBehaviorOptions> options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}
