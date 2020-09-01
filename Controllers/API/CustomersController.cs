using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment.Models;
using Microsoft.Ajax.Utilities;

namespace Assignment.Controllers.API
{
    public class CustomersController : ApiController{
        ApplicationDbContext _context;

        public CustomersController(){
            _context = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing) {
			_context.Dispose();
		}

		public IEnumerable<UserInfo> GetCustomers(){
			var userList = new List<UserInfo>();
			foreach(var user in _context.Users){
				userList.Add(new UserInfo(user));
			}
			return userList;
		}

		public UserInfo GetCustomer(string id){
			var user = _context.Users.SingleOrDefault(u => u.Id.Trim() == id.Trim());
			return new UserInfo(user);
		}
    }
}
