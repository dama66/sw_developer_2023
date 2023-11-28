namespace Wifi.Playlist.FormsUI
{
    partial class NewPlaylistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_author = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btt_ok = new System.Windows.Forms.Button();
            this.btt_cancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bezeichnung:";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(133, 30);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(255, 20);
            this.txt_name.TabIndex = 1;
            // 
            // txt_author
            // 
            this.txt_author.Location = new System.Drawing.Point(133, 65);
            this.txt_author.Name = "txt_author";
            this.txt_author.Size = new System.Drawing.Size(255, 20);
            this.txt_author.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Autor:";
            // 
            // btt_ok
            // 
            this.btt_ok.Location = new System.Drawing.Point(291, 126);
            this.btt_ok.Name = "btt_ok";
            this.btt_ok.Size = new System.Drawing.Size(75, 23);
            this.btt_ok.TabIndex = 4;
            this.btt_ok.Text = "OK";
            this.btt_ok.UseVisualStyleBackColor = true;
            this.btt_ok.Click += new System.EventHandler(this.btt_ok_Click);
            // 
            // btt_cancle
            // 
            this.btt_cancle.Location = new System.Drawing.Point(372, 126);
            this.btt_cancle.Name = "btt_cancle";
            this.btt_cancle.Size = new System.Drawing.Size(75, 23);
            this.btt_cancle.TabIndex = 5;
            this.btt_cancle.Text = "Abbruch";
            this.btt_cancle.UseVisualStyleBackColor = true;
            this.btt_cancle.Click += new System.EventHandler(this.btt_cancle_Click);
            // 
            // NewPlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btt_cancle;
            this.ClientSize = new System.Drawing.Size(466, 169);
            this.Controls.Add(this.btt_cancle);
            this.Controls.Add(this.btt_ok);
            this.Controls.Add(this.txt_author);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewPlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neue Playlist anlegen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_author;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btt_ok;
        private System.Windows.Forms.Button btt_cancle;
    }
}