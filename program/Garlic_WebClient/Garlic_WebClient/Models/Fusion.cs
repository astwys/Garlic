using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garlic_WebClient.Models {

    public static class UserInformation {

        private static garlicEntities db = new garlicEntities();

        private static string username;
        private static u_users user;

        public static string Username {
            get {
                return username;
            }
            set {
                if (value == null) {
                    user = null;
                    username = value;
                } else {
                    if (user == null) {
                        user = (from u in db.u_users
                                where u.u_username.Equals(username)
                                select u).FirstOrDefault();
                    } else {
                        if (!username.Equals(user.u_username)) {
                            user = (from u in db.u_users
                                    where u.u_username.Equals(username)
                                    select u).FirstOrDefault();
                        }
                    }
                }
            }
        }
        public static u_users User {
            get {
                return user;
            }
            set {
                if (value == null) {
                    user = value;
                    username = null;
                } else {
                    if (username == null) {
                        username = (from u in db.u_users
                                    where u.u_username.Equals(value.u_username)
                                    select u.u_username).FirstOrDefault();
                    } else {
                        if (!value.u_username.Equals(username)) {
                            username = (from u in db.u_users
                                        where u.u_username.Equals(value.u_username)
                                        select u.u_username).FirstOrDefault();
                        }
                    }
                }
            }
        }
    }

    public class HomePageModel {

        garlicEntities db = new garlicEntities();

        private int cloveID;
        public int? CloveID {
            get {
                return cloveID;
            }
            set {
                if (value == null)
                    cloveID = -1;
                else
                    cloveID = (int)value;
            }
        }

        public List<c_clove> Cloves { 
            get {
                var cloves = (from c in db.c_clove
                                where c.c_access == true || c.u_users.Contains(UserInformation.User)
                                select c).Distinct().ToList();

                return cloves.OrderBy(c => c.c_name).ToList();
            }
        }

        public List<vclovearticles> CloveArticles {
            get {
                var clovearticles = (from ca in db.vclovearticles
                                     select ca).Distinct().ToList();

                clovearticles = clovearticles.Where(a => a.isPublic.Equals(1)).ToList();

                if (CloveSearch != "") {
                    clovearticles = clovearticles.Where(s => s.a_title.ToLower().Contains(CloveSearch)).ToList();
                }

                if (CloveSort != "") {
                    switch (CloveSort) {
                        case "title_asc":
                            clovearticles = clovearticles.OrderBy(a => a.a_title).ToList();
                            break;
                        case "author_asc":
                            clovearticles = clovearticles.OrderBy(a => a.p_u_username).ToList();
                            break;
                        case "votes_desc":
                            clovearticles = clovearticles.OrderByDescending(a => a.voteCount).ToList();
                            break;
                    }
                }

                if (cloveID < 0)
                    return clovearticles;
                return clovearticles.Where(ca => ca.a_c_clove == cloveID).Distinct().ToList();
            }
        }

        public string CloveName {
            get {
                if (cloveID < 0)
                    return "All the things!";
                else
                    try {
                        return (from ca in db.vclovearticles
                                where ca.a_c_clove == cloveID
                                select ca.cloveName).First();
                    } catch (Exception) {

                        return (from c in db.c_clove
                                where c.c_id == cloveID
                                select c.c_name).FirstOrDefault();
                    }
            }
        }

        public string CloveDescription {
            get {
                if (cloveID < 0)
                    return "Hello and welcome to the frontpage. Here you see every single article that has ever been written.\n" +
                        "If you liked to narrow down the selection feel free to select from the different Cloves on the right.\nEnjoy!";
                else
                    try {
                        return (from ca in db.vclovearticles
                                where ca.a_c_clove == cloveID
                                select ca.cloveDesc).First();
                    } catch (Exception) {

                        return (from c in db.c_clove
                                where c.c_id == cloveID
                                select c.c_description).FirstOrDefault();
                    }
            }
        }

        private string cloveSearch;
        public string CloveSearch {
            get {
                return cloveSearch;
            }
            set {
                if (value == null) {
                    cloveSearch = "";
                } else {
                    cloveSearch = value.ToLower();
                }
            }
        }

        private string cloveSort;
        public string CloveSort {
            get {
                return cloveSort;
            }
            set {
                if (value == null) {
                    cloveSort = "";
                } else {
                    cloveSort = value;
                }
            }
        }
    }
}