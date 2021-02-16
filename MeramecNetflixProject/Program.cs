using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeramecNetflixProject.UI;

namespace MeramecNetflixProject
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new MovieOptionsView());
			Application.Run(new NewMovieDataEntry());
			//Application.Run(new MemberDataEntry());
			//Application.Run(new GenreDataEntry());
			//Application.Run(new LoginDataForm());
			
		}
	}
}
