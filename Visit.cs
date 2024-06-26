using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryOfaNailMaster
{
    internal class Visit
    {
        public int IdVisit {  get; set; }   
        public DateTime DateVisit { get; set; }
        public DateTime TimeVisit { get; set; }

        public string Service { get; set; }
        public string FnameMaster { get; set; }
        public string NameMaster { get; set; }
        public string FnameClient { get; set; }
        public string NameClient { get; set; }

        public string Status { get; set; }

        public string MasterFullName
        {
            get
            {
                return $"{FnameMaster} {NameMaster}";
            }
        }

        public string ClientFullName
        {
            get
            {
                return $"{FnameClient} {NameClient}";
            }
        }

        public string TimeService { get; set ; }


    }
}
