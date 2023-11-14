using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EinstiegForms
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            lbl_result.Text = "Ergebnis: " + txt_name.Text;
            txt_name.Text = string.Empty;
            txt_name.Focus();
        }
    }
}
