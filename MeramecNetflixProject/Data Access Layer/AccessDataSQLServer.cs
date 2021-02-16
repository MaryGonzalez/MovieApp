using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MeramecNetflixProject.Data_Access_Layer
{
	public static class AccessDataSQLServer
	{
		public static SqlConnection GetConnection()
		{
			string connectionString = "server=mc-sluggo.stlcc.edu; database=IS253_Gonzalez; user=gonzalez; password=gonzalez";
			SqlConnection connection = new SqlConnection(connectionString);
			return connection;
		}

	}
}
