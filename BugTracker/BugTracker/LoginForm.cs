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

            //execute login request
            if (loginok) ;
                       
        }

        private void DBCon_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line;
            string[] connect = new string[4];
            //Read file DBConnection.txt - unsecure must be stored otherwise
            System.IO.StreamReader file = new System.IO.StreamReader(@"\Coding\Projects\BugTracker\BugTracker\DBConnection.txt");
            while ((line = file.ReadLine()) != null)
            {
                connect[counter] = line;
                counter++;
            }

            file.Close();
            string dburl = connect[0];
            string db = connect[1];
            string dbuser = connect[2];
            string dbpassword = connect[3];

            DBlogin.Dblogin(dbuser, dbpassword, db, dburl);
        }
    }
}
