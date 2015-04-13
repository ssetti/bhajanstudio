namespace Bhajans
{
    partial class Form1
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
            this.soundExTextBox = new System.Windows.Forms.TextBox();
            this.soundExButton = new System.Windows.Forms.Button();
            this.f = new System.Windows.Forms.Label();
            this.soundExLabel = new System.Windows.Forms.Label();
            this.soundExTextBox2 = new System.Windows.Forms.TextBox();
            this.soundExLabel2 = new System.Windows.Forms.Label();
            this.soundExMatch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // soundExTextBox
            // 
            this.soundExTextBox.Location = new System.Drawing.Point(12, 20);
            this.soundExTextBox.Name = "soundExTextBox";
            this.soundExTextBox.Size = new System.Drawing.Size(100, 20);
            this.soundExTextBox.TabIndex = 0;
            // 
            // soundExButton
            // 
            this.soundExButton.Location = new System.Drawing.Point(12, 83);
            this.soundExButton.Name = "soundExButton";
            this.soundExButton.Size = new System.Drawing.Size(75, 23);
            this.soundExButton.TabIndex = 1;
            this.soundExButton.Text = "Compute SoundEx";
            this.soundExButton.UseVisualStyleBackColor = true;
            this.soundExButton.Click += new System.EventHandler(this.soundExButton_Click);
            // 
            // f
            // 
            this.f.AutoSize = true;
            this.f.Location = new System.Drawing.Point(12, 67);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(0, 13);
            this.f.TabIndex = 2;
            // 
            // soundExLabel
            // 
            this.soundExLabel.AutoSize = true;
            this.soundExLabel.Location = new System.Drawing.Point(12, 43);
            this.soundExLabel.Name = "soundExLabel";
            this.soundExLabel.Size = new System.Drawing.Size(0, 13);
            this.soundExLabel.TabIndex = 3;
            // 
            // soundExTextBox2
            // 
            this.soundExTextBox2.Location = new System.Drawing.Point(118, 20);
            this.soundExTextBox2.Name = "soundExTextBox2";
            this.soundExTextBox2.Size = new System.Drawing.Size(162, 20);
            this.soundExTextBox2.TabIndex = 4;
            // 
            // soundExLabel2
            // 
            this.soundExLabel2.AutoSize = true;
            this.soundExLabel2.Location = new System.Drawing.Point(115, 43);
            this.soundExLabel2.Name = "soundExLabel2";
            this.soundExLabel2.Size = new System.Drawing.Size(0, 13);
            this.soundExLabel2.TabIndex = 5;
            // 
            // soundExMatch
            // 
            this.soundExMatch.AutoSize = true;
            this.soundExMatch.Location = new System.Drawing.Point(115, 83);
            this.soundExMatch.Name = "soundExMatch";
            this.soundExMatch.Size = new System.Drawing.Size(0, 13);
            this.soundExMatch.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 117);
            this.Controls.Add(this.soundExMatch);
            this.Controls.Add(this.soundExLabel2);
            this.Controls.Add(this.soundExTextBox2);
            this.Controls.Add(this.soundExLabel);
            this.Controls.Add(this.f);
            this.Controls.Add(this.soundExButton);
            this.Controls.Add(this.soundExTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox soundExTextBox;
        private System.Windows.Forms.Button soundExButton;
        private System.Windows.Forms.Label f;
        private System.Windows.Forms.Label soundExLabel;
        private System.Windows.Forms.TextBox soundExTextBox2;
        private System.Windows.Forms.Label soundExLabel2;
        private System.Windows.Forms.Label soundExMatch;
    }
}