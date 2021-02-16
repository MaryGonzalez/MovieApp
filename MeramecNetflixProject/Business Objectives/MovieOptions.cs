using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeramecNetflixProject.Business_Objectives
{
	public class MovieOptions
	{
		public int Movie_Number { get; set; }
		public string Movie_Title { get; set; }
		public string Description { get; set; }
		public int Movie_Year_Made { get; set; }
		public int Genre_ID { get; set; }
		public string Movie_Rating { get; set; }
		public string Media_Type { get; set; }
		public string Movie_Retail_Cost { get; set; }
		public int Copies_On_Hand { get; set; }
		public string Image { get; set; }
		public string Trailer { get; set; }
	}
}
