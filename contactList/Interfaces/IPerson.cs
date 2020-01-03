using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactList
{
    interface IPerson
    {
        string FName { get; set; }
        string LName { get; set; }
        string MInit { get; set; }
        string IRDNum { get; set; }
    }
}
