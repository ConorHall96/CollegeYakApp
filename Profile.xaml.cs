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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        MEMBER member;

        public Profile(MEMBER member)
        {
            this.member = member;
            InitializeComponent();

            txtUsername.Text = member.USERNAME;
            txtPassword.Text = member.PASSWORD;
            txtCollege.Text = member.COLLEGE_NAME;
            txtEmail.Text = member.EMAIL;

            var age = Convert.ToByte(member.AGE);
            txtAge.Text = Convert.ToString(age);

            if (member.PICTURE == null)
            {
                BitmapImage image = new BitmapImage(new Uri("686909-user_people_man_human_head_person-512.png", UriKind.Relative));
                imgProfilePhoto.Source = image;
            }
            else
            {
                var image = (Byte[])member.PICTURE;
                //imgProfilePhoto.Source = image;
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogIn frmLogIn = new LogIn();
            frmLogIn.Show();
        }

        private void btnPostFeed_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NewsFeed frmNewsfeed = new NewsFeed(member);
            frmNewsfeed.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (var context = new Entities())
                {
                    context.UPDATEMEMBER(txtUsername.Text, txtEmail.Text, txtCollege.Text, txtPassword.Text, Decimal.Parse(txtAge.Text));
                }

                member.USERNAME = txtUsername.Text;
                member.EMAIL = txtEmail.Text;
                member.COLLEGE_NAME = txtCollege.Text;
                member.PASSWORD = txtPassword.Text;
                member.AGE = Byte.Parse(txtAge.Text);

                MessageBox.Show("Details Updated","Your Details have been updated an saved to the system.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not Updae", "Could not update details\n" + ex.Message);
            }
        }
    }
}
