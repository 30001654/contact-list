using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contactList
{
    static class Program
    {
        /*
         * Author:      Sefton Munro
         * Date:        23/11/2019
         * Description: Basic contact list with CRUD functionality + export data as .csv and .txt report
        */

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
