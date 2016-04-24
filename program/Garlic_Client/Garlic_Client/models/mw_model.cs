﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace Garlic_Client.models {
    class mw_model : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        //reference to the main window > access to times
        public static MainWindow mainwindow;
        public static ReadWindow readwindow;
        public static WriteWindow writewindow;
        public static LoginWindow loginwindow;

        // ----- Data Queries -----
        garlicEntities db = new garlicEntities();

        public IEnumerable<c_cloves> AllCloves {
            get {
                return (from c in db.c_cloves
                        orderby c.c_id, c.c_name
                        select c).ToList();
            }
        }

        private int selectedClove;
        public int SelectedClove {
            get {
                return this.selectedClove;
            }
            set {
                selectedClove = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCloveDescription"));
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCloveAdmins"));
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCloveArticles"));
            }
        }

        public string SelectedCloveDescription {
            get {
                return (from c in db.c_cloves
                        where c.c_id == this.selectedClove
                        select c.c_description).First().ToString();
                ;
            }
        }

        public IEnumerable<u_users> SelectedCloveAdmins {
            get {
                List<string> adminsofclove =  (from ua in db.ad_admins
                                               where ua.ad_c_clove == this.selectedClove
                                               orderby ua.ad_u_username
                                               select ua.ad_u_username).ToList();
                var x = adminsofclove;
                return (from u in db.u_users
                        where adminsofclove.Contains(u.u_username)
                        orderby u.u_username
                        select u).ToList();

            }
        }

        public ObservableCollection<Article> SelectedCloveArticles {
            get {
                //set cursor to waiting
                Cursor defaultCursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;
                //create an Article object for each article in the selected clove
                List<Article> articles = (from a in db.a_articles
                                          where a.a_c_clove == this.selectedClove
                                          select new Article()).ToList();
                //get the articles out of the database
                List<a_articles> articlesDB = (from a in db.a_articles
                                               where a.a_c_clove == this.selectedClove
                                               select a).ToList();
                //get the properties of the articles and store them in the Article objects
                for (int i = 0; i < articlesDB.Count; i++) {
                    articles[i].ID = articlesDB[i].a_p_post;
                    articles[i].Title = articlesDB[i].a_title;
                    articles[i].Author = articlesDB[i].p_posts.p_u_username;
                }

                for (int j = 0; j < articlesDB.Count; j++) {
                    int articleID = articles[j].ID;
                    articles[j].Upvotes = (from v1 in db.v_votes
                                           where v1.v_p_post == articleID && v1.v_upvote
                                           select v1).ToList().Count;
                    articles[j].Downvotes = (from v2 in db.v_votes
                                             where v2.v_p_post == articleID && !v2.v_upvote
                                             select v2).ToList().Count;
                }

                //set cursor back to normal
                Mouse.OverrideCursor = defaultCursor;

                return new ObservableCollection<Article>(articles);
            }
        }

        // ----------- Main Window ----------

        public string WelcomeMessage {
            get {
                return "Hello "+mw_model.Username + "!";
            }
        }

        private void subscribeToClove()
        {
            
            // TODO update current database to include s_subsriptions
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // ----------- ReadWindow -----------

        public static string ArticleTitle { get; set; }

        public string ArticleText {
            get
            {
                return (from p in db.p_posts
                        join a in db.a_articles on p.p_id equals a.a_p_post
                        where a.a_title.Equals(ArticleTitle)
                        select p.p_content).ToList().First().ToString();
            }
        }



        // ------------ LoginWindow -----------

        public static string Username { get; set; }
        public static string Password { get; set; }

        public bool UserExists (string user, string pw)
        {
            Cursor defaultCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;

            if (db.u_users.Any(u => (u.u_username == user) && (u.u_password == pw)))
            {
                Mouse.OverrideCursor = defaultCursor;
                return true;
            }
            Mouse.OverrideCursor = defaultCursor;
            return false;
        }


        // ----- Mini Classes -----

        public class Article {
            private string title;
            public string Title {
                get {
                    return this.title;
                }
                set {
                    string temp = value;
                    if (temp.Length > 200)
                        this.title = temp.Substring(0, 200) + "...";
                    else
                        this.title = temp;
                }
            }
            public string Author { get; set; }
            public int ID { get; set; }
            public int Upvotes { get; set; }
            public int Downvotes { get; set; }

            public Article (int id, int upvotes, int downvotes) {
                this.ID = id;
                this.Upvotes = upvotes;
                this.Downvotes = downvotes;
            }

            public Article () { }
        }

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }

            public User (string username, string password, string email)
            {
                this.Username = username;
                this.Password = password;
                this.Email = email;
            }
        }

        // ----- Events -----

        #region MW_WriteButton
        private ICommand writeArticleCommand;
        public ICommand WriteArtileCommand {
            get {
                if (writeArticleCommand == null) {
                    writeArticleCommand = new DelegateCommand(WriteExecuted, WriteCanExecute);
                }
                return writeArticleCommand;
            }
        }

        public bool WriteCanExecute (object param) {
            if (writewindow == null)
                return true;
            else
                return false;
        }

        public void WriteExecuted (object param) {
            WriteWindow ww = new WriteWindow();
            ww.Show();
            ww.Topmost = true;
        }
        #endregion

        #region WW_SubmitButton

        private ICommand submitArticle;
        public ICommand SubmitArticle {
            get {
                if (submitArticle == null)
                    submitArticle = new DelegateCommand(SubmitExecuted, SubmitCanExecute);
                return submitArticle;
            }
        }

        private bool SubmitCanExecute (object param) {
            if (param != null && ((string)param).Length > 1)
                return true;
            else
                return false;
        }

        private void SubmitExecuted (object param) {
            p_posts newpost = new p_posts();
            newpost.p_id = ((from p in db.p_posts
                             select p.p_id).Max())+1;
            newpost.p_content = writewindow.writecontent.Text;
            newpost.p_date = DateTime.Now;
            newpost.p_u_username = mw_model.Username;

            a_articles newarticle = new a_articles();
            newarticle.a_p_post = newpost.p_id;
            newarticle.a_title = (string)param;
            newarticle.a_c_clove = (int)writewindow.cloves_combobox.SelectedIndex+1;
            newarticle.r_rankings = null;

            db.p_posts.Add(newpost);
            db.a_articles.Add(newarticle);

            db.SaveChanges();
            //TODO I dont know why the auto-refresh is not working
            PropertyChanged(this, new PropertyChangedEventArgs("SelectedCloveArticles"));

            writewindow.Close();
        }

        public void NewUser (string username, string password, string email)
        {
            if (db.u_users.Any(u => (u.u_username == Username)))
            {
                MessageBox.Show("This username already exists, please choose another one.");
                return;
            }

            u_users user = new u_users
            {
                u_username = username,
                u_password = password,
                u_email = email
            };

            db.u_users.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Oops something went wrong. Please try again.");
                throw;
            }
        }

        #endregion

        // TODO make this method to be called on writewindow close
        public static void OnWriteWindowClosed () {
            writewindow = null;
        }
    }
}
