using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactList
{
    interface IContact
    {
        string HomePH { get; set; }
        string MobilePH { get; set; }
        string OfficeExt { get; set; }
        bool Active { get; set; }
    }
}
