using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetflixProject.Business_Objectives
{
	public class Member
	{
		public int Number { get; set; }
		public DateTime JoinDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Phone { get; set; }
		public string Member_Status { get; set; }
		public string Login_Name { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public int Contact_Method { get; set; }
		public int Subscription_ID { get; set; }
		public string Photo { get; set; }
	}
}
