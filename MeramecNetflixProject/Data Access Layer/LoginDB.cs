using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MeramecNetflixProject.Business_Objectives;

namespace MeramecNetflixProject.Data_Access_Layer
{
	public static class LoginDB
	{

		public static List<Member> GetMemberLogin()
		{
			//Change the MyCustomObject name to your customer business object that is returning data from the specific table
			List<Member> memberLoginList = new List<Member>();
			string SQLStatement = "select Login_Name, Password from Member order by Login_Name";

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
								Member objMemberLogin = new Member();
								objMemberLogin.Login_Name = objReader["Login_Name"].ToString();
								objMemberLogin.Password = objReader["Password"].ToString();

								//Add the genre to the collection
								memberLoginList.Add(objMemberLogin);
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

			return memberLoginList;
		}




		public static Member GetMemberLogin(int memberLogInID)
		{
			//Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
			string SQLStatement = String.Empty;

			//Change the MyCustomObject references  to your customer business object
			//Genre objTemp = new Genre();

			string sqlString = "Select Login_Name, Password from Member where Login_Name = @Member_Login_Name";
			SqlCommand objCommand = null;
			SqlConnection objConn = null;
			SqlDataReader objReader = null;
			Member objMemberLogin = null;
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
						objCommand.Parameters.AddWithValue("@Member_Login_Name", memberLogInID);
						//Execute the SQL and return a DataReader
						using (objReader = objCommand.ExecuteReader())
						{
							while (objReader.Read())
							{
								objMemberLogin = new Member();
								//Fill the customer object if found
								objMemberLogin.Login_Name = objReader["Login_Name"].ToString();
								objMemberLogin.Password = objReader["Password"].ToString();
							}
						}
					}
					return objMemberLogin;
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
