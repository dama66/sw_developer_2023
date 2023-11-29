using System;
using System.Windows.Forms;

namespace Wifi.Playlist.FormsUI
{
    public partial class NewPlaylistForm : Form, INewPlaylistDataProvider
    {
        public NewPlaylistForm()
        {
            InitializeComponent();
        }

        public string PlaylistName
        {
            get
            {
                return txt_name.Text;
            }
        }

        public string PlaylistAuthor
        {
            get
            {
                return txt_author.Text;
            }
        }

        public DialogResult ShowEditor()
        {
            return ShowDialog();
        }


        private void btt_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_author.Text) || string.IsNullOrEmpty(txt_name.Text))
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btt_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }        
    }
}
