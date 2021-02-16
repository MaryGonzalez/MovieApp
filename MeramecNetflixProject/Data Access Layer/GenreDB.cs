using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MeramecNetflixProject.Business_Objectives;

namespace MeramecNetflixProject.Data_Access_Layer
{
	public static class GenreDB
	{
		public static List<Genre> GetGenres()
		{
			//Change the MyCustomObject name to your customer business object that is returning data from the specific table
			List<Genre> genreList = new List<Genre>();
			string SQLStatement = "select Genre_ID, Name from Genre order by Genre_ID";

			SqlConnection objConn = null;
			SqlCommand objCommand = null;
			SqlDataReader objReader = null;

			try
			{
				using (objConn = AccessDataSQLServer.GetConnection())
				{
					//Open the connection to the database
					objConn.Open();

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(SQLStatement, objConn))
					{
						//Execute the SQL and return a DataReader Object
						using (objReader = objCommand.ExecuteReader())
						{
							while (objReader.Read())
							{
								Genre objGenre = new Genre();
								objGenre.Genre_ID = Convert.ToInt16(objReader["Genre_ID"].ToString());
								objGenre.Name = objReader["Name"].ToString();

								//Add the genre to the collection
								genreList.Add(objGenre);
							}
						}
					}

				}

			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				if (objConn != null)
				{
					objConn.Close();
				}

			}

			return genreList;
		}



		public static Genre GetGenre(int genreID)
		{
			//Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
			string SQLStatement = String.Empty;

			//Change the MyCustomObject references  to your customer business object
			//Genre objTemp = new Genre();

			string sqlString = "Select Genre_ID, Name from Genre where Genre_ID = @genre_Genre_ID";
			SqlCommand objCommand = null;
			SqlConnection objConn = null;
			SqlDataReader objReader = null;
			Genre objGenre = null;
			try
			{
				using (objConn = AccessDataSQLServer.GetConnection())
				{
					//Open the connection to the datbase
					objConn.Open();
					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Set command parameter
						objCommand.Parameters.AddWithValue("@genre_Genre_ID", genreID);
						//Execute the SQL and return a DataReader
						using (objReader = objCommand.ExecuteReader())
						{
							while (objReader.Read())
							{
								objGenre = new Genre();
								//Fill the customer object if found
								objGenre.Genre_ID = Convert.ToInt16(objReader["Genre_ID"].ToString());
								objGenre.Name = objReader["Name"].ToString();
							}
						}
					}
					return objGenre;
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				//Finally will always be called in a try..catch..statem. You can use to to close the connection
				//especially if an error is thrown
				if (objConn != null)
				{
					objConn.Close();
				}
			}
		}


		public static bool AddGenre(Genre objGenre)
		{
			//Pre-step: Replace the general object parameter with the appropriate business class object that you are using to insert data in the underline database table 
			string SQLStatement = String.Empty;

			int rowsAffected = 0;

			SqlCommand objCommand = null;
			SqlConnection objConn = null;

			string sqlString;
			try
			{
				using (objConn = AccessDataSQLServer.GetConnection())
				{
					//Open the connection to the datbase
					objConn.Open();
					sqlString = "INSERT into Genre values (@genre_Genre_ID, @genre_Name)";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@genre_Genre_ID", objGenre.Genre_ID);
						objCommand.Parameters.AddWithValue("@genre_Name", objGenre.Name);
						//Execute the SQL and return the number of rows affected
						rowsAffected = objCommand.ExecuteNonQuery();
					}
					if (rowsAffected > 0)
					{
						return true;
					}
					else
					{
						return false;
					}

				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				//Finally will always be called in a try..catch..statem. You can use to to close the connection
				//especially if an error is thrown
				if (objConn != null)
				{
					objConn.Close();
				}
			}
		}


		public static bool UpdateGenre(Genre objGenre)
		{
			string SQLStatement = String.Empty;

			int rowsAffected = 0;

			SqlCommand objCommand = null;
			SqlConnection objConn = null;

			string sqlString;
			try
			{
				using (objConn = AccessDataSQLServer.GetConnection())
				{
					//Open the connection to the datbase
					objConn.Open();
					sqlString = "UPDATE Genre " + Environment.NewLine +
								"set name = @genre_Name " + Environment.NewLine +
								"where id = @genre_Genre_ID";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@genre_Name", objGenre.Name);
						objCommand.Parameters.AddWithValue("@genre_Genre_ID", objGenre.Genre_ID);
						//Execute the SQL and return the number of rows affected
						rowsAffected = objCommand.ExecuteNonQuery();
					}
					if (rowsAffected > 0)
					{
						return true;
					}
					else
					{
						return false;
					}

				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				//Finally will always be called in a try..catch..statem. You can use to to close the connection
				//especially if an error is thrown
				if (objConn != null)
				{
					objConn.Close();
				}
			}
		}


		public static bool DeleteGenre(Genre objGenre)
		{
			string SQLStatement = String.Empty;
			
			int rowsAffected = 0;

			SqlCommand objCommand = null;
			SqlConnection objConn = null;

			string sqlString;
			try
			{
				using (objConn = AccessDataSQLServer.GetConnection())
				{
					//Open the connection to the datbase
					objConn.Open();
					sqlString = "Delete Genre where Genre_ID = @genre_Genre_ID";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@genre_Genre_ID", objGenre.Genre_ID);

						//Execute the SQL and return the number of rows affected
						rowsAffected = objCommand.ExecuteNonQuery();
					}
					if (rowsAffected > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			finally
			{
				//Finally will always be called in a try..catch..statem. You can use to to close the connection
				//especially if an error is thrown
				if (objConn != null)
				{
					objConn.Close();
				}
			}
		}





	}
}
