using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BugTracker
{
    class DBlogin
    {
        //login function
        public static void Dblogin(string user, string pass, string dbname, string dburl)
        {

            string connectionString = null;
            SqlConnection cnn;
            connectionString = "Data Source="+dburl+ ";Initial Catalog=" + dbname+";User ID="+user+";Password="+pass;
            cnn = new SqlConnection(connectionString);
            try
            {
                cnn.Open();
                Console.WriteLine("Database Connection");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't Open Database Connection");
            }

        }
    }
}
