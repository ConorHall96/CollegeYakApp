using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CollegeYakApp
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            String userName;
            String userPassword;

            MEMBER member;

            userName = txtUsername.Text;
            userPassword = txtPassword.Text;

            try
            {
                using (var context = new Entities())
                {
                    member = new MEMBER();

                    var query = from b in context.MEMBERs
                                where b.USERNAME == userName
                                select b;

                    foreach (var item in query)
                    {
                        member.USERNAME = userName;
                        member.EMAIL = item.EMAIL;
                        member.COLLEGE_NAME = item.COLLEGE_NAME;
                        member.PASSWORD = userPassword;
                        member.AGE = item.AGE;
                        member.CONFIRM_EMAIL = item.CONFIRM_EMAIL;
                        member.PICTURE = item.PICTURE;
                    }

                    context.LOGGINGIN(userName, userPassword);                
                }

                this.Hide();
                NewsFeed frmNewsFeed = new NewsFeed(member);
                frmNewsFeed.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not Login", "Invalid Login\n"+ex.Message);
            }          
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUp frmSignUp = new SignUp();
            frmSignUp.Show();
        }
    }
}
