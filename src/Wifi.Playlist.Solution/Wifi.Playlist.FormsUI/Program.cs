using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.Playlist.CoreTypes;
using Wifi.Playlist.Factories;
using Wifi.Playlist.Repositories;
using Wifi.Playlist.Weather;

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

            var builder = new ContainerBuilder();
            builder.RegisterType<DummyEditor>().As<INewPlaylistDataProvider>();
            builder.RegisterType<PlaylistItemFactory>().As<IPlaylistItemFactory>();
            builder.RegisterType<GetWeatherData>().As<IWeatherDataProvider>();
            builder.RegisterType<MainForm>();

            //container erzeugen
            var container = builder.Build();    

            //Typen erzeugen lassen
            container.Resolve<MainForm>();  

            //create types
            //var provider = new NewPlaylistForm();
            var provider = new DummyEditor();
            var weather = new GetWeatherData();

            //factories erzeugen
            var itemFactory = new PlaylistItemFactory();

            //repositories erzeugen
            var m3uRepo = new M3uRepository(itemFactory);

            Application.Run(new MainForm(provider, itemFactory, weather, m3uRepo));
        }
    }
}
