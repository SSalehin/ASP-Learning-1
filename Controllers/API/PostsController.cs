using Assignment.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Web.Http;
using System.Web.WebPages;

namespace Assignment.Controllers.API
{
    public class PostsController : ApiController
    {
        ApplicationDbContext _context;
        
        public PostsController(){
            _context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing) {
            _context.Dispose();
		}

        [HttpGet]
        [Route("~/API/posts")]
        public IEnumerable<Post> GetPosts() {
            var posts = new List<Post>();
            foreach (Post post in _context.Posts) {
                posts.Add(post);
            }
            return posts;
		}

        [HttpGet]
        [Route("~/API/posts/user")]
        public IEnumerable<Post> Getposts(string userEmail){
            userEmail = userEmail.Replace('_', '.');
            var posts = new List<Post>();
            foreach (Post post in _context.Posts) {
                if(post.UserEmail == userEmail) posts.Add(post);
            }
            return posts;
        }

        [HttpGet]
        [Route("~/API/posts/topic")]
        public IEnumerable<Post> Getposts(int topicId) {
            var posts = new List<Post>();
            foreach (Post post in _context.Posts) {
                if (post.TopicId == topicId) posts.Add(post);
            }
            return posts;
        }

        [HttpPost]
        [Route("~/API/posts")]        
        public Post CreatePost() {
            string body = Request.Content.ReadAsStringAsync().Result;
            var splitted = body
                .Trim()
                .Split(new char[] {'~'})
                .Where(s => !s.IsEmpty())
                .ToList();
            string content = splitted[0];
            int topicId = int.Parse(splitted[1]);

            var userId = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            var newPost = new Post(content, topicId, user);
            _context.Posts.Add(newPost);
            _context.SaveChanges();
            return newPost;
        }
    }
}
