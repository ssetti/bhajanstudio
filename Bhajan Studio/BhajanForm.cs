using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bhajans
{
    public partial class BhajanForm : Form
    {
        private int bhajanId = -1;
        private bool newRecord = false;
        private string songsFolder = "";

        public BhajanForm()
        {
            InitializeComponent();
        }

        private void BhajanForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.LanguageQuery' table. You can move, or remove it, as needed.
            this.languageQueryTableAdapter.Fill(this.sai_bhajans5DataSet.LanguageQuery);
            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.LordNameQuery' table. You can move, or remove it, as needed.
            this.lordNameQueryTableAdapter.Fill(this.sai_bhajans5DataSet.LordNameQuery);
            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.LanguageCategoryQuery' table. You can move, or remove it, as needed.
            this.languageCategoryQueryTableAdapter.Fill(this.sai_bhajans5DataSet.LanguageCategoryQuery);

            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.Bhajans' table. You can move, or remove it, as needed.
            if (!BhajansForm.bhajanId.Equals(""))
            {
                newRecord = false;
                this.bhajanId = Int32.Parse(BhajansForm.bhajanId);
                this.bhajansTableAdapter.FillByBhajanID(this.sai_bhajans5DataSet.Bhajans, this.bhajanId);
                deleteButton.Show();
            }
            else
            {
                newRecord = true;
                this.lordNameComboBox.Text = "";
                this.languageComboBox.Text = "";
                this.languageCategoryComboBox.Text = "";
                deleteButton.Hide();
            }

            //Read songs directory
            songsFolder = Properties.Settings.Default.SongsFolder;

//            this.windowsMediaPlayer.settings.autoStart = false;
//            this.windowsMediaPlayer.URL = songsFolder + "\\" + this.titleTextBox.Text + ".mp3";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string translation = null;
            string lordName = null;
            string language = null;
            string languageCategory = null;
            string songFile = null;
            string keywords = null;

            if (this.titleTextBox.Text.Equals(""))
            {
                MessageBox.Show("Title is not entered", "Wait a minute!");
                titleTextBox.Focus();
                return;
            }

            if (this.bodyTextBox.Text.Equals(""))
            {
                MessageBox.Show("Body is not entered", "Wait a minute!");
                bodyTextBox.Focus();
                return;
            }

            if (!this.translationTextBox.Text.Equals(""))
                translation = this.translationTextBox.Text;

            if (!this.lordNameComboBox.Text.Equals(""))
                lordName = this.lordNameComboBox.Text;

            if (!this.languageComboBox.Text.Equals(""))
                language = this.languageComboBox.Text;

            if (!this.languageCategoryComboBox.Text.Equals(""))
                languageCategory = this.languageCategoryComboBox.Text;

            if (!this.songFileTextBox.Text.Equals(""))
                songFile = this.songFileTextBox.Text;

            if (!this.keywordsTextBox.Text.Equals(""))
                keywords = this.keywordsTextBox.Text;

            if (newRecord == true)
            {
                bhajanId = 
                    this.bhajansTableAdapter.Insert(this.titleTextBox.Text,
                    this.bodyTextBox.Text,
                    translation,
                    lordName,
                    language,
                    languageCategory,
                    false,
                    songFile,
                    keywords);
            }
            else
            {
                this.bhajansTableAdapter.UpdateByBhajanID(this.titleTextBox.Text,
                    this.bodyTextBox.Text,
                    translation,
                    lordName,
                    language,
                    languageCategory,
                    false,
                    songFile,
                    keywords,
                    this.bhajanId);
            }

            Exit();

            BhajansForm.updateBhajansList(bhajanId);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Delete this Bhajan?", "Stop!", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.bhajansTableAdapter.DeleteByBhajanID(this.bhajanId);
                Exit();
                BhajansForm.updateBhajansList(0);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
//            this.windowsMediaPlayer.Dispose();
            this.Close();
        }
    }
}
