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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogIn frmLogIn = new LogIn();
            frmLogIn.Show();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (checkValidInputs())
            {   
                try
                {
                    using (var context = new Entities())
                    {
                        context.SIGNIN(txtUsername.Text,txtEmail.Text, txtCollege.Text, txtPassword.Text, Decimal.Parse(txtAge.Text));//cbxCollege.Text
                    }

                    this.Hide();
                    MEMBER member = new MEMBER();

                    member.USERNAME = txtUsername.Text;
                    member.EMAIL = txtEmail.Text;
                    member.COLLEGE_NAME = txtCollege.Text;
                    member.PASSWORD = txtPassword.Text;
                    member.AGE = Convert.ToByte(txtAge.Text);
                    member.CONFIRM_EMAIL = "Y";
                    member.PICTURE = null;

                    NewsFeed frmNewsFeed = new NewsFeed(member);
                    frmNewsFeed.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not Sign Up", "Invalid Sign Up\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter Fields", "No Text Entered");
            }      
        }

        private Boolean checkValidInputs()
        {
            if(String.IsNullOrEmpty(txtUsername.Text) && String.IsNullOrEmpty(txtPassword.Text))
                return false;
            else
                return true;
        }
    }
}
