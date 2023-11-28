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

namespace Wifi.Playlist.FormsUI
{
    public partial class MainForm : Form
    {
        private CoreTypes.Playlist _playlist;
        private readonly INewPlaylistDataProvider _newPlaylistDataProvider;

        public MainForm(INewPlaylistDataProvider newPlaylistDataProvider)
        {
            InitializeComponent();
            _newPlaylistDataProvider = newPlaylistDataProvider;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_itemDetails.Text = string.Empty;
            lbl_playlistDetails.Text = string.Empty;    
            lbl_playlistName.Text = string.Empty;

            EnableEditControls(false);
        }

        private void EnableEditControls(bool controlsEnabled)
        {
            addToolStripMenuItem.Enabled = controlsEnabled;
            removeToolStripMenuItem.Enabled = controlsEnabled;
            clearToolStripMenuItem.Enabled = controlsEnabled;
            saveToolStripMenuItem.Enabled = controlsEnabled;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if(_newPlaylistDataProvider.ShowEditor() != DialogResult.OK) 
            {
                return;
            }

            _playlist = new CoreTypes.Playlist(_newPlaylistDataProvider.PlaylistName, 
                                                _newPlaylistDataProvider.PlaylistAuthor);

            //update view
            EnableEditControls(true);

           ShowPlaylistDetails();
           ShowPlaylistItems();
        }

        private void ShowPlaylistItems()
        {
           
        }

        private void ShowPlaylistDetails()
        {
            lbl_playlistName.Text = _playlist.Name;
            lbl_playlistDetails.Text = $"Gesamt Spieldauer: {_playlist.Duration} Autor: {_playlist.Author}";
        }
    }
}
