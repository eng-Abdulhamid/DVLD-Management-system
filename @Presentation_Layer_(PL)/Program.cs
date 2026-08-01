using DTOs;
using DVLD_BusinessLogicLayer;
using DVLDPL;
using DVLDPL.PeopleManagement;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPL
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPeopleManagement());
        }
    }
}
