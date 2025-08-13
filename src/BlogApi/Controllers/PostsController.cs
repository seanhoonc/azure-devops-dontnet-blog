using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private static List<Post> posts = new List<Post>();

        // GET: api/posts
        [HttpGet]
        public IActionResult GetAll() => Ok(posts);

        // GET: api/posts/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            return post == null ? NotFound() : Ok(post);
        }

        // POST: api/posts
        [HttpPost]
        public IActionResult Create(Post post)
        {
            post.Id = posts.Count + 1;
            posts.Add(post);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        // PUT: api/posts/{id}
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, Post updatedPost)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            return NoContent();
        }

        // DELETE: api/posts/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            posts.Remove(post);
            return NoContent();
        }

    }
}