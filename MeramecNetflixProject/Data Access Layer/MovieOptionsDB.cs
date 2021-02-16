using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MeramecNetflixProject.Business_Objectives;

namespace MeramecNetflixProject.Data_Access_Layer
{
	public static class MovieOptionsDB
	{
		public static List<MovieOptions> GetMovieOptions()
		{
			//Change the MyCustomObject name to your customer business object that is returning data from the specific table
			List<MovieOptions> movieOptionsList = new List<MovieOptions>();
			string SQLStatement = "select Movie_Number, Movie_Title, Description, Movie_Year_Made,Genre_ID, Movie_Rating, Media_Type, Movie_Retail_Cost, Copies_On_Hand, Image, Trailer from Movie order by Movie_Number";

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
								MovieOptions objmovieOptions = new MovieOptions();								
								objmovieOptions.Movie_Number = Convert.ToInt32(objReader["Movie_Number"].ToString());
								objmovieOptions.Movie_Title = objReader["Movie_Title"].ToString();
								objmovieOptions.Description = objReader["Description"].ToString();
								objmovieOptions.Movie_Year_Made = Convert.ToInt16(objReader["Movie_Year_Made"].ToString());
								objmovieOptions.Genre_ID = Convert.ToInt16(objReader["Genre_ID"].ToString());
								objmovieOptions.Movie_Rating = (objReader["Movie_Rating"].ToString());
								objmovieOptions.Media_Type = objReader["Media_Type"].ToString();
								objmovieOptions.Movie_Retail_Cost = objReader["Movie_Retail_Cost"].ToString();
								objmovieOptions.Copies_On_Hand = Convert.ToInt16(objReader["Copies_On_Hand"].ToString());
								objmovieOptions.Image = objReader["Image"].ToString();
								objmovieOptions.Trailer = objReader["Trailer"].ToString();

								//Add the genre to the collection
								movieOptionsList.Add(objmovieOptions);
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

			return movieOptionsList;
		}



		public static MovieOptions GetMovieOptions(int movieOptionsID)
		{
			//Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
			string SQLStatement = String.Empty;

			//Change the MyCustomObject references  to your customer business object
			//Genre objTemp = new Genre();

			string sqlString = "Select Movie_Number, Movie_Title, Description, Movie_Year_Made,Genre_ID, Movie_Rating, Media_Type, Movie_Retail_Cost, Copies_On_Hand, Image, Trailer from NewMovie where Movie_Number = @NewMovie_Movie_Number";
			SqlCommand objCommand = null;
			SqlConnection objConn = null;
			SqlDataReader objReader = null;
			MovieOptions objmovieOptions = null;
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
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Number", movieOptionsID);
						//Execute the SQL and return a DataReader
						using (objReader = objCommand.ExecuteReader())
						{
							while (objReader.Read())
							{
								objmovieOptions = new MovieOptions();
								//Fill the customer object if found
								objmovieOptions.Movie_Number = Convert.ToInt32(objReader["Movie_Number"].ToString());
								objmovieOptions.Movie_Title = objReader["Movie_Title"].ToString();
								objmovieOptions.Description = objReader["Description"].ToString();
								objmovieOptions.Movie_Year_Made = Convert.ToInt16(objReader["Movie_Year_Made"].ToString());
								objmovieOptions.Genre_ID = Convert.ToInt16(objReader["Genre_ID"].ToString());
								objmovieOptions.Movie_Rating = (objReader["Movie_Rating"].ToString());
								objmovieOptions.Media_Type = objReader["Media_Type"].ToString();
								objmovieOptions.Movie_Retail_Cost = objReader["Movie_Retail_Cost"].ToString();
								objmovieOptions.Copies_On_Hand = Convert.ToInt16(objReader["Copies_On_Hand"].ToString());
								objmovieOptions.Image = objReader["Image"].ToString();
								objmovieOptions.Trailer = objReader["Trailer"].ToString();
							}
						}
					}
					return objmovieOptions;
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




		public static bool AddMovieOption(MovieOptions objMovieOption)
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
					sqlString = "INSERT into Movie values (@MovieOptions_Movie_Number, @MovieOptions_Movie_Title, @MovieOptions_Description, @MovieOptions_Movie_Year_Made, @MovieOptions_Genre_ID, @MovieOptions_Movie_Rating, @MovieOptions_Media_Type, @MovieOptions_Movie_Retail_Cost, @MovieOptions_Copies_On_Hand, @MovieOptions_Image, @MovieOptions_Trailer)";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Number", objMovieOption.Movie_Number);
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Title", objMovieOption.Movie_Title);
						objCommand.Parameters.AddWithValue("@MovieOptions_Description", objMovieOption.Description);
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Year_Made", objMovieOption.Movie_Year_Made);
						objCommand.Parameters.AddWithValue("@MovieOptions_Genre_ID", objMovieOption.Genre_ID);
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Rating", objMovieOption.Movie_Rating);
						objCommand.Parameters.AddWithValue("@MovieOptions_Media_Type", objMovieOption.Media_Type);
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Retail_Cost", objMovieOption.Movie_Retail_Cost);
						objCommand.Parameters.AddWithValue("@MovieOptions_Copies_On_Hand", objMovieOption.Copies_On_Hand);
						objCommand.Parameters.AddWithValue("@MovieOptions_Image", objMovieOption.Image);
						objCommand.Parameters.AddWithValue("@MovieOptions_Trailer", objMovieOption.Trailer);
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


		public static bool UpdateMovieOption(MovieOptions objMovieOption)
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
					sqlString = "UPDATE MovieOptions " + Environment.NewLine +
								"set Movie_Title = @MovieOptions_Movie_Title, Description = @MovieOptions_Description, Movie_Year_Made = @MovieOptions_Movie_Year_Made, Genre_ID = @MovieOptions_Genre_ID, Movie_Rating = @MovieOptions_Movie_Rating, Media_Type = @MovieOptions_Media_Type, Retail_Cost = @MovieOptions_Movie_Retail_Cost, Copies_On_Hand = @MovieOptions_Copies_On_Hand, Image = @MovieOptions_Image, Trailer = @MovieOptions_Trailer " + Environment.NewLine +
								"where Movie_Number = @member_Movie_Number";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@MovieOptionse_Movie_Number", objMovieOption.Movie_Number);
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Title", objMovieOption.Movie_Title);
						objCommand.Parameters.AddWithValue("@MovieOptions_Description", objMovieOption.Description);
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Year_Made", objMovieOption.Movie_Year_Made);
						objCommand.Parameters.AddWithValue("@MovieOptions_Genre_ID", objMovieOption.Genre_ID);
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Rating", objMovieOption.Movie_Rating);
						objCommand.Parameters.AddWithValue("@MovieOptions_Media_Type", objMovieOption.Media_Type);
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Retail_Cost", objMovieOption.Movie_Retail_Cost);
						objCommand.Parameters.AddWithValue("@MovieOptions_Copies_On_Hand", objMovieOption.Copies_On_Hand);
						objCommand.Parameters.AddWithValue("@MovieOptions_Image", objMovieOption.Image);
						objCommand.Parameters.AddWithValue("@MovieOptions_Trailer", objMovieOption.Trailer);

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
		
				if (objConn != null)
				{
					objConn.Close();
				}
			}
		}


		public static bool DeleteMovieOption(MovieOptions objMovieOption)
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
					sqlString = "Delete MovieOptions where Movie_Number = @MovieOptions_Movie_Number";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@MovieOptions_Movie_Number", objMovieOption.Movie_Number);

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
