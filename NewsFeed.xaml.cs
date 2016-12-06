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
    /// Interaction logic for NewsFeed.xaml
    /// </summary>
    public partial class NewsFeed : Window
    {
        MEMBER member;

        public NewsFeed(MEMBER member)
        {
            this.member = member;
            InitializeComponent();
            loadPosts();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogIn frmLogIn = new LogIn();
            frmLogIn.Show();
        }     

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Profile frmProfile = new Profile(member);
            frmProfile.Show();
        }

        private void loadPosts()
        {
            using (var context = new Entities())

            {
                var query = from c in context.POST_VIEW
                            orderby c.POST_TIME descending
                            select c;

                foreach (var item in query)
                {
                    Decimal votedPostId;
                    int downVotes = 0;
                    int upVotes = 0;

                    votedPostId = item.POST_ID;

                    var queryVoteDownCount = from a in context.VOTEDOWN_VIEW
                                             where a.POST_ID == votedPostId
                                             orderby a.POST_ID
                                             select a;
                    foreach (var voteDownItem in queryVoteDownCount)
                    {
                        downVotes++;
                    }

                    var queryVoteUpCount = from b in context.VOTEUP_VIEW
                                           where b.POST_ID == votedPostId
                                           orderby b.POST_ID
                                           select b;
                    foreach (var voteUpItem in queryVoteUpCount)
                    {
                        upVotes++;
                    }

                    var returnedPost = item.Username + "\n" + item.POST_TIME + "\n\n" + item.DETAILS;

                    var lblNewPost = createLabel("newPost", returnedPost);
                    var lblUpVotes = createLabel("UpVotes", "Up Votes: " + upVotes);
                    var lblDownVotes = createLabel("DownVotes", "Down Votes: " + downVotes);

                    var btnUpVote = createButton("ButtonUp", "Up Vote");
                    var btnDownVote = createButton("ButtonDown", "Down Vote");

                    btnUpVote.Click += (sender, e) => { btnUpVote_Click(sender, e, "U", member.USERNAME, item.Username, item.POST_ID); };
                    //http://stackoverflow.com/questions/5395908/how-to-pass-multiple-string-values-to-a-button-click-event-handler-in-c-sharp
                    //(How to pass multiple string values to a button click event handler in C#, 2016)

                    btnDownVote.Click += (sender, e) => { btnDownVote_Click(sender, e, "D", member.USERNAME, item.Username, item.POST_ID); };

                    ListBox lstPost = new ListBox();
                    lstPost.Name = "NewPost";

                    lstPost.Items.Add(lblNewPost);
                    lstPost.Items.Add(lblUpVotes);
                    lstPost.Items.Add(lblDownVotes);
                    lstPost.Items.Add(btnUpVote);
                    lstPost.Items.Add(btnDownVote);
                    lstPost.Width = 380;

                    lstPosts.Items.Add(lstPost);
                }
            }
        }

        public Label createLabel(String name, String content)
        {
            Label createdLabel = new Label();
            createdLabel.Name = name;
            createdLabel.Content = content;

            return createdLabel;
        }

        public Button createButton(String name, String content)
        {
            Button btnUpVote = new Button();
            btnUpVote.Name = name;
            btnUpVote.Content = content;

            return btnUpVote;
        }

        private void btnUpVote_Click(object sender, RoutedEventArgs e, String voteType, String voterUN, String votedUN, decimal postID)
        {
            try
            {
                using (var context = new Entities())
                {
                    context.CHECKVOTE(voteType, voterUN, votedUN, postID);
                }                
                MessageBox.Show("You Up Voted This Post by " + votedUN);
                //loadPosts();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Vote Limit Reached" + ex.Message);
            }
              
        }

        private void btnDownVote_Click(object sender, RoutedEventArgs e, String voteType, String voterUN, String votedUN, decimal postID)
        {
            
            try
            {
                using (var context = new Entities())
                {
                    context.CHECKVOTE(voteType, voterUN, votedUN, postID);
                }               
                MessageBox.Show("You Down Voted This Post by " + votedUN);
                //loadPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vote Limit Reached" + ex.Message);
                NewsFeed form = new NewsFeed(member);
            }
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                using (var context = new Entities())
                {
                    context.INSERTPOST(member.COLLEGE_NAME, member.USERNAME, txtWritePost.Text);
                }
                MessageBox.Show("Your Post has been uploaded");
                //loadPosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Post Limit Reached" + ex.Message);
            }
        }
    }
}
