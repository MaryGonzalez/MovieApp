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
	public partial class GenreDataEntry : Form
	{
		public GenreDataEntry()
		{
			InitializeComponent();
		}

		private void GenreDataEntry_Load(object sender, EventArgs e)
		{

		}

		
		private void btnClear_Click(object sender, EventArgs e)
		{
			txtGenreID.ReadOnly = false;
			txtGenreID.Text = String.Empty;
			txtGenreName.Text = String.Empty;
			dataGridView1.DataSource = null;
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			//Validate the UI
			if (string.IsNullOrEmpty(txtGenreID.Text.Trim()))
			{
				MessageBox.Show("Please enter a genre id.");
				txtGenreID.Focus();
				return;
			}

			if (string.IsNullOrEmpty(txtGenreName.Text.Trim()))
			{
				MessageBox.Show("Please enter a genre name.");
				txtGenreID.Focus();
				return;
			}

			Genre objGenre = new Genre();
			objGenre.Genre_ID = Convert.ToInt16(txtGenreID.Text);
			objGenre.Name = txtGenreName.Text.Trim();

			try
			{
				bool status = GenreDB.DeleteGenre(objGenre);
				if (status) //You can use this syntax as well..if (status ==true)
				{
					MessageBox.Show("Genre was deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Genre was not deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			//Validate the UI
			if (string.IsNullOrEmpty(txtGenreID.Text.Trim()))
			{
				MessageBox.Show("Please enter a genre id.");
				txtGenreID.Focus();
				return;
			}

			if (string.IsNullOrEmpty(txtGenreName.Text.Trim()))
			{
				MessageBox.Show("Please enter a genre name.");
				txtGenreID.Focus();
				return;
			}

			Genre objGenre = new Genre();
			objGenre.Genre_ID = Convert.ToInt16(txtGenreID.Text);
			objGenre.Name = txtGenreName.Text.Trim();

			try
			{
				bool status = GenreDB.UpdateGenre(objGenre);
				if (status) //You can use this syntax as well..if (status ==true)
				{
					MessageBox.Show("Genre has been updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Genre was not updated in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			//Call the GenreDB static class to fill the data grid
			try
			{
				List<Genre> genreList = new List<Genre>();
				genreList = GenreDB.GetGenres();
				dataGridView1.DataSource = genreList;

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			//Validate the UI
			if (string.IsNullOrEmpty(txtGenreID.Text.Trim()))
			{
				MessageBox.Show("Please enter a genre id.");
				txtGenreID.Focus();
				return;
			}

			Genre objGenre = GenreDB.GetGenre(Convert.ToInt32(txtGenreID.Text.Trim()));
			//Step 2: Validate to make sure the Customer object is not null.
			if (objGenre != null)
			{
				//Populate the UI with the object values
				txtGenreName.Text = objGenre.Name;
				//make Genre ID field read-only to be used for updating and deleting records demo
				txtGenreID.ReadOnly = true;
			}
			else
			{
				MessageBox.Show("Genre ID " + txtGenreID.Text.Trim() + " not found in database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			//Validate the UI
			if (string.IsNullOrEmpty(txtGenreID.Text.Trim()))
			{
				MessageBox.Show("Please enter a genre id.");
				txtGenreID.Focus();
				return;
			}

			if (string.IsNullOrEmpty(txtGenreName.Text.Trim()))
			{
				MessageBox.Show("Please enter a genre name.");
				txtGenreName.Focus();
				return;
			}

			Genre objGenre = new Genre();
			objGenre.Genre_ID = Convert.ToInt16(txtGenreID.Text);
			objGenre.Name = txtGenreName.Text.Trim();
			try
			{
				bool status = GenreDB.AddGenre(objGenre);
				if (status) //You can use this syntax as well..if (status ==true)
				{
					MessageBox.Show("Genre added to the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txtGenreID.Clear();
					txtGenreName.Clear();
				}
				else
				{
					MessageBox.Show("Genre was not added to database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


		}

		private void backBtn_Click(object sender, EventArgs e)
		{
			MovieOptionsView newOptionsForm = new MovieOptionsView();
			newOptionsForm.Show();
			this.Hide();

		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex >= 0)
			{
				DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

				txtGenreID.Text = row.Cells[0].Value.ToString();
				txtGenreName.Text = row.Cells[1].Value.ToString();
			}
		}
	}
}
