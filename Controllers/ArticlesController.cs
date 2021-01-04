using ArticleManager.Data;
using ArticleManager.Dtos;
using ArticleManager.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Controllers
{
    [Authorize]
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _repository;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/articles
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<ArticleReadDto>> GetAllArticles()
        {
            var articleItems = _repository.GetAllArticles();

            return Ok(_mapper.Map<IEnumerable<ArticleReadDto>>(articleItems));
        }

        // GET api/articles/{id}
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetArticleById")]
        public ActionResult<ArticleReadDto> GetArticleById(int id)
        {
            var articleItem = _repository.GetArticleById(id);

            if (articleItem != null)
            {
                return Ok(_mapper.Map<ArticleReadDto>(articleItem));
            }

            return NotFound();
        }

        // POST api/articles
        [HttpPost]
        public ActionResult<ArticleReadDto> CreateArticle(ArticleCreateDto articleCreateDto)
        {
            var articleModel = _mapper.Map<Article>(articleCreateDto);

            _repository.CreateArticle(articleModel);
            
            _repository.SaveChanges();

            var articleReadDto = _mapper.Map<ArticleReadDto>(articleModel);
            
            return CreatedAtRoute(
                nameof(GetArticleById), 
                new { articleReadDto.Id }, 
                articleReadDto
            );
        }

        // PUT api/articles/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateArticle(int id, ArticleUpdateDto articleUpdateDto)
        {
            var articleModelFromRepo = _repository.GetArticleById(id);
            
            if (articleModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(articleUpdateDto, articleModelFromRepo);

            _repository.UpdateArticle(articleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/articles/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialArticleUpdate(int id, JsonPatchDocument<ArticleUpdateDto> patchDoc)
        {
            var articleModelFromRepo = _repository.GetArticleById(id);

            if (articleModelFromRepo == null)
            {
                return NotFound();
            }

            var articleToPatch = _mapper.Map<ArticleUpdateDto>(articleModelFromRepo);

            patchDoc.ApplyTo(articleToPatch, ModelState);

            if (!TryValidateModel(articleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(articleToPatch, articleModelFromRepo);

            _repository.UpdateArticle(articleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/articles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAticle(int id)
        {
            var articleModelFromRepo = _repository.GetArticleById(id);

            if (articleModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteArticle(articleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
