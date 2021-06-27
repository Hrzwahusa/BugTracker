using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace BugTracker
{
    static class DBlogin
    {
        public static MySqlConnection cnn;
        //login function
        public static void Dblogin()
        {

            int counter = 0;
            string line;
            string[] connect = new string[4];
            //Read file DBConnection.txt - unsecure must be stored otherwise
            System.IO.StreamReader file = new System.IO.StreamReader("DBConnection.txt");
            while ((line = file.ReadLine()) != null)
            {
                connect[counter] = line;
                counter++;
            }

            file.Close();
            //write into vars
            string dburl = connect[0];
            string db = connect[1];
            string dbuser = connect[2];
            string dbpassword = connect[3];

            string connectionString = null;
            
            connectionString = "server="+dburl+";user= "+dbuser+";database=" + db + ";password=" +dbpassword;
            cnn = new MySqlConnection(connectionString);
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
