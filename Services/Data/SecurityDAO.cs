using MyFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace MyFirstApp.Services.Data
{
 

    public class SecurityDAO
    {
        static string sha256(string randomString)
        {
            if (randomString == null)
            {
                return randomString;
            }
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Daniel\source\repos\MyFirstApp\App_Data\DatenbankUser.mdf;Integrated Security = True";

        internal bool FindByUser(UserModel user)
        {
            bool success = false;

            string queryString = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @Password";
            


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = sha256(user.Password);
           
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }

                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;

        }

        internal bool RegisterUser(UserModel user)
        {
            bool success = false;

            if (user.Password == null)
            {
                success = false;
                return success;
            }

            if (user.Password != user.ConfirmPassword)
            {
                success = false;
                return success;
            }

            if (user.Password.Length < 6)
            {
                success = false;
                return success;
            }




            string queryString = "INSERT INTO dbo.Users (username, password) VALUES (@Username,@Password)";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.Username;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = sha256(user.Password);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            return success;
        }

    }
}