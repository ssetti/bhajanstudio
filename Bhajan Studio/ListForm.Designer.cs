namespace Bhajans
{
    partial class ListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListForm));
            this.allDataGridView = new System.Windows.Forms.DataGridView();
            this.allScalesQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sai_bhajans5DataSet = new Bhajans.sai_bhajans5DataSet();
            this.cancelButton = new System.Windows.Forms.Button();
            this.allScalesQueryTableAdapter = new Bhajans.sai_bhajans5DataSetTableAdapters.AllScalesQueryTableAdapter();
            this.scaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.allDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allScalesQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sai_bhajans5DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // allDataGridView
            // 
            this.allDataGridView.AllowUserToAddRows = false;
            this.allDataGridView.AllowUserToDeleteRows = false;
            this.allDataGridView.AllowUserToResizeColumns = false;
            this.allDataGridView.AllowUserToResizeRows = false;
            this.allDataGridView.AutoGenerateColumns = false;
            this.allDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.allDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scaleDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.MyName});
            this.allDataGridView.DataSource = this.allScalesQueryBindingSource;
            this.allDataGridView.Location = new System.Drawing.Point(10, 12);
            this.allDataGridView.MultiSelect = false;
            this.allDataGridView.Name = "allDataGridView";
            this.allDataGridView.ReadOnly = true;
            this.allDataGridView.RowHeadersVisible = false;
            this.allDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allDataGridView.Size = new System.Drawing.Size(518, 245);
            this.allDataGridView.TabIndex = 0;
            // 
            // allScalesQueryBindingSource
            // 
            this.allScalesQueryBindingSource.DataMember = "AllScalesQuery";
            this.allScalesQueryBindingSource.DataSource = this.sai_bhajans5DataSet;
            // 
            // sai_bhajans5DataSet
            // 
            this.sai_bhajans5DataSet.DataSetName = "sai_bhajans5DataSet";
            this.sai_bhajans5DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(453, 263);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // allScalesQueryTableAdapter
            // 
            this.allScalesQueryTableAdapter.ClearBeforeFill = true;
            // 
            // scaleDataGridViewTextBoxColumn
            // 
            this.scaleDataGridViewTextBoxColumn.DataPropertyName = "Scale";
            this.scaleDataGridViewTextBoxColumn.HeaderText = "Scale";
            this.scaleDataGridViewTextBoxColumn.Name = "scaleDataGridViewTextBoxColumn";
            this.scaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.scaleDataGridViewTextBoxColumn.Width = 59;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 52;
            // 
            // MyName
            // 
            this.MyName.DataPropertyName = "Name";
            this.MyName.HeaderText = "Name";
            this.MyName.Name = "MyName";
            this.MyName.ReadOnly = true;
            this.MyName.Width = 60;
            // 
            // ListForm
            // 
            this.AcceptButton = this.cancelButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(538, 297);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.allDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bhajans with Scales for the Bhajan Leader";
            this.Load += new System.EventHandler(this.List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allScalesQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sai_bhajans5DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView allDataGridView;
        private System.Windows.Forms.BindingSource allScalesQueryBindingSource;
        private sai_bhajans5DataSet sai_bhajans5DataSet;
        private Bhajans.sai_bhajans5DataSetTableAdapters.AllScalesQueryTableAdapter allScalesQueryTableAdapter;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn scaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyName;
    }
}