namespace MeramecNetflixProject.UI
{
	partial class LoginDataForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDataForm));
			this.loginTxt = new System.Windows.Forms.TextBox();
			this.PasswordTxt = new System.Windows.Forms.TextBox();
			this.signUpBtn = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.loginBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// loginTxt
			// 
			this.loginTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.loginTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loginTxt.Location = new System.Drawing.Point(644, 400);
			this.loginTxt.Name = "loginTxt";
			this.loginTxt.Size = new System.Drawing.Size(185, 26);
			this.loginTxt.TabIndex = 1;
			// 
			// PasswordTxt
			// 
			this.PasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.PasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordTxt.Location = new System.Drawing.Point(644, 452);
			this.PasswordTxt.Name = "PasswordTxt";
			this.PasswordTxt.PasswordChar = '*';
			this.PasswordTxt.Size = new System.Drawing.Size(185, 26);
			this.PasswordTxt.TabIndex = 2;
			// 
			// signUpBtn
			// 
			this.signUpBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.signUpBtn.BackColor = System.Drawing.Color.SlateGray;
			this.signUpBtn.FlatAppearance.BorderSize = 0;
			this.signUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.signUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.signUpBtn.ForeColor = System.Drawing.Color.White;
			this.signUpBtn.Location = new System.Drawing.Point(786, 579);
			this.signUpBtn.Name = "signUpBtn";
			this.signUpBtn.Size = new System.Drawing.Size(118, 32);
			this.signUpBtn.TabIndex = 4;
			this.signUpBtn.TabStop = false;
			this.signUpBtn.Text = "SIGN UP NOW";
			this.signUpBtn.UseVisualStyleBackColor = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureBox1.Image = global::MeramecNetflixProject.Properties.Resources.Movies22;
			this.pictureBox1.Location = new System.Drawing.Point(360, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(622, 670);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// loginBtn
			// 
			this.loginBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.loginBtn.BackColor = System.Drawing.Color.SlateGray;
			this.loginBtn.FlatAppearance.BorderSize = 0;
			this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loginBtn.ForeColor = System.Drawing.Color.White;
			this.loginBtn.Location = new System.Drawing.Point(677, 493);
			this.loginBtn.Name = "loginBtn";
			this.loginBtn.Size = new System.Drawing.Size(122, 34);
			this.loginBtn.TabIndex = 7;
			this.loginBtn.TabStop = false;
			this.loginBtn.Text = "LOG IN";
			this.loginBtn.UseVisualStyleBackColor = false;
			this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
			// 
			// LoginDataForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1284, 701);
			this.Controls.Add(this.loginBtn);
			this.Controls.Add(this.signUpBtn);
			this.Controls.Add(this.PasswordTxt);
			this.Controls.Add(this.loginTxt);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "LoginDataForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Movies with Meramec";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.LoginDataForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox loginTxt;
		private System.Windows.Forms.TextBox PasswordTxt;
		private System.Windows.Forms.Button signUpBtn;
		private System.Windows.Forms.Button loginBtn;
	}
}