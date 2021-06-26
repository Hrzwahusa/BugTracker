using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            password = StringtoSha256hash(password);

            //execute login request
            if(loginok) DBlogin(user,password);
                       
        }

        //login function
        public void DBlogin(string user, string pass)
        {

            Console.WriteLine(user);
            Console.WriteLine(pass);

        }

        //hash function
        static string StringtoSha256hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //string to bytearray - hashed
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                //back to string
                StringBuilder stringbuilder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }
    }
}
