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
	public partial class LoginDataForm : Form
	{
		public LoginDataForm()
		{
			InitializeComponent();
		}

		private void LoginDataForm_Load(object sender, EventArgs e)
		{

		}		

		private void loginBtn_Click(object sender, EventArgs e)
		{

			if (string.IsNullOrEmpty(loginTxt.Text.Trim()))
			{
				MessageBox.Show("Please enter a username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				loginTxt.Focus();
				return;
			}

			if (string.IsNullOrEmpty(PasswordTxt.Text.Trim()))
			{
				MessageBox.Show("Please enter a password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				PasswordTxt.Focus();
				return;
			}

			List<Member> memberLoginList = new List<Member>();
			memberLoginList = LoginDB.GetMemberLogin();

			Member objLogin = new Member();



			
			if (objLogin != null)
			{

				foreach(Member item in memberLoginList)
				{					
					if (loginTxt.Text == item.Login_Name && PasswordTxt.Text == item.Password)
					{
						MovieOptionsView newMovieOptionsForm = new MovieOptionsView();
						newMovieOptionsForm.Show();
						this.Hide();
					}
					
				}
				
			}else{
						MessageBox.Show("Username or password is incorrect.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

					}
			
		}

		
	}
}
