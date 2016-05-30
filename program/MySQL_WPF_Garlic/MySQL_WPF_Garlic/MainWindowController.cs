using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_WPF_Garlic {
    class MainWindowController {

        public garlicEntities db { get; set; }

        public MainWindowController (ref garlicEntities database) {
            this.db = database;
        }

        public Task<List<vcloveinfo>> Task_list_ItemsSource () {
            return Task<List<vcloveinfo>>.Run(() => {
                return (from ci in db.vcloveinfoes
                        select ci).Distinct().ToList();
            });
        }

        public Task<List<a_articles>> Task_articles_ItemsSource (vcloveinfo selecteditem) {
            return Task<List<a_articles>>.Run(() => {
                return (from a in db.a_articles
                        where a.a_c_clove == selecteditem.ci_cloveID
                        select a).Distinct().ToList();
            });
        }

        public Task<vpostinfo> Task_info_query (a_articles article) {
            return Task<vpostinfo>.Run(() => {
                return (from pi in db.vpostinfoes
                        where pi.p_id == article.a_p_id
                        select pi).Distinct().ToList().First();
            });
        }

    }
}
