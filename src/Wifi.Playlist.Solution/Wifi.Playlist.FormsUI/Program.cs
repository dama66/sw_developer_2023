using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.Playlist.Factories;

namespace Wifi.Playlist.FormsUI
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

            //create types
            //var provider = new NewPlaylistForm();
           var provider = new DummyEditor();

            //factories erzeugen
            var itemFactory = new PlaylistItemFactory();

            Application.Run(new MainForm(provider, itemFactory));
        }
    }
}
