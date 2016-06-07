using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garlic_WebClient.Models {
    public class Fusion {

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
                return db.c_clove.ToList();
            }
        }

        public List<vclovearticles> CloveArticles {
            get {
                if(cloveID < 0)
                    return (from ca in db.vclovearticles
                            select ca).Distinct().ToList();
                return (from ca in db.vclovearticles
                        where ca.a_c_clove == cloveID
                        select ca).Distinct().ToList();
            }
        }

        public string CloveName {
            get {
                if (cloveID < 0)
                    return "All the things!";
                else
                    return (from ca in db.vclovearticles
                            where ca.a_c_clove == cloveID
                            select ca.cloveName).First();
            }
        }

        public string CloveDescription {
            get {
                if (cloveID < 0)
                    return "Hello and welcome to the frontpage. Here you see every single article that has ever been written.\n"+
                        "If you liked to narrow down the selection feel free to select from the different Cloves on the right.\nEnjoy!";
                else
                    return (from ca in db.vclovearticles
                            where ca.a_c_clove == cloveID
                            select ca.cloveDesc).First();
            }
        }

    }
}