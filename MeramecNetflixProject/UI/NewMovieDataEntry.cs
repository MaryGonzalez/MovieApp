using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetflixProject.Business_Objectives;
using MeramecNetflixProject.Data_Access_Layer;

namespace MeramecNetflixProject.UI
{
	public partial class NewMovieDataEntry : Form
	{
		public NewMovieDataEntry()
		{
			InitializeComponent();
		}

		string imgUrl = null;
		MovieOptions objnewMovie = new MovieOptions();

		private void NewMovieDataEntry_Load(object sender, EventArgs e)
		{			
			//Populate combo boxes
			this.PopulateGenreCombo();
			this.PopulateRatingCombo();
			this.PopulateMediaTypeCombo();
		}

		private void movieNumber()
		{

		}

		private void uploadTrailerBtn_Click(object sender, EventArgs e)
		{
			
			uploadTrailer();

		}


		private void uploadTrailer()
		{
			string html = "<html><head>";
			html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
			html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='420' height='250' frameborder='0'></iframe>";
			html += "</body></html>";
			this.movieTrailerWebBrowser.DocumentText = string.Format(html, URLTxt.Text.Split('=')[1]);
		}


		private void ClearBtn_Click(object sender, EventArgs e)
		{
			ClearAll();
		}

		private void Addbtn_Click(object sender, EventArgs e)
		{
			ValidateInfo();

			MovieOptions objnewMovie = new MovieOptions();

			objnewMovie.Movie_Number = Convert.ToInt32(movieNumberTxt.Text);
			objnewMovie.Movie_Title = titleTxt.Text;
			objnewMovie.Description = descriptionTxt.Text;
			objnewMovie.Movie_Year_Made = Convert.ToInt16(yearTxt.Text);

			objnewMovie.Genre_ID = Convert.ToInt16(genreComboBox.SelectedIndex.ToString());

			//Ratings Combo Box
			if (ratingComboBox.SelectedIndex == 1)
			{
				objnewMovie.Movie_Rating = "G";
			}
			else if (ratingComboBox.SelectedIndex == 2)
			{
				objnewMovie.Movie_Rating = "PG";
			}
			else if (ratingComboBox.SelectedIndex == 3)
			{
				objnewMovie.Movie_Rating = "PG-13";
			}
			else if (ratingComboBox.SelectedIndex == 4)
			{
				objnewMovie.Movie_Rating = "R";
			}

			//Media Type Combo Box
			if(mediaTypeComboBox.SelectedIndex == 1)
			{
				objnewMovie.Media_Type = "Blu-Ray";
			}
			else if (mediaTypeComboBox.SelectedIndex == 2)
			{
				objnewMovie.Media_Type = "DVD";
			}


			objnewMovie.Movie_Retail_Cost = retailCostTxt.Text;
			objnewMovie.Copies_On_Hand = Convert.ToInt16(copiesTxt.Text);


			if (moviePosterPictureBox.Image != null)
			{
				objnewMovie.Image = imgUrl;
			}


			objnewMovie.Trailer = URLTxt.Text;



			try
			{
				bool status = MovieOptionsDB.AddMovieOption(objnewMovie);
				if (status) //You can use this syntax as well..if (status ==true)
				{
					MessageBox.Show("Movie was added to the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Movie was not added to database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	
		//Upload image
		private void UploadImageBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				imgUrl = dialog.FileName.ToString();
				moviePosterPictureBox.ImageLocation = imgUrl;
			}
		}
		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			//ValidateInfo();

			MovieOptions objNewMovie = new MovieOptions();

			objNewMovie.Movie_Number = Convert.ToInt32(movieNumberTxt.Text);
			objNewMovie.Movie_Title = titleTxt.Text;
			objNewMovie.Description = descriptionTxt.Text;
			objNewMovie.Movie_Year_Made = Convert.ToInt32(yearTxt.Text);
			objnewMovie.Genre_ID = Convert.ToInt16(genreComboBox.SelectedIndex.ToString());
			objNewMovie.Movie_Rating = ratingComboBox.Text;
			objNewMovie.Media_Type = mediaTypeComboBox.Text;
			objNewMovie.Movie_Retail_Cost = movieNumberTxt.Text;
			objNewMovie.Copies_On_Hand = Convert.ToInt16(copiesTxt.Text);
			objNewMovie.Image = Convert.ToString(moviePosterPictureBox.Image);
			objNewMovie.Trailer = URLTxt.Text;
			
			try
			{
				bool status = MovieOptionsDB.DeleteMovieOption(objNewMovie);
				if (status) //You can use this syntax as well..if (status ==true)
				{
					MessageBox.Show("New movie was deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("New movie was not deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BrowseBtn_Click(object sender, EventArgs e)
		{
			//Call the NewMovieDB static class to fill the data grid
			try
			{
				List<MovieOptions> newMovieList = new List<MovieOptions>();
				newMovieList = MovieOptionsDB.GetMovieOptions();
				NewMovieDataGridView.DataSource = newMovieList;

				this.NewMovieDataGridView.Columns[7].DefaultCellStyle.Format = "c";

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}

		private void UpdateBtn_Click(object sender, EventArgs e)
		{
			ValidateInfo();
			MovieOptions objMovieOption = new MovieOptions();

			objMovieOption.Movie_Number = Convert.ToInt32(movieNumberTxt.Text);
			objMovieOption.Movie_Title = titleTxt.Text;
			objMovieOption.Description = descriptionTxt.Text;
			objMovieOption.Movie_Year_Made = Convert.ToInt32(yearTxt.Text);
			objMovieOption.Genre_ID = Convert.ToInt16(genreComboBox.SelectedIndex.ToString());
			objMovieOption.Movie_Rating = ratingComboBox.Text;
			objMovieOption.Media_Type = mediaTypeComboBox.Text;
			objMovieOption.Movie_Retail_Cost = movieNumberTxt.Text;
			objMovieOption.Copies_On_Hand = Convert.ToInt16(copiesTxt.Text);
			objMovieOption.Image = Convert.ToString(moviePosterPictureBox.Image);
			objMovieOption.Trailer = URLTxt.Text;


			try
			{
				bool status = MovieOptionsDB.UpdateMovieOption(objMovieOption);
				if (status) 
				{
					MessageBox.Show("Movie has been updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Movie was not updated in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void PopulateGenreCombo()
		{			
			genreComboBox.DataSource = GenreDB.GetGenres();
			genreComboBox.DisplayMember = "Name";
			genreComboBox.ValueMember = "Genre_ID";
		}

		private void PopulateRatingCombo()
		{
			ratingComboBox.BackColor = Color.Black;

			ratingComboBox.Items.Add("--Select a Rating--");
			ratingComboBox.Items.Add("G : General Audience");
			ratingComboBox.Items.Add("PG : Parental Guidance Suggested");
			ratingComboBox.Items.Add("PG-13 : Parents Strongly Cautioned");
			ratingComboBox.Items.Add("R : Restricted");

			//Default combo box to first item
			ratingComboBox.SelectedIndex = 0;
		}

		private void PopulateMediaTypeCombo()
		{
			mediaTypeComboBox.Items.Add("--Select Media Type--");
			mediaTypeComboBox.Items.Add("Blu-Ray");
			mediaTypeComboBox.Items.Add("DVD");

			//Default combo box to first item
			mediaTypeComboBox.SelectedIndex = 0;
		}

		private void ValidateInfo()
		{
			//Validate the UI
			if (string.IsNullOrEmpty(titleTxt.Text))
			{
				MessageBox.Show("Please enter a title.");
				titleTxt.Focus();
				return;
			}

			if (string.IsNullOrEmpty(descriptionTxt.Text))
			{
				MessageBox.Show("Please enter a description.");
				descriptionTxt.Focus();
				return;
			}

			if (string.IsNullOrEmpty(movieNumberTxt.Text))
			{
				MessageBox.Show("Please enter a movie number.");
				movieNumberTxt.Focus();
				return;
			}

			if (string.IsNullOrEmpty(yearTxt.Text))
			{
				MessageBox.Show("Please enter the year made.");
				yearTxt.Focus();
				return;
			}

			if (genreComboBox.SelectedIndex == 0)
			{
				MessageBox.Show("No genre selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				genreComboBox.Focus();
				return;
			}

			if (ratingComboBox.SelectedIndex == 0)
			{
				MessageBox.Show("No rating selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ratingComboBox.Focus();
				return;
			}

			if (mediaTypeComboBox.SelectedIndex == 0)
			{
				MessageBox.Show("No media type selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				mediaTypeComboBox.Focus();
				return;
			}

			if (string.IsNullOrEmpty(retailCostTxt.Text))
			{
				MessageBox.Show("Please enter a retail cost.");
				retailCostTxt.Focus();
				return;
			}

			
			if (string.IsNullOrEmpty(copiesTxt.Text))
			{
				MessageBox.Show("Please enter copies on hand.");
				copiesTxt.Focus();
				return;
			}
		}

		private void genreComboBox_SelectionChangeCommitted(object sender, EventArgs e)
		{
			genreComboBox.Text = genreComboBox.SelectedValue.ToString();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			MovieOptionsView newMovieForm = new MovieOptionsView();
			newMovieForm.Show();
			this.Hide();
		}

		private void ClearAll()
		{
			titleTxt.Text = String.Empty;
			descriptionTxt.Text = String.Empty;
			movieNumberTxt.Text = String.Empty;
			yearTxt.Text = String.Empty;
			genreComboBox.SelectedIndex = 0;
			ratingComboBox.SelectedIndex = 0;
			mediaTypeComboBox.SelectedIndex = 0;
			retailCostTxt.Text = String.Empty;
			copiesTxt.Text = String.Empty;

			//photo
			moviePosterPictureBox.Image = Properties.Resources.photo2;

			//trailer
			this.movieTrailerWebBrowser.DocumentText = null;

			URLTxt.Text = String.Empty;
			NewMovieDataGridView.DataSource = null;

		
		}

		private void NewMovieDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
			
				DataGridViewRow row = this.NewMovieDataGridView.Rows[e.RowIndex];

				//Movie Number, Title, Description, Year
				movieNumberTxt.Text = row.Cells[0].Value.ToString();
				titleTxt.Text = row.Cells[1].Value.ToString();
				descriptionTxt.Text = row.Cells[2].Value.ToString();
				yearTxt.Text = row.Cells[3].Value.ToString();


				//Ratings
				string ratingString = row.Cells[5].Value.ToString();
				if(ratingString == "G")
				{
					ratingComboBox.SelectedIndex = 1;
				}
				else if(ratingString == "PG")
				{
					ratingComboBox.SelectedIndex = 2;
				}
				else if(ratingString == "PG-13")
				{
					ratingComboBox.SelectedIndex = 3;
				}
				else if(ratingString == "R")
				{
					ratingComboBox.SelectedIndex = 4;
				}


				//media type
				string mediaString = row.Cells[6].Value.ToString();
				if (mediaString == "Blu-Ray")
				{
					mediaTypeComboBox.SelectedIndex = 1;
				}
				else if (mediaString == "DVD")
				{
					mediaTypeComboBox.SelectedIndex = 2;
				}




				//Retail Cost, Copies on Hand
				retailCostTxt.Text = row.Cells[7].Value.ToString();

				copiesTxt.Text = row.Cells[8].Value.ToString();

				//Picture box
				string picture = row.Cells[9].Value.ToString();
				moviePosterPictureBox.ImageLocation = picture;
				
				URLTxt.Text = row.Cells[10].Value.ToString();


				uploadTrailer();

			}
		}
	}
}
