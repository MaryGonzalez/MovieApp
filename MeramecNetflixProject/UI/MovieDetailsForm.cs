using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetflixProject.Business_Objectives;
using MeramecNetflixProject.Data_Access_Layer;

namespace MeramecNetflixProject.UI
{
	public partial class MovieDetailsForm : Form
	{
		public MovieDetailsForm()
		{
			InitializeComponent();
		}

		MovieOptions objMovieOptions = new MovieOptions();
		List<MovieOptions> newMovieList = new List<MovieOptions>();


		private void MovieDetailsForm_Load(object sender, EventArgs e)
		{			
			LoadMovieData();
		}


		private void LoadMovieData()
		{
			newMovieList = MovieOptionsDB.GetMovieOptions();


			string poster = @"C:\Users\Mary\Desktop\C# II\Final Project\Big Project Images\Movie Posters\grt456.jpg";


			//string poster = objMovieOptions.Image.ToString();
			//posterPictureBox.ImageLocation = poster;



			foreach (MovieOptions item in newMovieList)
			{
			
				if (poster == item.Image)
				{
					//Title, Year, Rating, Genre, Description
					titleTxt.Text = item.Movie_Title;
					yearTxt.Text = item.Movie_Year_Made.ToString();
					ratingTxt.Text = item.Movie_Rating;
					genreTxt.Text = item.Genre_ID.ToString();					
					descriptionTxt.Text = item.Description;
					
					//Photo
					string picture = item.Image;
					posterPictureBox.ImageLocation = picture;

					//Trailer
					string URLTxt = item.Trailer;
					
					string html = "<html><head>";
					html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
					html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='420' height='250' frameborder='0'></iframe>";
					html += "</body></html>";
					this.trailerWebBrowser.DocumentText = string.Format(html, URLTxt.Split('=')[1]);


				}
			}
			
		}
		
	}
}
