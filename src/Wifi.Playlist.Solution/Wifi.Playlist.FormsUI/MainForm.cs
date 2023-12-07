using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.Playlist.CoreTypes;
using Wifi.Playlist.FormsUI.Properties;

namespace Wifi.Playlist.FormsUI
{
    public partial class MainForm : Form
    {
        private ToolTip tt_weather = new ToolTip();
        private IPlaylist _playlist;
        private readonly INewPlaylistDataProvider _newPlaylistDataProvider;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IWeatherDataProvider _weatherDataProvider;

        public MainForm(INewPlaylistDataProvider newPlaylistDataProvider,
                        IWeatherDataProvider weatherDataProvider,
                        IPlaylistItemFactory playlistItemFactory,
                        IRepositoryFactory repositoryFactory)
        {
            InitializeComponent();

            _newPlaylistDataProvider = newPlaylistDataProvider;
            _playlistItemFactory = playlistItemFactory;
            _repositoryFactory = repositoryFactory;
            _weatherDataProvider = weatherDataProvider;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get Weather Data
            _weatherDataProvider.GetWeather();

            //get Weather Icon
            pic_weather.ImageLocation = $"http://openweathermap.org/img/wn/{_weatherDataProvider.WeatherIcon}.png";

            // set ToolTip

            tt_weather.SetToolTip(pic_weather, $"{_weatherDataProvider.Name}\n" +
                                                $"{_weatherDataProvider.Weather}\n" +
                                                $"{_weatherDataProvider.Temp}°C");


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

            //HACK: Wird verbessert!! 
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
                    imageList.Images.Add(Resource.no_image_available);
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
            SetupFileDialog(openFileDialog, "Select Item", string.Empty, 
                            true, _playlistItemFactory.AvailableTypes);

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

        private void SetupFileDialog(FileDialog fileDialog, string title, string defaultFileName, bool multiselect, IEnumerable<IFileInfo> availableTypes)
        {           
            if(fileDialog is OpenFileDialog openFileDialog)
            {                
                openFileDialog.Multiselect = multiselect;
            }
            
            fileDialog.Title = title;
            fileDialog.FileName = defaultFileName;
            fileDialog.Filter = CreateFilter(availableTypes);            
        }

        private string CreateFilter(IEnumerable<IFileInfo> availableTypes)
        {
            string filter = string.Empty;

            filter = "All supported types|";

            var extensions = availableTypes.Select(x => x.Extension);
            extensions.ToList().ForEach(extension => filter += "*" + extension + ";");

            filter += "|";

            foreach (var type in availableTypes)
            {
                filter += $"{type.Description}|*{type.Extension}|";
            }

            //remove last | from filter string
            filter = filter.Substring(0, filter.Length - 1);
            return filter;
        }

        private void lst_itemsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = GetSelectedPlaylistItem(sender);
            if(item == null)
            {
                return;
            }

            ShowPlaylistItemDetails(item);
        }

        private void ShowPlaylistItemDetails(IPlaylistItem item)
        {
            if(item == null)
            {
                return;
            }

            lbl_itemDetails.Text =  $"Pfad:  {item.FilePath} {Environment.NewLine}";
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
            if(item == null)
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
            SetupFileDialog(saveFileDialog1, "Save playlist as",
                            _playlist.Name, false, _repositoryFactory.AvailableTypes);

            if(saveFileDialog1.ShowDialog() != DialogResult.OK) 
            {
                return;
            }

            var playlistPath = saveFileDialog1.FileName;
            var repository = _repositoryFactory.Create(playlistPath);

            if(repository != null)
            {
                repository.Save(_playlist, playlistPath);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupFileDialog(openFileDialog, "Select Playlist", "", false, 
                            _repositoryFactory.AvailableTypes);

            if(openFileDialog.ShowDialog() != DialogResult.OK) 
            { 
                return; 
            }

            var repository = _repositoryFactory.Create(openFileDialog.FileName);
            if(repository != null)
            {
                _playlist = repository.Load(openFileDialog.FileName);

                EnableEditControls(true);
                ShowPlaylistDetails();
                ShowPlaylistItems();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tt_weather.SetToolTip(pic_weather, $"{_weatherDataProvider.Name}\n" +
                                    $"{_weatherDataProvider.Weather}\n" +
                                    $"{_weatherDataProvider.Temp}°C");

            timer.Enabled = false;
        }
    }
}
