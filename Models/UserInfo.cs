using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Assignment.Models {
	[DataContract]
	public class UserInfo {
		[DataMember]
		public string Id { get; set; }
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string PhoneNumber{ get; set; }

		public UserInfo(ApplicationUser user){
			this.Id = user.Id;
			this.Email = user.Email;
			this.Name = user.UserName;
			this.PhoneNumber = user.PhoneNumber;
		}
	}
}