namespace MeramecNetflixProject.UI
{
	partial class MovieOptionsView
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieOptionsView));
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.userIconImg = new System.Windows.Forms.PictureBox();
			this.adminPanel = new System.Windows.Forms.Panel();
			this.genreBtn = new System.Windows.Forms.Button();
			this.moviesBtn = new System.Windows.Forms.Button();
			this.memberBtn = new System.Windows.Forms.Button();
			this.AdminBtn = new System.Windows.Forms.Button();
			this.manageAcctsPanel = new System.Windows.Forms.Panel();
			this.orderBtn = new System.Windows.Forms.Button();
			this.rentalsBtn = new System.Windows.Forms.Button();
			this.browseBtn = new System.Windows.Forms.Button();
			this.watchListBtn = new System.Windows.Forms.Button();
			this.manageBtn = new System.Windows.Forms.Button();
			this.logOutBtn = new System.Windows.Forms.Button();
			this.adminTimer = new System.Windows.Forms.Timer(this.components);
			this.manageAcctTimer = new System.Windows.Forms.Timer(this.components);
			this.titleImg = new System.Windows.Forms.PictureBox();
			this.movieOptionsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.userIconImg)).BeginInit();
			this.adminPanel.SuspendLayout();
			this.manageAcctsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.titleImg)).BeginInit();
			this.movieOptionsFlowPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.userIconImg);
			this.flowLayoutPanel1.Controls.Add(this.adminPanel);
			this.flowLayoutPanel1.Controls.Add(this.manageAcctsPanel);
			this.flowLayoutPanel1.Controls.Add(this.logOutBtn);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1102, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(262, 690);
			this.flowLayoutPanel1.TabIndex = 35;
			// 
			// userIconImg
			// 
			this.userIconImg.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.userIconImg.Image = global::MeramecNetflixProject.Properties.Resources.profile1;
			this.userIconImg.Location = new System.Drawing.Point(3, 3);
			this.userIconImg.Name = "userIconImg";
			this.userIconImg.Size = new System.Drawing.Size(78, 60);
			this.userIconImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.userIconImg.TabIndex = 21;
			this.userIconImg.TabStop = false;
			// 
			// adminPanel
			// 
			this.adminPanel.Controls.Add(this.genreBtn);
			this.adminPanel.Controls.Add(this.moviesBtn);
			this.adminPanel.Controls.Add(this.memberBtn);
			this.adminPanel.Controls.Add(this.AdminBtn);
			this.adminPanel.Location = new System.Drawing.Point(3, 69);
			this.adminPanel.MaximumSize = new System.Drawing.Size(200, 161);
			this.adminPanel.MinimumSize = new System.Drawing.Size(200, 40);
			this.adminPanel.Name = "adminPanel";
			this.adminPanel.Size = new System.Drawing.Size(200, 40);
			this.adminPanel.TabIndex = 37;
			// 
			// genreBtn
			// 
			this.genreBtn.BackColor = System.Drawing.Color.DimGray;
			this.genreBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.genreBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.genreBtn.FlatAppearance.BorderSize = 0;
			this.genreBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.genreBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.genreBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.genreBtn.Location = new System.Drawing.Point(0, 120);
			this.genreBtn.Name = "genreBtn";
			this.genreBtn.Size = new System.Drawing.Size(200, 40);
			this.genreBtn.TabIndex = 40;
			this.genreBtn.Text = "Genres";
			this.genreBtn.UseVisualStyleBackColor = false;
			this.genreBtn.Click += new System.EventHandler(this.genreBtn_Click);
			this.genreBtn.MouseLeave += new System.EventHandler(this.genreBtn_MouseLeave);
			this.genreBtn.MouseHover += new System.EventHandler(this.genreBtn_MouseHover);
			// 
			// moviesBtn
			// 
			this.moviesBtn.BackColor = System.Drawing.Color.DimGray;
			this.moviesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.moviesBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.moviesBtn.FlatAppearance.BorderSize = 0;
			this.moviesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.moviesBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.moviesBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.moviesBtn.Location = new System.Drawing.Point(0, 80);
			this.moviesBtn.Name = "moviesBtn";
			this.moviesBtn.Size = new System.Drawing.Size(200, 40);
			this.moviesBtn.TabIndex = 39;
			this.moviesBtn.Text = "Movies";
			this.moviesBtn.UseVisualStyleBackColor = false;
			this.moviesBtn.Click += new System.EventHandler(this.moviesBtn_Click);
			this.moviesBtn.MouseLeave += new System.EventHandler(this.moviesBtn_MouseLeave);
			this.moviesBtn.MouseHover += new System.EventHandler(this.moviesBtn_MouseHover);
			// 
			// memberBtn
			// 
			this.memberBtn.BackColor = System.Drawing.Color.DimGray;
			this.memberBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.memberBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.memberBtn.FlatAppearance.BorderSize = 0;
			this.memberBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.memberBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memberBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.memberBtn.Location = new System.Drawing.Point(0, 40);
			this.memberBtn.Name = "memberBtn";
			this.memberBtn.Size = new System.Drawing.Size(200, 40);
			this.memberBtn.TabIndex = 38;
			this.memberBtn.Text = "Members";
			this.memberBtn.UseVisualStyleBackColor = false;
			this.memberBtn.Click += new System.EventHandler(this.memberBtn_Click);
			this.memberBtn.MouseLeave += new System.EventHandler(this.memberBtn_MouseLeave);
			this.memberBtn.MouseHover += new System.EventHandler(this.memberBtn_MouseHover);
			// 
			// AdminBtn
			// 
			this.AdminBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.AdminBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.AdminBtn.FlatAppearance.BorderSize = 0;
			this.AdminBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AdminBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AdminBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.AdminBtn.Image = ((System.Drawing.Image)(resources.GetObject("AdminBtn.Image")));
			this.AdminBtn.Location = new System.Drawing.Point(0, 0);
			this.AdminBtn.Name = "AdminBtn";
			this.AdminBtn.Size = new System.Drawing.Size(200, 40);
			this.AdminBtn.TabIndex = 37;
			this.AdminBtn.Text = "Administration";
			this.AdminBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.AdminBtn.UseVisualStyleBackColor = true;
			this.AdminBtn.Click += new System.EventHandler(this.AdminBtn_Click);
			// 
			// manageAcctsPanel
			// 
			this.manageAcctsPanel.Controls.Add(this.orderBtn);
			this.manageAcctsPanel.Controls.Add(this.rentalsBtn);
			this.manageAcctsPanel.Controls.Add(this.browseBtn);
			this.manageAcctsPanel.Controls.Add(this.watchListBtn);
			this.manageAcctsPanel.Controls.Add(this.manageBtn);
			this.manageAcctsPanel.Location = new System.Drawing.Point(3, 115);
			this.manageAcctsPanel.MaximumSize = new System.Drawing.Size(200, 199);
			this.manageAcctsPanel.MinimumSize = new System.Drawing.Size(200, 37);
			this.manageAcctsPanel.Name = "manageAcctsPanel";
			this.manageAcctsPanel.Size = new System.Drawing.Size(200, 37);
			this.manageAcctsPanel.TabIndex = 36;
			// 
			// orderBtn
			// 
			this.orderBtn.BackColor = System.Drawing.Color.DimGray;
			this.orderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.orderBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.orderBtn.FlatAppearance.BorderSize = 0;
			this.orderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.orderBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.orderBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.orderBtn.Location = new System.Drawing.Point(0, 157);
			this.orderBtn.Name = "orderBtn";
			this.orderBtn.Size = new System.Drawing.Size(200, 40);
			this.orderBtn.TabIndex = 41;
			this.orderBtn.Text = "Order Movies";
			this.orderBtn.UseVisualStyleBackColor = false;
			this.orderBtn.MouseLeave += new System.EventHandler(this.orderBtn_MouseLeave);
			this.orderBtn.MouseHover += new System.EventHandler(this.orderBtn_MouseHover);
			// 
			// rentalsBtn
			// 
			this.rentalsBtn.BackColor = System.Drawing.Color.DimGray;
			this.rentalsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rentalsBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.rentalsBtn.FlatAppearance.BorderSize = 0;
			this.rentalsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rentalsBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rentalsBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.rentalsBtn.Location = new System.Drawing.Point(0, 117);
			this.rentalsBtn.Name = "rentalsBtn";
			this.rentalsBtn.Size = new System.Drawing.Size(200, 40);
			this.rentalsBtn.TabIndex = 40;
			this.rentalsBtn.Text = "View Rentals";
			this.rentalsBtn.UseVisualStyleBackColor = false;
			this.rentalsBtn.MouseLeave += new System.EventHandler(this.rentalsBtn_MouseLeave);
			this.rentalsBtn.MouseHover += new System.EventHandler(this.rentalsBtn_MouseHover);
			// 
			// browseBtn
			// 
			this.browseBtn.BackColor = System.Drawing.Color.DimGray;
			this.browseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.browseBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.browseBtn.FlatAppearance.BorderSize = 0;
			this.browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.browseBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.browseBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.browseBtn.Location = new System.Drawing.Point(0, 77);
			this.browseBtn.Name = "browseBtn";
			this.browseBtn.Size = new System.Drawing.Size(200, 40);
			this.browseBtn.TabIndex = 39;
			this.browseBtn.Text = "Browse Inventory";
			this.browseBtn.UseVisualStyleBackColor = false;
			this.browseBtn.MouseLeave += new System.EventHandler(this.browseBtn_MouseLeave);
			this.browseBtn.MouseHover += new System.EventHandler(this.browseBtn_MouseHover);
			// 
			// watchListBtn
			// 
			this.watchListBtn.BackColor = System.Drawing.Color.DimGray;
			this.watchListBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.watchListBtn.FlatAppearance.BorderSize = 0;
			this.watchListBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.watchListBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.watchListBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.watchListBtn.Location = new System.Drawing.Point(0, 37);
			this.watchListBtn.Name = "watchListBtn";
			this.watchListBtn.Size = new System.Drawing.Size(200, 40);
			this.watchListBtn.TabIndex = 1;
			this.watchListBtn.Text = "Create Watch List";
			this.watchListBtn.UseVisualStyleBackColor = false;
			this.watchListBtn.MouseLeave += new System.EventHandler(this.watchListBtn_MouseLeave);
			this.watchListBtn.MouseHover += new System.EventHandler(this.watchListBtn_MouseHover);
			// 
			// manageBtn
			// 
			this.manageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.manageBtn.Dock = System.Windows.Forms.DockStyle.Top;
			this.manageBtn.FlatAppearance.BorderSize = 0;
			this.manageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.manageBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.manageBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.manageBtn.Image = ((System.Drawing.Image)(resources.GetObject("manageBtn.Image")));
			this.manageBtn.Location = new System.Drawing.Point(0, 0);
			this.manageBtn.Name = "manageBtn";
			this.manageBtn.Size = new System.Drawing.Size(200, 37);
			this.manageBtn.TabIndex = 0;
			this.manageBtn.Text = "Manage Accounts";
			this.manageBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.manageBtn.UseVisualStyleBackColor = true;
			this.manageBtn.Click += new System.EventHandler(this.manageBtn_Click);
			// 
			// logOutBtn
			// 
			this.logOutBtn.BackColor = System.Drawing.Color.Black;
			this.logOutBtn.FlatAppearance.BorderSize = 0;
			this.logOutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.logOutBtn.Font = new System.Drawing.Font("Franklin Gothic Book", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logOutBtn.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.logOutBtn.Location = new System.Drawing.Point(3, 158);
			this.logOutBtn.Name = "logOutBtn";
			this.logOutBtn.Size = new System.Drawing.Size(200, 37);
			this.logOutBtn.TabIndex = 38;
			this.logOutBtn.Text = "Log Out";
			this.logOutBtn.UseVisualStyleBackColor = false;
			this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click);
			// 
			// adminTimer
			// 
			this.adminTimer.Interval = 10;
			this.adminTimer.Tick += new System.EventHandler(this.adminTimer_Tick);
			// 
			// manageAcctTimer
			// 
			this.manageAcctTimer.Interval = 10;
			this.manageAcctTimer.Tick += new System.EventHandler(this.manageAcctTimer_Tick);
			// 
			// titleImg
			// 
			this.titleImg.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.titleImg.Image = global::MeramecNetflixProject.Properties.Resources.title;
			this.titleImg.Location = new System.Drawing.Point(263, 22);
			this.titleImg.Name = "titleImg";
			this.titleImg.Size = new System.Drawing.Size(670, 112);
			this.titleImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.titleImg.TabIndex = 23;
			this.titleImg.TabStop = false;
			// 
			// movieOptionsFlowPanel
			// 
			this.movieOptionsFlowPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.movieOptionsFlowPanel.AutoScroll = true;
			this.movieOptionsFlowPanel.Controls.Add(this.pictureBox1);
			this.movieOptionsFlowPanel.Location = new System.Drawing.Point(23, 46);
			this.movieOptionsFlowPanel.Name = "movieOptionsFlowPanel";
			this.movieOptionsFlowPanel.Size = new System.Drawing.Size(1279, 693);
			this.movieOptionsFlowPanel.TabIndex = 36;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(3, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(8, 8);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// MovieOptionsView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1364, 690);
			this.Controls.Add(this.movieOptionsFlowPanel);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.titleImg);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MovieOptionsView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Movies with Meramec";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MovieOptionsView_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.userIconImg)).EndInit();
			this.adminPanel.ResumeLayout(false);
			this.manageAcctsPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.titleImg)).EndInit();
			this.movieOptionsFlowPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox userIconImg;
		private System.Windows.Forms.PictureBox titleImg;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel adminPanel;
		private System.Windows.Forms.Button genreBtn;
		private System.Windows.Forms.Button moviesBtn;
		private System.Windows.Forms.Button memberBtn;
		private System.Windows.Forms.Button AdminBtn;
		private System.Windows.Forms.Timer adminTimer;
		private System.Windows.Forms.Panel manageAcctsPanel;
		private System.Windows.Forms.Button orderBtn;
		private System.Windows.Forms.Button rentalsBtn;
		private System.Windows.Forms.Button browseBtn;
		private System.Windows.Forms.Button watchListBtn;
		private System.Windows.Forms.Button manageBtn;
		private System.Windows.Forms.Button logOutBtn;
		private System.Windows.Forms.Timer manageAcctTimer;
		private System.Windows.Forms.FlowLayoutPanel movieOptionsFlowPanel;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}