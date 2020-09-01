using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Assignment.Models {
	[DataContract]
	public class Post {
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Content { get; set; }
		[DataMember]
		public int TopicId { get; set; }
		[DataMember]
		public string UserEmail { get; set; }
		[DataMember]
		public string UserName { get; set; }
		[DataMember]
		public DateTime PostedOn { get; set; }

		public Post() { }

		public Post(string content, int topicId, ApplicationUser user){
			this.Content = content;
			this.TopicId = topicId;
			this.PostedOn = DateTime.Now;
			this.UserEmail = user.Email;
			this.UserName = user.UserName;
		}

		public Post(int id, string content, int topicId, string userEmail, string userName, DateTime postedOn){
			this.Id = id;
			this.Content =content;
			this.TopicId = topicId;
			this.UserEmail = userEmail;
			this.UserName = userName;
			this.PostedOn = postedOn;
		}

		public static Post FromDescription(int id, string content, int topicId, string userEmail, string userName, DateTime postedOn) {
			return  new Post(id, content, topicId, userEmail, userName, postedOn);
		}
	}
}