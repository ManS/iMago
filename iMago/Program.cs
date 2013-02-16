using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iMago
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();  // to enable form skin
            DevExpress.UserSkins.BonusSkins.Register(); // to enable skins that you will include with " DevExpress.BonusSkins.v9.2.dll "
            Application.Run(new Main());
        }
    }
}