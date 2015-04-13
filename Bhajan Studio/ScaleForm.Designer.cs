namespace Bhajans
{
    partial class ScaleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScaleForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bhajanLeaderComboBox = new System.Windows.Forms.ComboBox();
            this.bhajanLeadersQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sai_bhajans5DataSet = new Bhajans.sai_bhajans5DataSet();
            this.scaleComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bhajanLeadersQueryTableAdapter = new Bhajans.sai_bhajans5DataSetTableAdapters.BhajanLeadersQueryTableAdapter();
            this.bhajanLeadersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bhajanLeadersTableAdapter = new Bhajans.sai_bhajans5DataSetTableAdapters.BhajanLeadersTableAdapter();
            this.bhajanScalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bhajanScalesTableAdapter = new Bhajans.sai_bhajans5DataSetTableAdapters.BhajanScalesTableAdapter();
            this.removeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bhajanLeadersQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sai_bhajans5DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bhajanLeadersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bhajanScalesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bhajan Leader";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scale";
            // 
            // bhajanLeaderComboBox
            // 
            this.bhajanLeaderComboBox.DataSource = this.bhajanLeadersQueryBindingSource;
            this.bhajanLeaderComboBox.DisplayMember = "Name";
            this.bhajanLeaderComboBox.FormattingEnabled = true;
            this.bhajanLeaderComboBox.Location = new System.Drawing.Point(89, 8);
            this.bhajanLeaderComboBox.Name = "bhajanLeaderComboBox";
            this.bhajanLeaderComboBox.Size = new System.Drawing.Size(191, 21);
            this.bhajanLeaderComboBox.TabIndex = 1;
            this.bhajanLeaderComboBox.ValueMember = "Name";
            // 
            // bhajanLeadersQueryBindingSource
            // 
            this.bhajanLeadersQueryBindingSource.DataMember = "BhajanLeadersQuery";
            this.bhajanLeadersQueryBindingSource.DataSource = this.sai_bhajans5DataSet;
            // 
            // sai_bhajans5DataSet
            // 
            this.sai_bhajans5DataSet.DataSetName = "sai_bhajans5DataSet";
            this.sai_bhajans5DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // scaleComboBox
            // 
            this.scaleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scaleComboBox.FormattingEnabled = true;
            this.scaleComboBox.Items.AddRange(new object[] {
            "",
            "-",
            "1",
            "1M",
            "1m",
            "1Madhyam",
            "1.5",
            "1.5M",
            "1.5m",
            "1.5Madhyam",
            "2",
            "2M",
            "2m",
            "2Madhyam",
            "2.5",
            "2.5M",
            "2.5m",
            "2.5Madhyam",
            "3",
            "3M",
            "3m",
            "3Madhyam",
            "4",
            "4M",
            "4m",
            "4Madhyam",
            "4.5",
            "4.5M",
            "4.5m",
            "4.5Madhyam",
            "5",
            "5M",
            "5m",
            "5Madhyam",
            "5.5",
            "5.5M",
            "5.5m",
            "5.5Madhyam",
            "6",
            "6M",
            "6m",
            "6Madhyam",
            "6.5",
            "6.5M",
            "6.5m",
            "6.5Madhyam",
            "7",
            "7M",
            "7m",
            "7Madhyam",
            "A",
            "Am",
            "AM",
            "A# (Bb)",
            "A#m (Bbm)",
            "A#M (BbM)",
            "B",
            "Bm",
            "BM",
            "C (B#)",
            "Cm (B#m)",
            "CM (B#M)",
            "C#",
            "C#m",
            "C#M",
            "D",
            "Dm",
            "DM",
            "D#",
            "D#m",
            "D#M",
            "E",
            "Em",
            "EM",
            "F (E#)",
            "Fm (E#m)",
            "FM (E#M)",
            "F#",
            "F#m",
            "F#M",
            "G",
            "Gm",
            "GM",
            "G#",
            "G#m",
            "G#M"});
            this.scaleComboBox.Location = new System.Drawing.Point(89, 39);
            this.scaleComboBox.Name = "scaleComboBox";
            this.scaleComboBox.Size = new System.Drawing.Size(191, 21);
            this.scaleComboBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(89, 71);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(170, 71);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // bhajanLeadersQueryTableAdapter
            // 
            this.bhajanLeadersQueryTableAdapter.ClearBeforeFill = true;
            // 
            // bhajanLeadersBindingSource
            // 
            this.bhajanLeadersBindingSource.DataMember = "BhajanLeaders";
            this.bhajanLeadersBindingSource.DataSource = this.sai_bhajans5DataSet;
            // 
            // bhajanLeadersTableAdapter
            // 
            this.bhajanLeadersTableAdapter.ClearBeforeFill = true;
            // 
            // bhajanScalesBindingSource
            // 
            this.bhajanScalesBindingSource.DataMember = "BhajanScales";
            this.bhajanScalesBindingSource.DataSource = this.sai_bhajans5DataSet;
            // 
            // bhajanScalesTableAdapter
            // 
            this.bhajanScalesTableAdapter.ClearBeforeFill = true;
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Wingdings 2", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.removeButton.Location = new System.Drawing.Point(255, 70);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(24, 24);
            this.removeButton.TabIndex = 21;
            this.removeButton.Text = "3  &Delete";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // ScaleForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(287, 102);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.scaleComboBox);
            this.Controls.Add(this.bhajanLeaderComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScaleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Scale";
            this.Load += new System.EventHandler(this.ScaleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bhajanLeadersQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sai_bhajans5DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bhajanLeadersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bhajanScalesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private sai_bhajans5DataSet sai_bhajans5DataSet;
        public System.Windows.Forms.ComboBox bhajanLeaderComboBox;
        public System.Windows.Forms.ComboBox scaleComboBox;
        private System.Windows.Forms.BindingSource bhajanLeadersQueryBindingSource;
        private Bhajans.sai_bhajans5DataSetTableAdapters.BhajanLeadersQueryTableAdapter bhajanLeadersQueryTableAdapter;
        private System.Windows.Forms.BindingSource bhajanLeadersBindingSource;
        private Bhajans.sai_bhajans5DataSetTableAdapters.BhajanLeadersTableAdapter bhajanLeadersTableAdapter;
        private System.Windows.Forms.BindingSource bhajanScalesBindingSource;
        private Bhajans.sai_bhajans5DataSetTableAdapters.BhajanScalesTableAdapter bhajanScalesTableAdapter;
        private System.Windows.Forms.Button removeButton;
    }
}