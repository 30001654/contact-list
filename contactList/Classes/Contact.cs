using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactList
{
    class Contact : IPerson, IContact
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MInit { get; set; }
        public string HomePH { get; set; }
        public string MobilePH { get; set; }
        public string OfficeExt { get; set; }
        public string IRDNum { get; set; }
        public bool Active { get; set; }
    }
}
