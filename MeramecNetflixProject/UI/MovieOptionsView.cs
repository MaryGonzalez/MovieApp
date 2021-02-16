using MeramecNetflixProject.Properties;
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
	public partial class MovieOptionsView : Form
	{
		//Drop down menu timer
		private bool isCollapsed;

		public MovieOptionsView()
		{
			InitializeComponent();
		}

		List<MovieOptions> movieOptionsList = new List<MovieOptions>();
		MovieOptions objMovieOptions = new MovieOptions();
		PictureBox picture;



		private void MovieOptionsView_Load(object sender, EventArgs e)
		{
			movieOptionsList = MovieOptionsDB.GetMovieOptions();

			for (int i = 0; i <= movieOptionsList.Count; i++)
			{				
				addPicture(i);
				//movieOptionsFlowPanel.Controls.Add(picture);
				
			}
		}


		PictureBox addPicture(int i)
		{ 
			foreach (MovieOptions movie in movieOptionsList)
			{
			picture = new PictureBox();

			picture.Size = new Size(209, 293);
			picture.Location = new Point(5, (i * 80) + 5);
			picture.Margin = new Padding(15, 30, 15, 30);
			picture.SizeMode = PictureBoxSizeMode.StretchImage;

			string poster = movie.Image;
			picture.ImageLocation = poster;

			movieOptionsFlowPanel.Controls.Add(picture);
			picture.Click += new System.EventHandler(this.pic_Click);
			}

			return picture;
		}


		private void pic_Click(object sender, EventArgs e)
		{
			Form formBackground = new Form();
			try
			{
				
				using (MovieDetailsForm newMoviesDetailsForm = new MovieDetailsForm())
				{					
					formBackground.StartPosition = FormStartPosition.Manual;
					formBackground.FormBorderStyle = FormBorderStyle.None;
					formBackground.Opacity = .50d;
					formBackground.BackColor = Color.Black;
					formBackground.WindowState = FormWindowState.Maximized;
					formBackground.TopMost = true;
					formBackground.Location = this.Location;
					formBackground.ShowInTaskbar = false;
					formBackground.Show();

					newMoviesDetailsForm.Owner = formBackground;
					newMoviesDetailsForm.ShowDialog();

					formBackground.Dispose();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				formBackground.Dispose();
			}
		}


		

		
		private void logOutBtn_Click(object sender, EventArgs e)
		{
			LoginDataForm newLogout = new LoginDataForm();
			newLogout.Show();
			this.Hide();
		}

		private void memberBtn_Click(object sender, EventArgs e)
		{
			MemberDataEntry newMemberForm = new MemberDataEntry();
			newMemberForm.Show();
			this.Hide();
		}

		private void moviesBtn_Click(object sender, EventArgs e)
		{
			NewMovieDataEntry newMovieForm = new NewMovieDataEntry();
			newMovieForm.Show();
			this.Hide();
		}

		private void genreBtn_Click(object sender, EventArgs e)
		{
			GenreDataEntry newGenreForm = new GenreDataEntry();
			newGenreForm.Show();
			this.Hide();
		}

		private void adminTimer_Tick(object sender, EventArgs e)
		{

			if (isCollapsed)
			{
				AdminBtn.Image = Resources.closeArrow1;
				adminPanel.Height += 10;
				if(adminPanel.Size == adminPanel.MaximumSize)
				{
					adminTimer.Stop();
					isCollapsed = false;
				}
			}
			else
			{
				AdminBtn.Image = Resources.openArrow1;
				adminPanel.Height -= 10;
				if (adminPanel.Size == adminPanel.MinimumSize)
				{
					adminTimer.Stop();
					isCollapsed = true;
				}
			}

		}


		private void manageAcctTimer_Tick(object sender, EventArgs e)
		{
			if (isCollapsed)
			{
				manageBtn.Image = Resources.closeArrow1;
				manageAcctsPanel.Height += 10;
				if (manageAcctsPanel.Size == manageAcctsPanel.MaximumSize)
				{
					manageAcctTimer.Stop();
					isCollapsed = false;
				}
			}
			else
			{
				manageBtn.Image = Resources.openArrow1;
				manageAcctsPanel.Height -= 10;
				if (manageAcctsPanel.Size == manageAcctsPanel.MinimumSize)
				{
					manageAcctTimer.Stop();
					isCollapsed = true;
				}
			}

		}





		private void AdminBtn_Click(object sender, EventArgs e)
		{
			adminTimer.Start();
		}

		private void manageBtn_Click(object sender, EventArgs e)
		{
			manageAcctTimer.Start();
		}



		private void memberBtn_MouseHover(object sender, EventArgs e)
		{
			memberBtn.BackColor = Color.DarkGray;
		}

		private void memberBtn_MouseLeave(object sender, EventArgs e)
		{
			memberBtn.BackColor = Color.DimGray;
		}

		private void moviesBtn_MouseHover(object sender, EventArgs e)
		{
			moviesBtn.BackColor = Color.DarkGray;
		}

		private void moviesBtn_MouseLeave(object sender, EventArgs e)
		{
			moviesBtn.BackColor = Color.DimGray;
		}

		private void genreBtn_MouseHover(object sender, EventArgs e)
		{
			genreBtn.BackColor = Color.DarkGray;
		}

		private void genreBtn_MouseLeave(object sender, EventArgs e)
		{
			genreBtn.BackColor = Color.DimGray;
		}

		private void watchListBtn_MouseHover(object sender, EventArgs e)
		{
			watchListBtn.BackColor = Color.DarkGray;
		}

		private void watchListBtn_MouseLeave(object sender, EventArgs e)
		{
			watchListBtn.BackColor = Color.DimGray;
		}

		private void browseBtn_MouseHover(object sender, EventArgs e)
		{
			browseBtn.BackColor = Color.DarkGray;
		}

		private void browseBtn_MouseLeave(object sender, EventArgs e)
		{
			browseBtn.BackColor = Color.DimGray;
		}

		private void rentalsBtn_MouseHover(object sender, EventArgs e)
		{
			rentalsBtn.BackColor = Color.DarkGray;
		}

		private void rentalsBtn_MouseLeave(object sender, EventArgs e)
		{
			rentalsBtn.BackColor = Color.DimGray;
		}

		private void orderBtn_MouseHover(object sender, EventArgs e)
		{
			orderBtn.BackColor = Color.DarkGray;
		}

		private void orderBtn_MouseLeave(object sender, EventArgs e)
		{
			orderBtn.BackColor = Color.DimGray;
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Form formBackground = new Form();
			try
			{
				using (MovieDetailsForm newMoviesDetailsForm = new MovieDetailsForm())
				{
					formBackground.StartPosition = FormStartPosition.Manual;
					formBackground.FormBorderStyle = FormBorderStyle.None;
					formBackground.Opacity = .50d;
					formBackground.BackColor = Color.Black;
					formBackground.WindowState = FormWindowState.Maximized;
					formBackground.TopMost = true;
					formBackground.Location = this.Location;
					formBackground.ShowInTaskbar = false;
					formBackground.Show();

					newMoviesDetailsForm.Owner = formBackground;
					newMoviesDetailsForm.ShowDialog();

					formBackground.Dispose();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				formBackground.Dispose();
			}

		}
	}
}
