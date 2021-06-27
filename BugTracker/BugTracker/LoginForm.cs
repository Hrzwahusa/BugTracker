using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BugTracker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }        
        private void Loginbutton_Click(object sender, EventArgs e)
        {

            //cleaning user input
            string rdrpass = "";
            bool loginok = true;
            string user = username.Text.ToString();
            string password = pass.Text.ToString();            

            //check for possible injections
            for(int i = 0; i < user.Length; i++)
            {
                if(user.Substring(i,1) == "\"" || user.Substring(i,1) == "'" || user.Substring(i,1) == "\\" || user.Substring(i,1) == ";" || user.Substring(i, 1) == "=" || user.Substring(i, 1) == "(" || user.Substring(i, 1) == ")" || user.Substring(i, 1) == " " || user.Substring(i, 1) == "/" || user.Substring(i, 1) ==  "*")
                {
                    failedlabel.Text = "Invalid Username";
                    failedlabel.Visible = true;
                    loginok = false;
                }
            }

            //password hash
            password = Hash.StringtoSha256hash(password);
            Console.WriteLine(password);
                        
            //db connection
            DBlogin.Dblogin();

            string sql = "SELECT Pass FROM User WHERE Name='"+user+"'";
            MySqlCommand cmd = new MySqlCommand(sql, DBlogin.cnn);
            object rdr = cmd.ExecuteScalar();
            if(rdr != null)
            {
                rdrpass = rdr.ToString();
            }
           

            //execute login request
            if (loginok && rdrpass == password)
            {
                Console.WriteLine("success");
                DBlogin.cnn.Close();
            }
                       
        }        
    }
}
