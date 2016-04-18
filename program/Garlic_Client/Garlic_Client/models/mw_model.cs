using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;


namespace Garlic_Client.models {
    class mw_model : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        GarlicDatabaseEntities db = new GarlicDatabaseEntities();

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

    }
}
