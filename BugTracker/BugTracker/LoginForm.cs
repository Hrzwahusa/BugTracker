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

        private void loginbutton_Click(object sender, EventArgs e)
        {
            //cleaning user input

            String user = username.ToString();
            String password = pass.ToString();

            for(int i = 0; i < user.Length; i++)
            {
                if(user.Substring(i,1) == "\"" || user.Substring(i,1) == "'" || user.Substring(i,1) == "\\")
                {
                    failedlabel.Text = "Invalid Username";
                    failedlabel.Visible = true;
                }
            }

            for(int i = 0; i < password.Length; i++)
            {
                if(password.Substring(i, 1) == "\"" || password.Substring(i, 1) == "'" || password.Substring(i, 1) == "\\")
                {
                    failedlabel.Text = "Forbidden Characters in Password";
                    failedlabel.Visible = true;
                }
            }

            //execute login request

            dblogin(user,password);
            

            
        }
        public void dblogin(String user, String pass)
        {

        }
    }
}
