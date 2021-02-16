using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MeramecNetflixProject.Business_Objectives;
using MeramecNetflixProject.Data_Access_Layer;
using System.IO;

namespace MeramecNetflixProject.UI
{
	public partial class MemberDataEntry : Form
	{
		public MemberDataEntry()
		{
			InitializeComponent();
		}

		string imgUrl = null;
		Member objMember = new Member();

		private void MemberDataEntry_Load(object sender, EventArgs e)
		{
			PopulateComboBox();

			//Join Date
			joinDateTimePicker.Value = DateTime.Now;

			//Start focus on member number textbox
			memberNumTxt.Focus();


		}
		

		private void PopulateComboBox()
		{
			//Populate Subscription Combo Box
			subscriptionTypeComboBox.Items.Add("--Select--");
			subscriptionTypeComboBox.Items.Add("Regular");  //Cost for Regular: $5
			subscriptionTypeComboBox.Items.Add("Premium");  //Cost for Premium: $10
			subscriptionTypeComboBox.Items.Add("Deluxe");   //Cost for Deluxe: $15

			subscriptionTypeComboBox.SelectedIndex = 0;
		}

		private void BrowseBtn_Click(object sender, EventArgs e)
		{
			List<Member> myMemberList = new List<Member>();

			//Call the MemberDB database static class to populate the Member datagrid
			try
			{
				myMemberList = MemberDB.GetMembers();
				MemberDataGridView.DataSource = myMemberList;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			ClearUI();
		}

		private void uploadImageBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				imgUrl = dialog.FileName.ToString();
				memberPictureBox.ImageLocation = imgUrl;
			}


		}

		private void Addbtn_Click(object sender, EventArgs e)
		{
			ValidateInfo();	
			
			Member myMember = new Member();
			myMember.Number = Convert.ToInt32(memberNumTxt.Text);
			myMember.JoinDate = Convert.ToDateTime(joinDateTimePicker.Text);
			myMember.FirstName = firstNameTxt.Text.Trim();
			myMember.LastName = lastNameTxt.Text.Trim();
			myMember.Address = addressTxt.Text.Trim();
			myMember.City = cityTxt.Text.Trim();
			myMember.State = stateTxt.Text.Trim();
			myMember.ZipCode = zipCodeTxt.Text.Trim();
			myMember.Phone = phoneNumberTxt.Text.Replace("-", "");
			myMember.Login_Name = loginNameTxt.Text.Trim();
			myMember.Password = passwordTxt.Text.Trim();
			myMember.Email = emailTxt.Text.Trim();


			if(memberPictureBox.Image != null)
			{						
				myMember.Photo = imgUrl;
			}
			


			//Member Status Radio Button
			if (activeMemberStatusBtn.Checked == true)
			{
				myMember.Member_Status = "A";
			}
			else if(inactiveMemberStatusRadioBtn.Checked == true)
			{
				myMember.Member_Status = "I";
			}


			//Contact Method Radio Button
			if (facebookContactMethodRadioBtn.Checked == true)
			{
				myMember.Contact_Method = 1;
			}
			else if (twitterContactMethodRadioBtn.Checked == true)
			{
				myMember.Contact_Method = 2;
			}
			else if (emailContactMethodRadioBtn.Checked == true)
			{
				myMember.Contact_Method = 3;
			}
			else if (phoneContactMethodRadioBtn.Checked == true)
			{
				myMember.Contact_Method = 4;
			}

			//Subscription ComboBox - Regular, Premium, Deluxe
			if(subscriptionTypeComboBox.SelectedIndex == 1)
			{
				myMember.Subscription_ID = 1;
			}
			else if (subscriptionTypeComboBox.SelectedIndex == 2)
			{
				myMember.Subscription_ID = 2;
			}
			else if (subscriptionTypeComboBox.SelectedIndex == 3)
			{
				myMember.Subscription_ID = 3;
			}

			

			try
			{

				bool status = MemberDB.AddMember(myMember);
				if (status)
				{
					MessageBox.Show("Member Added", ",", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Member Not Added", ",", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


		}

		

		private void UpdateBtn_Click(object sender, EventArgs e)
		{

			ValidateInfo();

			Member myMember = new Member();

			memberNumTxt.Text = myMember.Number.ToString();
			joinDateTimePicker.Text = myMember.JoinDate.ToString();
			firstNameTxt.Text = myMember.FirstName.ToString();
			lastNameTxt.Text = myMember.LastName.ToString();
			addressTxt.Text = myMember.Address.ToString();
			cityTxt.Text = myMember.City.ToString();
			stateTxt.Text = myMember.State.ToString();
			zipCodeTxt.Text = myMember.ZipCode.ToString();
			phoneNumberTxt.Text = myMember.Phone.ToString();
			loginNameTxt.Text = myMember.Login_Name.ToString();
			passwordTxt.Text = myMember.Password.ToString();
			emailTxt.Text = myMember.Email.ToString();
			
			myMember.Photo = memberPictureBox.Text;

			try
			{

				bool status = MemberDB.UpdateMember(myMember);
				if (status)
				{
					MessageBox.Show("Member Updated", ",", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Member Not Updated", ",", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		

		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			//Member objMember = new Member();

			//Have user verify deletion
			DialogResult result = MessageBox.Show("Are you sure you want to delete this member? This action cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


			//ValidateInfo();

			if (result == DialogResult.Yes)
			{

				objMember.Number = Convert.ToInt32(memberNumTxt.Text);
				objMember.JoinDate = Convert.ToDateTime(joinDateTimePicker.Text);
				objMember.FirstName = firstNameTxt.Text.Trim();
				objMember.LastName = lastNameTxt.Text.Trim();
				objMember.Address = addressTxt.Text.Trim();
				objMember.City = cityTxt.Text.Trim();
				objMember.State = stateTxt.Text.Trim();
				objMember.ZipCode = zipCodeTxt.Text.Trim();
				objMember.Phone = phoneNumberTxt.Text.Replace("-", "");
				objMember.Login_Name = loginNameTxt.Text.Trim();
				objMember.Password = passwordTxt.Text.Trim();
				objMember.Email = emailTxt.Text.Trim();
				objMember.Subscription_ID = Convert.ToInt16(subscriptionTypeComboBox.Text);
				objMember.Photo = memberPictureBox.Text;

				////Member Status Radio Button
				if (activeMemberStatusBtn.Checked == true)
				{
					objMember.Member_Status = "A";
				}
				else if (inactiveMemberStatusRadioBtn.Checked == true)
				{
					objMember.Member_Status = "I";
				}


				////Contact Method Radio Button
				if (facebookContactMethodRadioBtn.Checked == true)
				{
					objMember.Contact_Method = 1;
				}
				else if (twitterContactMethodRadioBtn.Checked == true)
				{
					objMember.Contact_Method = 2;
				}
				else if (emailContactMethodRadioBtn.Checked == true)
				{
					objMember.Contact_Method = 3;
				}
				else if (phoneContactMethodRadioBtn.Checked == true)
				{
					objMember.Contact_Method = 4;
				}


				try
				{
					bool status = MemberDB.DeleteMember(objMember);
					if (status) //You can use this syntax as well..if (status ==true)
					{
						MessageBox.Show("Member was deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Member was not deleted from the database.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}
		private void ClearUI()
		{
			//Member Status
			activeMemberStatusBtn.Checked = false;
			inactiveMemberStatusRadioBtn.Checked = false;

			//Contact Method
			facebookContactMethodRadioBtn.Checked = false;
			twitterContactMethodRadioBtn.Checked = false;
			emailContactMethodRadioBtn.Checked = false;
			phoneContactMethodRadioBtn.Checked = false;

			//Member Number
			memberNumTxt.Clear();

			//Join Date
			joinDateTimePicker.Value = DateTime.Now;

			//First, Last, Address, City, State, Zip Code, Phone Number, Login Name, Password, Email
			firstNameTxt.Clear();
			lastNameTxt.Clear();
			addressTxt.Clear();
			cityTxt.Clear();
			stateTxt.Clear();
			zipCodeTxt.Clear();
			phoneNumberTxt.Clear();
			loginNameTxt.Clear();
			passwordTxt.Clear();
			emailTxt.Clear();
			
			//Subscription Type Combo Box
			subscriptionTypeComboBox.SelectedIndex = 0;

			//Image
			memberPictureBox.Image = Properties.Resources._22_223965_no_profile_picture_icon_circle_member_icon_png;

			//Grid View
			MemberDataGridView.DataSource = null;

		}

		

		private void ValidateInfo()
		{

			//Member Status: radio btn
			if(activeMemberStatusBtn.Checked == false && inactiveMemberStatusRadioBtn.Checked == false)
			{
				MessageBox.Show("Member Status is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//Contact Method - Can be null: radio btn

			//Member Number
			if (memberNumTxt.Text == String.Empty)
			{
				MessageBox.Show("Member number is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				memberNumTxt.Focus();
				return;
			}

			//Join Date
			if (joinDateTimePicker.Value.ToString() == "")
			{
				MessageBox.Show("Member join date is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				joinDateTimePicker.Focus();
				return;
			}

			if(joinDateTimePicker.Value > DateTime.Today)
			{
				MessageBox.Show("Please select a valid date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				joinDateTimePicker.Focus();
				return;
			}

			//Subscription Type
			if (subscriptionTypeComboBox.SelectedIndex == 0)
			{
				MessageBox.Show("No subscription type selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				subscriptionTypeComboBox.Focus();
				return;
			}


			//First name
			if (firstNameTxt.Text == String.Empty)
			{
				MessageBox.Show("Member's first name is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				firstNameTxt.Focus();
				return;
			}

			//Last Name
			if (lastNameTxt.Text == String.Empty)
			{
				MessageBox.Show("Member's last name is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				lastNameTxt.Focus();
				return;
			}

			//Address
			if (addressTxt.Text == String.Empty)
			{
				MessageBox.Show("Member's address is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				addressTxt.Focus();
				return;
			}

			//City
			if (cityTxt.Text == String.Empty)
			{
				MessageBox.Show("Member's city is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cityTxt.Focus();
				return;
			}

			//State
			if (stateTxt.Text == String.Empty)
			{
				MessageBox.Show("Member's  state is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				stateTxt.Focus();
				return;
			}

			if(stateTxt.Text.Length != 2)
			{
				MessageBox.Show("Please use state's abbreviation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				stateTxt.Focus();
				return;
			}
			//Zip code
			if (zipCodeTxt.Text == String.Empty)
			{
				MessageBox.Show("Member's zip code is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				zipCodeTxt.Focus();
				return;
			}

			//Zip code length
			if(zipCodeTxt.TextLength != 5)
			{
				MessageBox.Show("Zip code is 'xxxxx' ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				zipCodeTxt.Focus();
				return;
			}

			//Phone number
			if (phoneNumberTxt.Text == String.Empty)
			{
				MessageBox.Show("Member Phone Number is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				phoneNumberTxt.Focus();
				return;
			}
			
			//Check length of phone number, accepts number with or without area code
			if(phoneNumberTxt.Text.Length != 10)
			{
				MessageBox.Show("Phone Number is 'xxx-xxx-xxxx'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				phoneNumberTxt.Focus();
				return;
			}
			
			//Login name
			if (loginNameTxt.Text == String.Empty)
			{
				MessageBox.Show("Member's login name is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				loginNameTxt.Focus();
				return;
			}

			//Login name length
			if(loginNameTxt.Text.Length > 20)
			{
				MessageBox.Show("Login name is too long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				loginNameTxt.Focus();
				return;
			}

			//Password
			if (passwordTxt.Text == String.Empty)
			{
				MessageBox.Show("Member's password is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				passwordTxt.Focus();
				return;
			}

			//Password length
			if(passwordTxt.Text.Length > 20)
			{
				MessageBox.Show("Password is too long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				passwordTxt.Focus();
				return;
			}

			//Validate email isn't blank
			if (emailTxt.Text == String.Empty)
			{
				MessageBox.Show("Member Email is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				emailTxt.Focus();
				return;
			}


			//Photo - can be null

		}

		
		private void emailTxt_Leave(object sender, EventArgs e)
		{
			//Validate correct email format
			string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

			if (Regex.IsMatch(emailTxt.Text, pattern))
			{
				emailErrorProvider.Clear();
			}
			else
			{
				emailErrorProvider.SetError(this.emailTxt, "Please provide valid email address");
				return;
			}
		}

		private void firstNameTxt_Leave(object sender, EventArgs e)
		{
			string pattern = "^[a-zA-Z]";

			if(Regex.IsMatch(firstNameTxt.Text, pattern))
			{
				FirstNameErrorProvider.Clear();
			}
			else
			{
				FirstNameErrorProvider.SetError(this.firstNameTxt, "Please provide a first name");
				return;
			}
		}

		private void lastNameTxt_Leave(object sender, EventArgs e)
		{
			string pattern = "^[a-zA-Z]";

			if (Regex.IsMatch(lastNameTxt.Text, pattern))
			{
				LastNameErrorProvider.Clear();
			}
			else
			{
				LastNameErrorProvider.SetError(this.lastNameTxt, "Please provide a last name");
				return;
			}
		}

		private void memberNumTxt_Leave(object sender, EventArgs e)
		{
			string pattern = "[0-9]";

			if(Regex.IsMatch(memberNumTxt.Text, pattern))
			{
				MemberNumberErrorProvider.Clear();
			}
			else
			{
				MemberNumberErrorProvider.SetError(this.memberNumTxt, "Please provide member number");
				return;
			}
		}

		private void addressTxt_Leave(object sender, EventArgs e)
		{
			string pattern = "^[0-9a-zA-Z]";

			if (Regex.IsMatch(addressTxt.Text, pattern))
			{
				AddressErrorProvider.Clear();
			}
			else
			{
				AddressErrorProvider.SetError(this.addressTxt, "Please provide an address");
				return;
			}
		}

		private void cityTxt_Leave(object sender, EventArgs e)
		{
			string pattern = "^[a-zA-Z]";

			if (Regex.IsMatch(cityTxt.Text, pattern))
			{
				CityErrorProvider.Clear();
			}
			else
			{
				CityErrorProvider.SetError(this.cityTxt, "Please provide a city");
				return;
			}
		}

		private void stateTxt_Leave(object sender, EventArgs e)
		{
			string pattern = "^[a-zA-Z]";

			if (Regex.IsMatch(stateTxt.Text, pattern))
			{
				StateErrorProvider.Clear();
			}
			else
			{
				StateErrorProvider.SetError(this.stateTxt, "Please provide a state");
				return;
			}
		}

		private void backBtn_Click(object sender, EventArgs e)
		{
			MovieOptionsView newMemberForm = new MovieOptionsView();
			newMemberForm.Show();
			this.Hide();
		}

		private void MemberDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex >= 0)
			{

				DataGridViewRow row = this.MemberDataGridView.Rows[e.RowIndex];

				////Member Status -> 8
				char memberStatus;
				string statusString = row.Cells[9].Value.ToString();

				if (char.TryParse(statusString, out memberStatus))
				{
					if (memberStatus == 'A')
					{
						activeMemberStatusBtn.Checked = true;
					}
					else if(memberStatus == 'I')
					{
						inactiveMemberStatusRadioBtn.Checked = true;
					}
				}
				

				//Contact Method
				int contactMethod;
				string contactString = row.Cells[13].Value.ToString();
				
				if (int.TryParse(contactString, out contactMethod))
				{
					if (contactMethod == 1)
					{
						facebookContactMethodRadioBtn.Checked = true;
					}

					else if (contactMethod == 2)
					{
						twitterContactMethodRadioBtn.Checked = true;
					}
					else if (contactMethod == 3)
					{
						emailContactMethodRadioBtn.Checked = true;
					}
					else if (contactMethod == 4)
					{
						phoneContactMethodRadioBtn.Checked = true;
					}
				}
			
				//Member Number
				memberNumTxt.Text = row.Cells[0].Value.ToString();

				//Join Date
				joinDateTimePicker.Text = row.Cells[1].Value.ToString();

				
				//Subscription Type
				int subscription;
				string subscriptionString = row.Cells[14].Value.ToString();

				if (int.TryParse(subscriptionString, out subscription))
				{
					if (subscription == 1)
					{
						subscriptionTypeComboBox.SelectedIndex = 1;
					}

					else if (subscription == 2)
					{
						subscriptionTypeComboBox.SelectedIndex = 2;
					}
					else if (subscription == 3)
					{
						subscriptionTypeComboBox.SelectedIndex = 3;
					}
					
				}


				firstNameTxt.Text = row.Cells[2].Value.ToString();
				lastNameTxt.Text = row.Cells[3].Value.ToString();
				addressTxt.Text = row.Cells[4].Value.ToString();
				cityTxt.Text = row.Cells[5].Value.ToString();
				stateTxt.Text = row.Cells[6].Value.ToString();
				zipCodeTxt.Text = row.Cells[7].Value.ToString();

				
				phoneNumberTxt.Text = row.Cells[8].Value.ToString();
				emailTxt.Text = row.Cells[12].Value.ToString();
				loginNameTxt.Text = row.Cells[10].Value.ToString();
				passwordTxt.Text = row.Cells[11].Value.ToString();



				//Picture box			
				string picture = row.Cells[15].Value.ToString();
				memberPictureBox.ImageLocation = picture;

			}
		}


	}
}
