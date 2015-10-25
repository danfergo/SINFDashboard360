using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SINFDashboard360.Controllers
{
    public class SessionController : ApiController
    {
        private bool isLoggedin = false;
        private SQLiteConnection dbConnection;

        
        SessionController(){
            dbConnection = new SQLiteConnection("Data Source=c:\\dashboard360.db;Version=3;");
            dbConnection.Open();
        }

       

        // GET api/session - get current sessin
        public IEnumerable<string> Get()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM accounts",dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(reader);
            Console.WriteLine("--------------------------------------");

            return new string[] { "value1", "value2" };
        }

        // PUT api/session - login
        public void Post([FromBody]string value)
        {
             
        }

        // DELETE api/session - logout
        public void Delete()
        {
            isLoggedin = false; 
        }
    }
}
