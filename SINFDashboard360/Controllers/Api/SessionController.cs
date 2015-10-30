using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.SessionState;
using System.Web.Mvc;
using SINFDashboard360.Models;



namespace SINFDashboard360.Controllers
{
    public class SessionController : ApiController
    {
        private SQLiteConnection dbConnection;


        SessionController()
        {
            dbConnection = new SQLiteConnection("Data Source=c:\\dashboard360.db;Version=3;");
            dbConnection.Open();
        }

        // GET api/session - get current sessin
        public Object Get()
        {
            if (System.Web.HttpContext.Current.Session["account_id"] != null) {
                int account_id = (int)System.Web.HttpContext.Current.Session["account_id"];
                SQLiteCommand command = new SQLiteCommand("SELECT * FROM accounts WHERE account_id='" + account_id + "'", dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();

                if(reader.Read()){
                    return new User
                    {
                        id = (int)reader.GetInt32(0)
                    };
                }

                Delete(); // something unexpected happened: probably user was unregistered -> force logout
                return new Error("Something unexpected happened");
            }


            return new Error("Session does not exist yet");
        }

        // PUT api/session - login
        public Object Post([FromBody]JToken jsonBody)
        {

            String email = "";
            String password = "";

            if (System.Web.HttpContext.Current.Session["account_id"] != null) {
                return Get();
            }


            try
            {
                email = jsonBody["email"].ToString();
                password = jsonBody["password"].ToString();
            }
            catch (Exception)
            {
                return new Error("Invalid parameters");
            }

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM accounts WHERE email='" + email + "'", dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                System.Diagnostics.Debug.WriteLine("{0} ", reader["password"].ToString());
                if( reader["password"].Equals(password) ){
                    System.Web.HttpContext.Current.Session["account_id"] = reader.GetInt32(0);
                    return Get();           
                }
                
                return new Error("Email and password do not match");
            }
            
            return new Error("Email does not exist");
        }

        // DELETE api/session - logout
        public Object Delete()
        {
            System.Web.HttpContext.Current.Session.Abandon();
            return new Success("You are logged out now");
        }
    }
}
