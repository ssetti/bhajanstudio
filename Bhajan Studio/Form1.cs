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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void soundExButton_Click(object sender, EventArgs e)
        {
            soundExLabel.Text = SoundEx.Soundex(soundExTextBox.Text);
            soundExLabel2.Text = SoundEx.Soundex(soundExTextBox2.Text);

            if (SoundEx.ContainsSoundingString(soundExTextBox2.Text, soundExTextBox.Text))
                soundExMatch.Text = "True";
            else
                soundExMatch.Text = "False";
        }
    }
}
