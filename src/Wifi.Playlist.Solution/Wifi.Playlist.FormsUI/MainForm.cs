using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.Playlist.CoreTypes;
using Wifi.Playlist.Factories;
using Wifi.Playlist.Repositories;

namespace Wifi.Playlist.FormsUI
{
    public partial class MainForm : Form
    {
        private CoreTypes.Playlist _playlist;
        private M3uRepository _m3uRepository;
        private readonly INewPlaylistDataProvider _newPlaylistDataProvider;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IWeatherDataProvider _weatherDataProvider;

        public MainForm(INewPlaylistDataProvider newPlaylistDataProvider,
                        IPlaylistItemFactory playlistItemFactory,
                        IWeatherDataProvider weatherDataProvider,
                        M3uRepository m3uRepo)

        {
            InitializeComponent();

            _newPlaylistDataProvider = newPlaylistDataProvider;
            _playlistItemFactory = playlistItemFactory;
            _weatherDataProvider = weatherDataProvider;
            _m3uRepository = m3uRepo;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get Weather Data
            _weatherDataProvider.GetWeather();

            //get Weather Icon
            pic_weather.ImageLocation = $"https://openweathermap.org/img/wn/{_weatherDataProvider.WeatherIcon}.png";

            // set ToolTip
            ToolTip tt_weather = new ToolTip();

            tt_weather.SetToolTip(pic_weather, $"{_weatherDataProvider.Name}\n" +
                                                $"{_weatherDataProvider.Weather}\n" +
                                                $"{_weatherDataProvider.Temp}°C");

            // init
            lbl_playlistName.Text = string.Empty;
            lbl_itemDetails.Text = string.Empty;
            lbl_playlistDetails.Text = string.Empty;
            EnableEditControls(false);




        }

        private void EnableEditControls(bool controlsEnabled)
        {
            addToolStripMenuItem.Enabled = controlsEnabled;
            removeToolStripMenuItem.Enabled = controlsEnabled;
            clearToolStripMenuItem.Enabled = controlsEnabled;
            saveToolStripMenuItem.Enabled = controlsEnabled;
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_newPlaylistDataProvider.ShowEditor() != DialogResult.OK)
            {
                return;
            }


            //HACK: Wird verbessert!
            _playlist = new CoreTypes.Playlist(_newPlaylistDataProvider.PlaylistName,
                                               _newPlaylistDataProvider.PlaylistAuthor);

            //update view
            EnableEditControls(true);
            ShowPlaylistDetails();
            ShowPlaylistItems();
        }

        private void ShowPlaylistItems()
        {
            int imageIndex = 0;

            lst_itemsView.Items.Clear();
            imageList.Images.Clear();

            foreach (var item in _playlist.Items)
            {
                var listViewItem = new ListViewItem(item.ToString());
                listViewItem.Tag = item;

                if (item.Thumbnail != null)
                {
                    imageList.Images.Add(item.Thumbnail);
                }
                else
                {
                    imageList.Images.Add(Resource.no_image_icon);
                }
                listViewItem.ImageIndex = imageIndex++;
                lst_itemsView.Items.Add(listViewItem);
            }

            lst_itemsView.LargeImageList = imageList;

        }

        private void ShowPlaylistDetails()
        {
            lbl_playlistName.Text = _playlist.Name;
            lbl_playlistDetails.Text = $"Gesamt Spieldauer: {_playlist.Duration.ToString("hh\\:mm\\:ss")} Autor: {_playlist.Author}";
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }


            foreach (var fileName in openFileDialog.FileNames)
            {
                var newItem = _playlistItemFactory.Create(fileName);

                if (newItem == null)
                {
                    return;
                }

                _playlist.Add(newItem);
            }

            ShowPlaylistDetails();
            ShowPlaylistItems();
        }

        private void lst_itemsView_SelectedIndexChanged(object sender, EventArgs e)
        {
          var item =  GetSelectedPlaylistItem(sender);

            if(item == null)
            {
                return; 
            }

            ShowPlaylistItemDetails(item);
        }

        private void ShowPlaylistItemDetails(IPlaylistItem item)
        {

            if (item == null)
            { 
                return; 
            }
            lbl_itemDetails.Text = $"Pfad: {item.FilePath} {Environment.NewLine}";
            lbl_itemDetails.Text += $"Dauer: {item.Duration.ToString("hh\\:mm\\:ss")}";
        }

        private IPlaylistItem GetSelectedPlaylistItem(object sender)
        {
            var listView = sender as ListView;
            if (listView == null || listView.SelectedItems.Count != 1)
            {
                return null;
            }
            var selectedItem = listView.SelectedItems[0];
            var playlistItem = selectedItem.Tag as IPlaylistItem;
            if (playlistItem == null)
            {
                return null;
            }

            return playlistItem;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = GetSelectedPlaylistItem(lst_itemsView);
            if (item == null)
            {
                return;
            }
             
            _playlist.Remove(item);

            ShowPlaylistDetails();
            ShowPlaylistItems();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _playlist.Clear();

            ShowPlaylistDetails();
            ShowPlaylistItems();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = $"{_playlist.Name.Replace (" ", "_")}.txt";


            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _m3uRepository.Save(_playlist, Path.GetFullPath(saveFileDialog.FileName));
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (_playlist != null)
            {
                _playlist.Clear();
                ShowPlaylistDetails();
                ShowPlaylistItems();
            }
            _playlist = (CoreTypes.Playlist)_m3uRepository.Load(Path.GetFullPath(openFileDialog.FileName));

            EnableEditControls(true);
            ShowPlaylistDetails();
            ShowPlaylistItems();
        }
    }
}
