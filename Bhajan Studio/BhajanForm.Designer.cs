namespace Bhajans
{
    partial class BhajanForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BhajanForm));
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.bhajansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sai_bhajans5DataSet = new Bhajans.sai_bhajans5DataSet();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.bhajansTableAdapter = new Bhajans.sai_bhajans5DataSetTableAdapters.BhajansTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.translationTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lordNameComboBox = new System.Windows.Forms.ComboBox();
            this.lordNameQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.languageCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.languageCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
//            this.windowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.songFileTextBox = new System.Windows.Forms.TextBox();
            this.lordNameQueryTableAdapter = new Bhajans.sai_bhajans5DataSetTableAdapters.LordNameQueryTableAdapter();
            this.languageQueryTableAdapter = new Bhajans.sai_bhajans5DataSetTableAdapters.LanguageQueryTableAdapter();
            this.bhajanIDTextBox = new System.Windows.Forms.TextBox();
            this.languageCategoryQueryTableAdapter = new Bhajans.sai_bhajans5DataSetTableAdapters.LanguageCategoryQueryTableAdapter();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.keywordsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bhajansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sai_bhajans5DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lordNameQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageCategoryBindingSource)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.windowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "Title", true));
            this.titleTextBox.Location = new System.Drawing.Point(107, 13);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(416, 20);
            this.titleTextBox.TabIndex = 0;
            // 
            // bhajansBindingSource
            // 
            this.bhajansBindingSource.DataMember = "Bhajans";
            this.bhajansBindingSource.DataSource = this.sai_bhajans5DataSet;
            // 
            // sai_bhajans5DataSet
            // 
            this.sai_bhajans5DataSet.DataSetName = "sai_bhajans5DataSet";
            this.sai_bhajans5DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "Body", true));
            this.bodyTextBox.Location = new System.Drawing.Point(107, 34);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bodyTextBox.Size = new System.Drawing.Size(416, 80);
            this.bodyTextBox.TabIndex = 1;
            // 
            // bhajansTableAdapter
            // 
            this.bhajansTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Body";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Translation";
            // 
            // translationTextBox
            // 
            this.translationTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "Translation", true));
            this.translationTextBox.Location = new System.Drawing.Point(107, 115);
            this.translationTextBox.Multiline = true;
            this.translationTextBox.Name = "translationTextBox";
            this.translationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.translationTextBox.Size = new System.Drawing.Size(416, 58);
            this.translationTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lord Name";
            // 
            // lordNameComboBox
            // 
            this.lordNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "LordName", true));
            this.lordNameComboBox.DataSource = this.lordNameQueryBindingSource;
            this.lordNameComboBox.DisplayMember = "LordName";
            this.lordNameComboBox.FormattingEnabled = true;
            this.lordNameComboBox.Location = new System.Drawing.Point(107, 173);
            this.lordNameComboBox.Name = "lordNameComboBox";
            this.lordNameComboBox.Size = new System.Drawing.Size(199, 21);
            this.lordNameComboBox.TabIndex = 3;
            this.lordNameComboBox.ValueMember = "LordName";
            // 
            // lordNameQueryBindingSource
            // 
            this.lordNameQueryBindingSource.DataMember = "LordNameQuery";
            this.lordNameQueryBindingSource.DataSource = this.sai_bhajans5DataSet;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Language";
            // 
            // languageComboBox
            // 
            this.languageComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "Language", true));
            this.languageComboBox.DataSource = this.languageQueryBindingSource;
            this.languageComboBox.DisplayMember = "Language";
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Location = new System.Drawing.Point(107, 195);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(199, 21);
            this.languageComboBox.TabIndex = 4;
            this.languageComboBox.ValueMember = "Language";
            // 
            // languageQueryBindingSource
            // 
            this.languageQueryBindingSource.DataMember = "LanguageQuery";
            this.languageQueryBindingSource.DataSource = this.sai_bhajans5DataSet;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Language Category";
            // 
            // languageCategoryComboBox
            // 
            this.languageCategoryComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "LangCategory", true));
            this.languageCategoryComboBox.DataSource = this.languageCategoryBindingSource;
            this.languageCategoryComboBox.DisplayMember = "LangCategory";
            this.languageCategoryComboBox.FormattingEnabled = true;
            this.languageCategoryComboBox.Location = new System.Drawing.Point(107, 217);
            this.languageCategoryComboBox.Name = "languageCategoryComboBox";
            this.languageCategoryComboBox.Size = new System.Drawing.Size(199, 21);
            this.languageCategoryComboBox.TabIndex = 5;
            this.languageCategoryComboBox.ValueMember = "LangCategory";
            // 
            // languageCategoryBindingSource
            // 
            this.languageCategoryBindingSource.DataMember = "LanguageCategoryQuery";
            this.languageCategoryBindingSource.DataSource = this.sai_bhajans5DataSet;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(314, 236);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(395, 236);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // windowsMediaPlayer
            // 
//            this.windowsMediaPlayer.Enabled = true;
//            this.windowsMediaPlayer.Location = new System.Drawing.Point(314, 173);
//            this.windowsMediaPlayer.Name = "windowsMediaPlayer";
//            this.windowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("windowsMediaPlayer.OcxState")));
//            this.windowsMediaPlayer.Size = new System.Drawing.Size(209, 45);
//            this.windowsMediaPlayer.TabIndex = 7;
            // 
            // songFileTextBox
            // 
            this.songFileTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "SongFile", true));
            this.songFileTextBox.Location = new System.Drawing.Point(107, 256);
            this.songFileTextBox.Name = "songFileTextBox";
            this.songFileTextBox.Size = new System.Drawing.Size(199, 20);
            this.songFileTextBox.TabIndex = 15;
            this.songFileTextBox.Visible = false;
            // 
            // lordNameQueryTableAdapter
            // 
            this.lordNameQueryTableAdapter.ClearBeforeFill = true;
            // 
            // languageQueryTableAdapter
            // 
            this.languageQueryTableAdapter.ClearBeforeFill = true;
            // 
            // bhajanIDTextBox
            // 
            this.bhajanIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "Bhajan ID", true));
            this.bhajanIDTextBox.Location = new System.Drawing.Point(107, 1);
            this.bhajanIDTextBox.Name = "bhajanIDTextBox";
            this.bhajanIDTextBox.Size = new System.Drawing.Size(199, 20);
            this.bhajanIDTextBox.TabIndex = 16;
            this.bhajanIDTextBox.Visible = false;
            // 
            // languageCategoryQueryTableAdapter
            // 
            this.languageCategoryQueryTableAdapter.ClearBeforeFill = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Wingdings 2", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.deleteButton.Location = new System.Drawing.Point(499, 233);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(24, 26);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "3";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Keywords";
            // 
            // keywordsTextBox
            // 
            this.keywordsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "Keywords", true));
            this.keywordsTextBox.Location = new System.Drawing.Point(107, 239);
            this.keywordsTextBox.Name = "keywordsTextBox";
            this.keywordsTextBox.Size = new System.Drawing.Size(199, 20);
            this.keywordsTextBox.TabIndex = 6;
            // 
            // BhajanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(529, 265);
            this.Controls.Add(this.keywordsTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.bhajanIDTextBox);
            this.Controls.Add(this.songFileTextBox);
//            this.Controls.Add(this.windowsMediaPlayer);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lordNameComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.translationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.languageCategoryComboBox);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bhajansBindingSource, "Title", true));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BhajanForm";
            this.ShowInTaskbar = false;
            this.Text = "New Bhajan";
            this.Load += new System.EventHandler(this.BhajanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bhajansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sai_bhajans5DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lordNameQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageCategoryBindingSource)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.windowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleTextBox;
        private sai_bhajans5DataSet sai_bhajans5DataSet;
        private System.Windows.Forms.BindingSource bhajansBindingSource;
        private Bhajans.sai_bhajans5DataSetTableAdapters.BhajansTableAdapter bhajansTableAdapter;
        private System.Windows.Forms.TextBox bodyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox translationTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox lordNameComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox languageCategoryComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
//        private AxWMPLib.AxWindowsMediaPlayer windowsMediaPlayer;
        private System.Windows.Forms.TextBox songFileTextBox;
        private System.Windows.Forms.BindingSource lordNameQueryBindingSource;
        private Bhajans.sai_bhajans5DataSetTableAdapters.LordNameQueryTableAdapter lordNameQueryTableAdapter;
        private System.Windows.Forms.BindingSource languageQueryBindingSource;
        private Bhajans.sai_bhajans5DataSetTableAdapters.LanguageQueryTableAdapter languageQueryTableAdapter;
        private System.Windows.Forms.TextBox bhajanIDTextBox;
        private System.Windows.Forms.BindingSource languageCategoryBindingSource;
        private Bhajans.sai_bhajans5DataSetTableAdapters.LanguageCategoryQueryTableAdapter languageCategoryQueryTableAdapter;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox keywordsTextBox;
    }
}