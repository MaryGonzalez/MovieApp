using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MeramecNetflixProject.Business_Objectives;

namespace MeramecNetflixProject.Data_Access_Layer
{
	public class MemberDB
	{
		public static List<Member> GetMembers()
		{
			//Change the MyCustomObject name to your customer business object that is returning data from the specific table
			List<Member> memberList = new List<Member>();


			string SQLStatement = "select Number, JoinDate, FirstName, LastName, Address, City, State, ZipCode, Phone, Member_Status, Login_Name, Password, Email, Contact_Method, Subscription_ID, Photo from Member order by Number";
			//string SQLStatement = "from Member in memberList join subscription in subscriptionList";
			
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
								Member objMember = new Member();

								objMember.Number = Convert.ToInt32(objReader["Number"].ToString());
								objMember.JoinDate = Convert.ToDateTime(objReader["JoinDate"].ToString());
								objMember.FirstName = objReader["FirstName"].ToString();
								objMember.LastName = objReader["LastName"].ToString();
								objMember.Address = objReader["Address"].ToString();
								objMember.City = objReader["City"].ToString();
								objMember.State = objReader["State"].ToString();
								objMember.ZipCode = objReader["ZipCode"].ToString();
								objMember.Phone = objReader["Phone"].ToString();
								objMember.Member_Status = objReader["Member_Status"].ToString();
								objMember.Login_Name = objReader["Login_Name"].ToString();
								objMember.Password = objReader["Password"].ToString();
								objMember.Email = objReader["Email"].ToString();
								objMember.Contact_Method = Convert.ToInt32(objReader["Contact_Method"].ToString());
								objMember.Subscription_ID = Convert.ToInt32(objReader["Subscription_ID"].ToString());
								objMember.Photo = objReader["Photo"].ToString();

								
								//Add the genre to the collection
								memberList.Add(objMember);
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

			return memberList;

		}

		public static Member GetMember(int memberID)
		{
			//Pre-step: Replace the general object parameter with the appropriate data type parameter for retrieving a specific item from the specific database table. 
			string SQLStatement = String.Empty;

			string sqlString = "Select Number, JoinDate, FirstName, LastName, Address, City, State, ZipCode, Phone, Member_Status, Login_Name, Password, Email,  Subscription_ID, Photo from Member where Number = @Member_Number";
			

			SqlCommand objCommand = null;
			SqlConnection objConn = null;
			SqlDataReader objReader = null;
			Member objMember = null;
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
						objCommand.Parameters.AddWithValue("@Member_Number", memberID);
						//Execute the SQL and return a DataReader
						using (objReader = objCommand.ExecuteReader())
						{
							while (objReader.Read())
							{
								objMember = new Member();

								//Fill the customer object if found
								objMember.Number = Convert.ToInt32(objReader["Number"].ToString());
								objMember.JoinDate = Convert.ToDateTime(objReader["JoinDate"].ToString());
								objMember.FirstName = objReader["FirstName"].ToString();
								objMember.LastName = objReader["LastName"].ToString();
								objMember.Address = objReader["Address"].ToString();
								objMember.City = objReader["City"].ToString();
								objMember.State = objReader["State"].ToString();
								objMember.ZipCode = objReader["ZipCode"].ToString();
								objMember.Phone = objReader["Phone"].ToString();
								objMember.Member_Status = objReader["Member_Status"].ToString();
								objMember.Login_Name = objReader["Login_Name"].ToString();
								objMember.Password = objReader["Password"].ToString();
								objMember.Email = objReader["Email"].ToString();
								objMember.Contact_Method = Convert.ToInt32(objReader["Contact_Method"].ToString());
								objMember.Subscription_ID = Convert.ToInt32(objReader["Subscription_ID"].ToString());
								objMember.Photo = objReader["Photo"].ToString();
							}
						}
					}
					return objMember;
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


		public static bool AddMember(Member objMember)
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
					sqlString = "INSERT into Member values (@member_Number, @member_JoinDate, @member_FirstName, @member_LastName, @member_Address, @member_City, @member_State, @member_ZipCode, @member_Phone, @member_Member_Status, @member_Login_Name, @member_Password, @member_Email, @member_Contact_Method, @member_Subscription_ID, @member_Photo)";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@member_Number", objMember.Number);
						objCommand.Parameters.AddWithValue("@member_JoinDate", objMember.JoinDate);
						objCommand.Parameters.AddWithValue("@member_FirstName", objMember.FirstName);
						objCommand.Parameters.AddWithValue("@member_LastName", objMember.LastName);
						objCommand.Parameters.AddWithValue("@member_Address", objMember.Address);
						objCommand.Parameters.AddWithValue("@member_City", objMember.City);
						objCommand.Parameters.AddWithValue("@member_State", objMember.State);
						objCommand.Parameters.AddWithValue("@member_ZipCode", objMember.ZipCode);
						objCommand.Parameters.AddWithValue("@member_Phone", objMember.Phone);
						objCommand.Parameters.AddWithValue("@member_Member_Status", objMember.Member_Status);
						objCommand.Parameters.AddWithValue("@member_Login_Name", objMember.Login_Name);
						objCommand.Parameters.AddWithValue("@member_Password", objMember.Password);
						objCommand.Parameters.AddWithValue("@member_Email", objMember.Email);
						objCommand.Parameters.AddWithValue("@member_Contact_Method", objMember.Contact_Method);
						objCommand.Parameters.AddWithValue("@member_Subscription_ID", objMember.Subscription_ID);
						objCommand.Parameters.AddWithValue("@member_Photo", objMember.Photo);

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

		public static bool UpdateMember(Member objMember)
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
					sqlString = "UPDATE Member " + Environment.NewLine +
								"set JoinDate = @member_JoinDate, FirstName = @member_FirstName, LastName = @member_LastName, Address = @member_Address, City = @member_City, State = @member_State, ZipCode = @member_ZipCode, Phone = @member_Phone, Member_Status = @member_Member_Status, Login_Name = @member_Login_Name, Password = @member_Password, Email = @member_Email, Contact_Method = @member_Contact_Method, Subscription_ID = @member_Subscription_ID, Photo = @member_Photo" + Environment.NewLine +
								"where Movie_Number = @member_Number ";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@member_Number", objMember.Number);
						objCommand.Parameters.AddWithValue("@member_JoinDate", objMember.JoinDate);
						objCommand.Parameters.AddWithValue("@member_FirstName", objMember.FirstName);
						objCommand.Parameters.AddWithValue("@member_LastName", objMember.LastName);
						objCommand.Parameters.AddWithValue("@member_Address", objMember.Address);
						objCommand.Parameters.AddWithValue("@member_City", objMember.City);
						objCommand.Parameters.AddWithValue("@member_State", objMember.State);
						objCommand.Parameters.AddWithValue("@member_ZipCode", objMember.ZipCode);
						objCommand.Parameters.AddWithValue("@member_Phone", objMember.Phone);
						objCommand.Parameters.AddWithValue("@member_Member_Status", objMember.Member_Status);
						objCommand.Parameters.AddWithValue("@member_Login_Name", objMember.Login_Name);
						objCommand.Parameters.AddWithValue("@member_Password", objMember.Password);
						objCommand.Parameters.AddWithValue("@member_Email", objMember.Email);
						objCommand.Parameters.AddWithValue("@member_Contact_Method", objMember.Contact_Method);
						objCommand.Parameters.AddWithValue("@member_Subscription_ID", objMember.Subscription_ID);
						objCommand.Parameters.AddWithValue("@member_Photo", objMember.Photo);

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


		public static bool DeleteMember(Member objMember)
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
					sqlString = "Delete Member where Number = @member_Number";

					//Create a command object with the SQL statement
					using (objCommand = new SqlCommand(sqlString, objConn))
					{
						//Use the command parameters method to set the paramater values of the SQL Insert statement
						objCommand.Parameters.AddWithValue("@member_Number", objMember.Number);

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
