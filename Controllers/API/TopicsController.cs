using Assignment.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment.Controllers.API
{
    public class TopicsController : ApiController
    {
        ApplicationDbContext _context;

        public TopicsController(){
            _context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing) {
            _context.Dispose();
		}

		public IEnumerable<Topic> GetTopics(){
            var topics = new List<Topic>();
            foreach(Topic topic in _context.Topics){
                topics.Add(topic);
			}
            return topics;
		}
    }
}
