using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.Playlist.CoreTypes;
using Wifi.Playlist.Factories;
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

            //builder erzeugen
            var builder = new ContainerBuilder();

            //typen registrieren
            //builder.RegisterType<DummyEditor>().As<INewPlaylistDataProvider>();
            builder.RegisterType<NewPlaylistForm>().As<INewPlaylistDataProvider>();
            builder.RegisterType<PlaylistItemFactory>().As<IPlaylistItemFactory>();
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();
            builder.RegisterType<GetWeatherData>().As<IWeatherDataProvider>();
            builder.RegisterType<MainForm>();

            //container erzeugen
            var container = builder.Build();

            //Typen erzeugen lassen
            var mainForm = container.Resolve<MainForm>();           

            Application.Run(mainForm);
        }
    }
}
