using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Runtime.InteropServices;

namespace Bhajans
{
    public partial class BhajansForm : Form
    {
        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        public static string style;
        public static string bhajanId;
        public static string bhajanLeader;
        public static string bhajanScale;
        public static BhajansForm theBhajansForm;
        public static PowerPoint.Application objApp = null;
        public static PowerPoint._Presentation objPres = null;
        string templateLocation;
        string emptyTemplateLocation;
        string outputFolder;
        bool useReferenceSlide;
        int referenceSlide;
        string beforeAfter;
        int titleTextBoxIndex;
        int bodyTextBoxIndex;
        int translationTextBoxIndex;
        int bhajanNumberTextBoxIndex;
        int nextBhajanTextBoxIndex;
        string titleTextBoxCharacteristics;
        string bodyTextBoxCharacteristics;
        string translationTextBoxCharacteristics;
        string bhajanNumberTextBoxCharacteristics;
        string nextBhajanTextBoxCharacteristics;
        string currentWorkingDirectory;
        string nextBhajanFormat;
        TextBoxCharacteristics titleCharacteristics = null;
        TextBoxCharacteristics bodyCharacteristics = null;
        TextBoxCharacteristics translationCharacteristics = null;
        TextBoxCharacteristics bhajanNumberCharacteristics = null;
        TextBoxCharacteristics nextBhajanCharacteristics = null;
        bool updatingView = false;

        public BhajansForm()
        {
            InitializeComponent();
        }

        private void BhajansForm_Load(object sender, EventArgs e)
        {
            this.Text = "Sai Bhajans (" + style + ")";
            theBhajansForm = this;
            currentWorkingDirectory = Directory.GetCurrentDirectory();

            //Get all bhajans
            this.bhajansTableAdapter.Fill(this.sai_bhajans5DataSet.Bhajans);
            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.BhajanScales' table. You can move, or remove it, as needed.
            this.bhajanScalesTableAdapter.Fill(this.sai_bhajans5DataSet.BhajanScales);
            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.BhajanLeaders' table. You can move, or remove it, as needed.
            this.bhajanLeadersTableAdapter.Fill(this.sai_bhajans5DataSet.BhajanLeaders);

            if (this.bhajansDataGridView.Rows.Count > 0)
                this.bhajanTextBox1.Text = this.bhajansDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            else
                this.bhajanTextBox1.Text = "";

            this.selectedDataGridView.Rows.Clear();

            //Get all bhajan leaders
            if (this.hideEmptyScalesCheckBox.Checked == true)
                this.bhajanScalesQueryTableAdapter.Fill2(this.sai_bhajans5DataSet.BhajanScalesQuery, Int32.Parse(this.bhajansDataGridView.SelectedRows[0].Cells[0].Value.ToString()), this.bhajanLeadersTextBox.Text);
            else
                this.bhajanScalesQueryTableAdapter.Fill(this.sai_bhajans5DataSet.BhajanScalesQuery, Int32.Parse(this.bhajansDataGridView.SelectedRows[0].Cells[0].Value.ToString()), this.bhajanLeadersTextBox.Text);

            //Read unbound settings
            templateLocation = Properties.Settings.Default.PowerPointTemplateLocation;
            emptyTemplateLocation = Properties.Settings.Default.PowerPointEmptyTemplateLocation;
            outputFolder = Properties.Settings.Default.OutputFolder;
            useReferenceSlide = Properties.Settings.Default.UseReferenceSlide;
            referenceSlide = Properties.Settings.Default.ReferenceSlideIndex;
            beforeAfter = Properties.Settings.Default.InsertBeforeOrAfter;
            nextBhajanFormat = Properties.Settings.Default.NextBhajanFormat;

            if (useReferenceSlide == true)
            {
                titleTextBoxIndex = Properties.Settings.Default.TitleTextBoxIndex;
                bodyTextBoxIndex = Properties.Settings.Default.BodyTextBoxIndex;
                translationTextBoxIndex = Properties.Settings.Default.TranslationTextBoxIndex;
                bhajanNumberTextBoxIndex = Properties.Settings.Default.BhajanNumberTextBoxIndex;
                nextBhajanTextBoxIndex = Properties.Settings.Default.NextBhajanTextBoxIndex;
            }
            else
            {
                titleTextBoxCharacteristics = Properties.Settings.Default.TitleTextBoxCharacteristics;
                if (titleTextBoxCharacteristics != null && !titleTextBoxCharacteristics.Equals(""))
                    titleCharacteristics = new TextBoxCharacteristics(titleTextBoxCharacteristics);
                bodyTextBoxCharacteristics = Properties.Settings.Default.BodyTextBoxCharacteristics;
                if (bodyTextBoxCharacteristics != null && !bodyTextBoxCharacteristics.Equals(""))
                    bodyCharacteristics = new TextBoxCharacteristics(bodyTextBoxCharacteristics);
                translationTextBoxCharacteristics = Properties.Settings.Default.TranslationTextBoxCharacteristics;
                if (translationTextBoxCharacteristics != null && !translationTextBoxCharacteristics.Equals(""))
                    translationCharacteristics = new TextBoxCharacteristics(translationTextBoxCharacteristics);
                bhajanNumberTextBoxCharacteristics = Properties.Settings.Default.BhajanNumberTextBoxCharacteristics;
                if (bhajanNumberTextBoxCharacteristics != null && !bhajanNumberTextBoxCharacteristics.Equals(""))
                    bhajanNumberCharacteristics = new TextBoxCharacteristics(bhajanNumberTextBoxCharacteristics);
                nextBhajanTextBoxCharacteristics = Properties.Settings.Default.NextBhajanTextBoxCharacteristics;
                if (nextBhajanTextBoxCharacteristics != null && !nextBhajanTextBoxCharacteristics.Equals(""))
                    nextBhajanCharacteristics = new TextBoxCharacteristics(nextBhajanTextBoxCharacteristics);
            }
        }

        private void BhajansForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;
                this.searchTextBox.Text = "";
                this.bhajanLeadersTextBox.Text = "";
                this.searchTextBox.Focus();
            }
            else if (e.Alt == true && e.KeyCode == Keys.L)
            {
                e.Handled = true;
                this.bhajanLeadersTextBox.Focus();
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            updatingView = true;
            filterBhajans();
            updatingView = false;
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            const int WM_KEYDOWN = 0x100;
            const int VK_DOWN = 0x28;

            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                bhajansDataGridView.Focus();
                PostMessage(bhajansDataGridView.Handle, WM_KEYDOWN, VK_DOWN, 0);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                addButton_Click(null, null);
            }
        }

        private void startsWithCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filterBhajans();
        }

        private void titleOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filterBhajans();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (bhajansDataGridView.SelectedRows.Count > 0)
            {
                bool found = false;
                string location = "";

                // Search to see if already added
                if (selectedDataGridView.Rows.Count > 0)
                {
                    for (int i = 0; i < selectedDataGridView.Rows.Count; i++)
                    {
                        if (bhajansDataGridView.SelectedRows[0].Cells[0].Value.Equals(selectedDataGridView.Rows[i].Cells[6].Value))
                        {
                            found = true;
                            location = selectedDataGridView.Rows[i].Cells[0].Value.ToString();
                            break;
                        }
                    }
                }

                DialogResult dr;
                if (found == true)
                {
                    dr = MessageBox.Show("You have already added this Bhajan at location " + location + ". Continue adding", "Wait a minute!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                        return;
                }

                string scale = "";
                string name = "";
                int bhajanLeaderId = -1;

                if (bhajanLeadersDataGridView.SelectedRows.Count > 0)
                {
                    if (bhajanLeadersDataGridView.SelectedRows[0].Cells[0].Value != null)
                        bhajanLeaderId = Int32.Parse(bhajanLeadersDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    if (bhajanLeadersDataGridView.SelectedRows[0].Cells[1].Value != null)
                        name = bhajanLeadersDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                    if (bhajanLeadersDataGridView.SelectedRows[0].Cells[2].Value != null)
                        scale = bhajanLeadersDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                }

                dr = MessageBox.Show("Do you want to add the following Bhajan:" +
                                                    "\r\rTitle:\t\t" + bhajansDataGridView.SelectedRows[0].Cells[1].Value +
                                                    "\rScale:\t\t" + scale +
                                                    "\rBhajan Leader:\t" + name, "Please verify", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    selectedDataGridView.Rows.Add();
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0].Value = selectedDataGridView.Rows.Count;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[1].Value = bhajansDataGridView.SelectedRows[0].Cells[1].Value;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[2].Value = scale;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[3].Value = name;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[4].Value = bhajansDataGridView.SelectedRows[0].Cells[2].Value;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[5].Value = bhajansDataGridView.SelectedRows[0].Cells[3].Value;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[6].Value = bhajansDataGridView.SelectedRows[0].Cells[0].Value;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[7].Value = bhajansDataGridView.SelectedRows[0].Cells[4].Value;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[8].Value = bhajansDataGridView.SelectedRows[0].Cells[5].Value;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[9].Value = bhajanLeaderId;

                    // Remove prior selections
                    for (int i = 0; i < selectedDataGridView.SelectedRows.Count; i++)
                        selectedDataGridView.SelectedRows[i].Selected = false;

                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Selected = true;

                    if (this.selectedDataGridView.SelectedRows.Count == 1 && this.selectedDataGridView.SelectedRows[0].Cells[7].Value != null)
                        this.bhajanTextBox2.Text = this.selectedDataGridView.SelectedRows[0].Cells[7].Value.ToString();
                    else
                        this.bhajanTextBox2.Text = "";
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int count = selectedDataGridView.SelectedRows.Count;
            if (count > 0)
            {
                DialogResult dr = MessageBox.Show("Do you want to remove selected Bhajans?", "Stop!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    for (int i = count - 1; i >= 0; i--)
                        selectedDataGridView.Rows.Remove(selectedDataGridView.SelectedRows[i]);

                    //Renumber
                    for (int i = 0; i < selectedDataGridView.Rows.Count; i++)
                        selectedDataGridView.Rows[i].Cells[0].Value = i + 1;
                }
            }
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            System.Data.DataTable myTable = new DataTable();
            myTable.Columns.Add(new DataColumn("No."));
            myTable.Columns.Add(new DataColumn("BhajanId"));
            myTable.Columns.Add(new DataColumn("BhajanLeaderId"));
            myTable.Columns.Add(new DataColumn("Title"));
            myTable.Columns.Add(new DataColumn("Scale"));
            myTable.Columns.Add(new DataColumn("Bhajan Leader"));

            if (selectedDataGridView.Rows.Count > 0)
            {
                object[] items = new object[6];

                for (int i = 0; i < selectedDataGridView.Rows.Count; i++)
                {
                    items[0] = selectedDataGridView.Rows[i].Cells[0].Value;
                    items[1] = selectedDataGridView.Rows[i].Cells[6].Value;
                    items[2] = selectedDataGridView.Rows[i].Cells[9].Value;
                    items[3] = selectedDataGridView.Rows[i].Cells[1].Value;
                    items[4] = selectedDataGridView.Rows[i].Cells[2].Value;
                    items[5] = selectedDataGridView.Rows[i].Cells[3].Value;

                    myTable.Rows.Add(items);
                }

                string value = Csv.CsvWriter.WriteToString(myTable, true, true);

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.DefaultExt = "csv";
                sfd.Filter = "Comma Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.OverwritePrompt = true;
                sfd.Title = "Save Bhajans Session List";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream file = new FileStream(sfd.FileName, FileMode.Create);
                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                    file.Write(encoding.GetBytes(value), 0, value.Length);
                    file.Close();
                }

                Directory.SetCurrentDirectory(currentWorkingDirectory);
            }
        }

        private void loadListButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "csv";
            ofd.Filter = "Comma Separated Values (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.CheckFileExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(ofd.FileName, FileMode.Open);

                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                string value = "";
                byte[] bytes = new byte[1024];
                while (file.Read(bytes, 0, 1024) > 0)
                    value += encoding.GetString(bytes);
                file.Close();

                Directory.SetCurrentDirectory(currentWorkingDirectory);

                DataTable myTable = Csv.CsvParser.Parse(value, true);

                if (selectedDataGridView.Rows.Count > 0 && myTable.Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Do you want to Replace (Yes) or Append (No) to the existing list?", "Warning!", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        int total = selectedDataGridView.Rows.Count;
                        for (int i = 0; i < total; i++)
                            selectedDataGridView.Rows.Remove(selectedDataGridView.Rows[0]);
                    }
                }

                for (int i = 0; i < myTable.Rows.Count; i++)
                {
                    object[] items = myTable.Rows[i].ItemArray;
                    int bhajanId = 0;

                    try
                    {
                        bhajanId = Int32.Parse(items[1].ToString());
                    }
                    catch (Exception exception)
                    {
                        break;
                    }

                    int bhajanLeaderId = Int32.Parse(items[2].ToString());

                    sai_bhajans5DataSet.BhajansDataTable bdt = this.bhajansTableAdapter.GetDataByBhajanID(bhajanId);
                    string name = "";
                    string scale = "";
                    if (bhajanLeaderId > 0)
                        name = this.bhajanLeadersTableAdapter.GetNameByID(bhajanLeaderId).ToString();
                    if (bhajanId > 0 && bhajanLeaderId > 0)
                        scale = this.bhajanScalesTableAdapter.GetScale(bhajanId, bhajanLeaderId).ToString();

                    selectedDataGridView.Rows.Add();
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0].Value = selectedDataGridView.Rows.Count;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[1].Value = bdt.Rows[0].ItemArray[1];
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[2].Value = scale;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[3].Value = name;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[4].Value = bdt.Rows[0].ItemArray[4];
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[5].Value = bdt.Rows[0].ItemArray[5];
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[6].Value = bhajanId;
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[7].Value = bdt.Rows[0].ItemArray[2];
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[8].Value = bdt.Rows[0].ItemArray[3];
                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[9].Value = bhajanLeaderId;

                    // Remove prior selections
                    for (int k = 0; k < selectedDataGridView.SelectedRows.Count; k++)
                        selectedDataGridView.SelectedRows[k].Selected = false;

                    selectedDataGridView.Rows[selectedDataGridView.Rows.GetLastRow(DataGridViewElementStates.None)].Selected = true;

                    if (this.selectedDataGridView.SelectedRows.Count == 1 && this.selectedDataGridView.SelectedRows[0].Cells[7].Value != null)
                        this.bhajanTextBox2.Text = this.selectedDataGridView.SelectedRows[0].Cells[7].Value.ToString();
                    else
                        this.bhajanTextBox2.Text = "";
                }
            }
        }

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            if (selectedDataGridView.Rows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete all selected Bhajans?", "Stop!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    selectedDataGridView.Rows.Clear();
            }
        }

        private void bhajansDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateBhajanBodyAndTranslation();
        }

        private void bhajansDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (updatingView == false)
                updateBhajanBodyAndTranslation();
        }

        private void bhajansDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addButton_Click(null, null);
                e.Handled = true;
            }
        }

        private void mover(int index1, int index2)
        {
            selectedDataGridView.Rows.Insert(index2, 1);
            selectedDataGridView.Rows[index2].Cells[0].Value = selectedDataGridView.Rows[index1].Cells[0].Value;
            selectedDataGridView.Rows[index2].Cells[1].Value = selectedDataGridView.Rows[index1].Cells[1].Value;
            selectedDataGridView.Rows[index2].Cells[2].Value = selectedDataGridView.Rows[index1].Cells[2].Value;
            selectedDataGridView.Rows[index2].Cells[3].Value = selectedDataGridView.Rows[index1].Cells[3].Value;
            selectedDataGridView.Rows[index2].Cells[4].Value = selectedDataGridView.Rows[index1].Cells[4].Value;
            selectedDataGridView.Rows[index2].Cells[5].Value = selectedDataGridView.Rows[index1].Cells[5].Value;
            selectedDataGridView.Rows[index2].Cells[6].Value = selectedDataGridView.Rows[index1].Cells[6].Value;
            selectedDataGridView.Rows[index2].Cells[7].Value = selectedDataGridView.Rows[index1].Cells[7].Value;
            selectedDataGridView.Rows[index2].Cells[8].Value = selectedDataGridView.Rows[index1].Cells[8].Value;
            selectedDataGridView.Rows[index2].Cells[9].Value = selectedDataGridView.Rows[index1].Cells[9].Value;
            selectedDataGridView.Rows[index2].Selected = true;
            selectedDataGridView.Rows[index1].Selected = false;
            selectedDataGridView.Rows.RemoveAt(index1);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if (selectedDataGridView.SelectedRows.Count > 0)
            {
                int count = selectedDataGridView.SelectedRows.Count;
                int[] selections = new int[count];

                for (int i = 0; i < count; i++)
                    selections[i] = selectedDataGridView.SelectedRows[i].Index;

                Array.Sort(selections);

                for (int i = 0; i < count; i++)
                    if (selections[i] > 0)
                        mover(selections[i] + 1, selections[i] - 1);

                for (int i = 0; i < selectedDataGridView.Rows.Count; i++)
                    selectedDataGridView.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if (selectedDataGridView.SelectedRows.Count > 0)
            {
                int count = selectedDataGridView.SelectedRows.Count;
                int[] selections = new int[count];

                for (int i = 0; i < count; i++)
                    selections[i] = selectedDataGridView.SelectedRows[i].Index;

                Array.Sort(selections);

                for (int i = 0; i < count; i++)
                    if (selections[i] < selectedDataGridView.Rows.Count - 1)
                        mover(selections[i], selections[i] + 2);

                for (int i = 0; i < selectedDataGridView.Rows.Count; i++)
                    selectedDataGridView.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void moveTopButton_Click(object sender, EventArgs e)
        {
            if (selectedDataGridView.SelectedRows.Count > 0)
            {
                int count = selectedDataGridView.SelectedRows.Count;
                int[] selections = new int[count];

                for (int i = 0; i < count; i++)
                    selections[i] = selectedDataGridView.SelectedRows[i].Index;

                Array.Sort(selections);

                for (int i = 0; i < count; i++)
                    if (selections[i] > 0)
                        mover(selections[i] + 1, i);

                for (int i = 0; i < selectedDataGridView.Rows.Count; i++)
                    selectedDataGridView.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void moveBottomButton_Click(object sender, EventArgs e)
        {
            if (selectedDataGridView.SelectedRows.Count > 0)
            {
                int count = selectedDataGridView.SelectedRows.Count;
                int[] selections = new int[count];

                for (int i = 0; i < count; i++)
                    selections[i] = selectedDataGridView.SelectedRows[i].Index;

                Array.Sort(selections);

                for (int i = 0; i < count; i++)
                    if (selections[i] < selectedDataGridView.Rows.Count - 1)
                        mover(selections[i], selectedDataGridView.Rows.Count);

                for (int i = 0; i < selectedDataGridView.Rows.Count; i++)
                    selectedDataGridView.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void selectedDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            updateSelectedBhajanBodyAndTranslation();
        }

        private void selectedDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            updateSelectedBhajanBodyAndTranslation();
        }

        private void bhajansDataGridView_DoubleClick(object sender, EventArgs e)
        {
            changeButton_Click(null, null);
        }

        private void pptButton_Click(object sender, EventArgs e)
        {
            PowerPoint.Presentations objPresSet;
            PowerPoint.Slides objSlides;
            PowerPoint._Slide objSlide;
            PowerPoint.Shapes objShapes;
            PowerPoint.Shape objShape;

            PowerPoint.SlideShowSettings objSSS;

            int newSlide = 1;
            bool found = false;

            //Search for objApp and Presentation
            if (objApp == null)
            {
                objApp = new PowerPoint.Application();
                objPresSet = objApp.Presentations;

                for (int i = 1; i <= objPresSet.Count; i++)
                {
                    objPres = objPresSet[i];
                    for (int j = 1; j <= objPres.Tags.Count; j++)
                    {
                        if (objPres.Tags["Sai Bhajans"].Equals("Single Slide"))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (!found)
                    objApp = null;
            }

            if (objApp != null)
            {
                objPresSet = objApp.Presentations;
                for (int i = 1; i <= objPresSet.Count; i++)
                {
                    if (objPresSet[i] == objPres)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    objSlide = objPres.Slides[1];
                }
                else
                {
                    objPresSet = objApp.Presentations;
                    try
                    {
                        objPres = objPresSet.Open(templateLocation, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
                    }
                    catch (COMException come)
                    {
                        try
                        {
                            objPres = objPresSet.Open(Application.StartupPath + "\\" + emptyTemplateLocation, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
                        }
                        catch (COMException come2)
                        {
                            objApp = new PowerPoint.Application();
                            objApp.WindowState = Microsoft.Office.Interop.PowerPoint.PpWindowState.ppWindowMinimized;
                            objApp.Visible = MsoTriState.msoTrue;
                            objPresSet = objApp.Presentations;
                            try
                            {
                                objPres = objPresSet.Open(templateLocation, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
                            }
                            catch (COMException come3)
                            {
                                objPres = objPresSet.Open(Application.StartupPath + "\\" + emptyTemplateLocation, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
                            }
                        }
                    }
                    objSlide = objPres.Slides.Add(newSlide, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutTitleOnly);
                    objSlides = objPres.Slides;
                }
            }
            else
            {
                objApp = new PowerPoint.Application();
                objApp.WindowState = Microsoft.Office.Interop.PowerPoint.PpWindowState.ppWindowMinimized;
                objApp.Visible = MsoTriState.msoTrue;
                objPresSet = objApp.Presentations;
                try
                {
                    objPres = objPresSet.Open(templateLocation, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
                }
                catch (COMException come)
                {
                    objPres = objPresSet.Open(Application.StartupPath + "\\" + emptyTemplateLocation, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
                }
                objSlide = objPres.Slides.Add(newSlide, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutTitleOnly);
                objSlides = objPres.Slides;
            }

            if (bhajansDataGridView.SelectedRows.Count > 0)
            {
                objShapes = objSlide.Shapes;

                for (int i = objShapes.Count; i >= 1; i--)
                    objShapes[i].Delete();

                if (bodyCharacteristics != null)
                {
                    objShape = objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 200);
                    if (bhajansDataGridView.SelectedRows[0].Cells[4].Value != null)
                        objShape.TextFrame.TextRange.Text = bhajansDataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    bodyCharacteristics.TransferCharacteristics(objShape);
                }

                if (translationCharacteristics != null)
                {
                    objShape = objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 200);
                    if (bhajansDataGridView.SelectedRows[0].Cells[5].Value != null)
                        objShape.TextFrame.TextRange.Text = bhajansDataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    translationCharacteristics.TransferCharacteristics(objShape);
                }
            }

            objShape = objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 200);

            objPres.Tags.Add("Sai Bhajans", "Single Slide");

            objSSS = objPres.SlideShowSettings;
            objSSS.StartingSlide = 1;
            objSSS.EndingSlide = 1;
            objSSS.Run();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            PowerPoint.Application objApp;
            PowerPoint.Presentations objPresSet;
            PowerPoint._Presentation objPres;
            PowerPoint.Slides objSlides;
            PowerPoint._Slide objSlide;
            PowerPoint._Slide objNextSlide;
            PowerPoint.Shapes objShapes;
            PowerPoint.Shape objShape;
            string nextSlideTitle = "";
            string nextSlideLeader = "";
            string nextSlideScale = "-";

            objApp = new PowerPoint.Application();
            objApp.WindowState = Microsoft.Office.Interop.PowerPoint.PpWindowState.ppWindowMinimized;
            objApp.Visible = MsoTriState.msoTrue;
            objPresSet = objApp.Presentations;
            try
            {
                objPres = objPresSet.Open(templateLocation, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            }
            catch (COMException come)
            {
                objPres = objPresSet.Open(Application.StartupPath + "\\" + templateLocation, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            }
            objSlides = objPres.Slides;

            int refSlide = referenceSlide;
            bool before = false;
            if (beforeAfter.Equals("Before"))
                before = true;
            int newSlide = 0;
            if (before)
                newSlide = refSlide;
            else
                newSlide = refSlide + 1;

            for (int i = selectedDataGridView.Rows.Count - 1; i >= 0; i--)
            {
                if (useReferenceSlide == true)
                {
                    objSlide = objSlides[refSlide];
                    objSlide.Duplicate();
                }
                else
                {
                    objSlide = objPres.Slides.Add(newSlide, Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutTitleOnly);
                }
            }

            for (int i = selectedDataGridView.Rows.Count - 1; i >= 0; i--)
            {
                objSlide = objSlides[newSlide + i];
                objShapes = objSlide.Shapes;

                if (objSlides.Count >= (newSlide + i + 1))
                    objNextSlide = objSlides[newSlide + i + 1];
                else
                    objNextSlide = null;

                if (useReferenceSlide == true)
                {
                    if (titleTextBoxIndex > 0)
                    {
                        objShape = objShapes[titleTextBoxIndex];
                        if (selectedDataGridView.Rows[i].Cells[1].Value != null)
                            objShape.TextFrame.TextRange.Text = selectedDataGridView.Rows[i].Cells[1].Value.ToString() + "\v";
                        objShape.TextFrame.WordWrap = MsoTriState.msoFalse;
                        objShape.TextFrame.HorizontalAnchor = MsoHorizontalAnchor.msoAnchorCenter;
                    }

                    if (bodyTextBoxIndex > 0)
                    {
                        objShape = objShapes[bodyTextBoxIndex];
                        if (selectedDataGridView.Rows[i].Cells[7].Value != null)
                            objShape.TextFrame.TextRange.Text = selectedDataGridView.Rows[i].Cells[7].Value.ToString();
                    }

                    if (translationTextBoxIndex > 0)
                    {
                        objShape = objShapes[translationTextBoxIndex];
                        if (selectedDataGridView.Rows[i].Cells[8].Value != null)
                            objShape.TextFrame.TextRange.Text = selectedDataGridView.Rows[i].Cells[8].Value.ToString();
                    }

                    if (bhajanNumberTextBoxIndex > 0)
                    {
                        objShape = objShapes[bhajanNumberTextBoxIndex];
                        objShape.TextFrame.TextRange.Text = (i + 1).ToString();
                    }

                    if (nextBhajanTextBoxIndex > 0)
                    {
                        objShape = objShapes[nextBhajanTextBoxIndex];

                        if (objNextSlide == null)
                            nextSlideTitle = "";
                        else if (objNextSlide.Shapes.HasTitle == MsoTriState.msoFalse)
                            nextSlideTitle = objNextSlide.Shapes[1].TextFrame.TextRange.Text;
                        else
                            nextSlideTitle = objNextSlide.Shapes.Title.TextFrame.TextRange.Text;

                        if (i == selectedDataGridView.Rows.Count - 1)
                        {
                            nextSlideScale = "-";
                            nextSlideLeader = "";
                        }
                        else
                        {
                            if (selectedDataGridView.Rows[i + 1].Cells[2].Value == null || selectedDataGridView.Rows[i + 1].Cells[2].Value.Equals(""))
                                nextSlideScale = "-";
                            else
                                nextSlideScale = (string) selectedDataGridView.Rows[i + 1].Cells[2].Value;

                            if (selectedDataGridView.Rows[i + 1].Cells[3].Value == null || selectedDataGridView.Rows[i + 1].Cells[3].Value.Equals(""))
                                nextSlideLeader = "";
                            else
                                nextSlideLeader = (string) selectedDataGridView.Rows[i + 1].Cells[3].Value;
                        }

                        if (i == selectedDataGridView.Rows.Count - 1)
                            objShape.TextFrame.TextRange.Text = "Next: " + nextSlideTitle;
                        else
                            objShape.TextFrame.TextRange.Text = nextBhajanFormat.Replace("%scale%", nextSlideScale).Replace("%leader%", nextSlideLeader).Replace("%title%", nextSlideTitle);
                        objShape.TextFrame.WordWrap = MsoTriState.msoFalse;
                    }
                }
                else
                {
                    if (titleCharacteristics != null)
                    {
                        objShape = objSlide.Shapes.Title;
                        if (selectedDataGridView.Rows[i].Cells[1].Value != null)
                            objShape.TextFrame.TextRange.Text = selectedDataGridView.Rows[i].Cells[1].Value.ToString() + "\v";
                        objShape.TextFrame.WordWrap = MsoTriState.msoFalse;
                        objShape.TextFrame.HorizontalAnchor = MsoHorizontalAnchor.msoAnchorCenter;
                        titleCharacteristics.TransferCharacteristics(objShape);
                    }

                    if (bodyCharacteristics != null)
                    {
                        objShape = objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 200);
                        if (selectedDataGridView.Rows[i].Cells[7].Value != null)
                            objShape.TextFrame.TextRange.Text = selectedDataGridView.Rows[i].Cells[7].Value.ToString();
                        bodyCharacteristics.TransferCharacteristics(objShape);
                    }

                    if (translationCharacteristics != null)
                    {
                        objShape = objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 200);
                        if (selectedDataGridView.Rows[i].Cells[8].Value != null)
                            objShape.TextFrame.TextRange.Text = selectedDataGridView.Rows[i].Cells[8].Value.ToString();
                        translationCharacteristics.TransferCharacteristics(objShape);
                    }

                    if (bhajanNumberCharacteristics != null)
                    {
                        objShape = objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 200);
                        objShape.TextFrame.TextRange.Text = (i + 1).ToString();
                        bhajanNumberCharacteristics.TransferCharacteristics(objShape);
                    }

                    if (nextBhajanCharacteristics != null)
                    {
                        objShape = objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 200);
                        if (objNextSlide == null)
                            nextSlideTitle = "";
                        else if (objNextSlide.Shapes.HasTitle == MsoTriState.msoFalse)
                            nextSlideTitle = objNextSlide.Shapes[1].TextFrame.TextRange.Text;
                        else
                            nextSlideTitle = objNextSlide.Shapes.Title.TextFrame.TextRange.Text;

                        if (i == selectedDataGridView.Rows.Count - 1)
                        {
                            nextSlideScale = "-";
                            nextSlideLeader = "";
                        }
                        else
                        {
                            if (selectedDataGridView.Rows[i + 1].Cells[2].Value == null || selectedDataGridView.Rows[i + 1].Cells[2].Value.Equals(""))
                                nextSlideScale = "-";
                            else
                                nextSlideScale = (string) selectedDataGridView.Rows[i + 1].Cells[2].Value;

                            if (selectedDataGridView.Rows[i + 1].Cells[3].Value == null || selectedDataGridView.Rows[i + 1].Cells[3].Value.Equals(""))
                                nextSlideLeader = "";
                            else
                                nextSlideLeader = (string) selectedDataGridView.Rows[i + 1].Cells[3].Value;
                        }

                        if (i == selectedDataGridView.Rows.Count - 1)
                            objShape.TextFrame.TextRange.Text = "Next: " + nextSlideTitle;
                        else
                            objShape.TextFrame.TextRange.Text = nextBhajanFormat.Replace("%scale%", nextSlideScale).Replace("%leader%", nextSlideLeader).Replace("%title%", nextSlideTitle);
                        objShape.TextFrame.WordWrap = MsoTriState.msoFalse;
                        nextBhajanCharacteristics.TransferCharacteristics(objShape);
                    }
                }
            }

            //Cover the previous slide
            if (newSlide > 1)
            {
                objSlide = objSlides[newSlide - 1];
                objShapes = objSlide.Shapes;
                objNextSlide = objSlides[newSlide];

                if (useReferenceSlide == true)
                {
                    if (nextBhajanTextBoxIndex > 0)
                    {
                        objShape = objShapes[nextBhajanTextBoxIndex];
                        if (objNextSlide == null)
                            nextSlideTitle = "";
                        else if (objNextSlide.Shapes.HasTitle == MsoTriState.msoFalse)
                            nextSlideTitle = objNextSlide.Shapes[1].TextFrame.TextRange.Text;
                        else
                            nextSlideTitle = objNextSlide.Shapes.Title.TextFrame.TextRange.Text;

                        if (selectedDataGridView.Rows.Count > 0)
                        {
                            if (selectedDataGridView.Rows[0].Cells[2].Value == null || selectedDataGridView.Rows[0].Cells[2].Value.Equals(""))
                                nextSlideScale = "-";
                            else
                                nextSlideScale = (string) selectedDataGridView.Rows[0].Cells[2].Value;

                            if (selectedDataGridView.Rows[0].Cells[3].Value == null || selectedDataGridView.Rows[0].Cells[3].Value.Equals(""))
                                nextSlideLeader = "";
                            else
                                nextSlideLeader = (string) selectedDataGridView.Rows[0].Cells[3].Value;
                        }

                        if (selectedDataGridView.Rows.Count == 0)
                            objShape.TextFrame.TextRange.Text = "Next: " + nextSlideTitle;
                        else
                            objShape.TextFrame.TextRange.Text = nextBhajanFormat.Replace("%scale%", nextSlideScale).Replace("%leader%", nextSlideLeader).Replace("%title%", nextSlideTitle);
                        objShape.TextFrame.WordWrap = MsoTriState.msoFalse;
                    }
                }
                else
                {
                    if (nextBhajanCharacteristics != null)
                    {
                        objShape = objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, 100, 100, 500, 200);
                        if (objNextSlide == null)
                            nextSlideTitle = "";
                        else if (objNextSlide.Shapes.HasTitle == MsoTriState.msoFalse)
                            nextSlideTitle = objNextSlide.Shapes[1].TextFrame.TextRange.Text;
                        else
                            nextSlideTitle = objNextSlide.Shapes.Title.TextFrame.TextRange.Text;

                        if (selectedDataGridView.Rows.Count > 0)
                        {
                            if (selectedDataGridView.Rows[0].Cells[2].Value == null || selectedDataGridView.Rows[0].Cells[2].Value.Equals(""))
                                nextSlideScale = "-";
                            else
                                nextSlideScale = (string) selectedDataGridView.Rows[0].Cells[2].Value;

                            if (selectedDataGridView.Rows[0].Cells[3].Value == null || selectedDataGridView.Rows[0].Cells[3].Value.Equals(""))
                                nextSlideLeader = "";
                            else
                                nextSlideLeader = (string) selectedDataGridView.Rows[0].Cells[3].Value;
                        }

                        if (selectedDataGridView.Rows.Count == 0)
                            objShape.TextFrame.TextRange.Text = "Next: " + nextSlideTitle;
                        else
                            objShape.TextFrame.TextRange.Text = nextBhajanFormat.Replace("%scale%", nextSlideScale).Replace("%leader%", nextSlideLeader).Replace("%title%", nextSlideTitle);
                        objShape.TextFrame.WordWrap = MsoTriState.msoFalse;
                        nextBhajanCharacteristics.TransferCharacteristics(objShape);
                    }
                }
            }

            try
            {
                objPres.SaveAs(outputFolder + "\\Bhajans_" + DateTime.Now.ToString("yyyyMMdd") + ".ppt", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPresentation, MsoTriState.msoTrue);
            }
            catch (COMException come)
            {
                objPres.SaveAs(Application.StartupPath + "\\" + outputFolder + "\\Bhajans_" + DateTime.Now.ToString("yyyyMMdd") + ".ppt", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPresentation, MsoTriState.msoTrue);
            }

            objApp.WindowState = Microsoft.Office.Interop.PowerPoint.PpWindowState.ppWindowNormal;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            bhajanId = "";

            BhajanForm bform = new BhajanForm();
            bform.Location = new Point(this.Location.X + 100, this.Location.Y + 100);
            bform.ShowDialog();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            bhajanId = bhajansDataGridView.SelectedRows[0].Cells[0].Value.ToString();

            BhajanForm bform = new BhajanForm();
            bform.Location = new Point(this.Location.X + 100, this.Location.Y + 100);
            bform.ShowDialog();
        }

        public static void updateBhajansList(int bhajanId)
        {
            int index = theBhajansForm.bhajansDataGridView.FirstDisplayedScrollingRowIndex;
            int selectedIndex = -1;
            if (index >= 0)
                selectedIndex = theBhajansForm.bhajansDataGridView.SelectedRows[0].Index;

            theBhajansForm.filterBhajans();

            if (index >= 0 && theBhajansForm.bhajansDataGridView.Rows.Count > 0)
            {
                if (index >= theBhajansForm.bhajansDataGridView.Rows.Count)
                    index = theBhajansForm.bhajansDataGridView.Rows.Count - 1;
                if (selectedIndex >= theBhajansForm.bhajansDataGridView.Rows.Count)
                    selectedIndex = theBhajansForm.bhajansDataGridView.Rows.Count - 1;
                theBhajansForm.bhajansDataGridView.FirstDisplayedScrollingRowIndex = index;
                theBhajansForm.bhajansDataGridView.Rows[selectedIndex].Selected = true;

                theBhajansForm.updateBhajanBodyAndTranslation();
            }

            if (bhajanId > 0)
            {
                for (int i = 0; i < theBhajansForm.bhajansDataGridView.Rows.Count; i++)
                    if (Int32.Parse(theBhajansForm.bhajansDataGridView.Rows[i].Cells[0].Value.ToString()) == bhajanId)
                    {
                        theBhajansForm.bhajansDataGridView.Rows[i].Selected = true;
                        theBhajansForm.bhajansDataGridView.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
        }

        private void filterBhajans()
        {
            if (startsWithCheckBox.Checked == true && titleOnlyCheckBox.Checked == true)
                this.bhajansTableAdapter.FillBySearchText4(this.sai_bhajans5DataSet.Bhajans, this.searchTextBox.Text);
            else if (startsWithCheckBox.Checked == true)
                this.bhajansTableAdapter.FillBySearchText2(this.sai_bhajans5DataSet.Bhajans, this.searchTextBox.Text, this.searchTextBox.Text, this.searchTextBox.Text, this.searchTextBox.Text, this.searchTextBox.Text);
            else if (titleOnlyCheckBox.Checked == true)
                this.bhajansTableAdapter.FillBySearchText3(this.sai_bhajans5DataSet.Bhajans, this.searchTextBox.Text);
            else
                this.bhajansTableAdapter.FillBySearchText1(this.sai_bhajans5DataSet.Bhajans, this.searchTextBox.Text, this.searchTextBox.Text, this.searchTextBox.Text, this.searchTextBox.Text, this.searchTextBox.Text);

            updateBhajanBodyAndTranslation();
        }

        private void updateBhajanBodyAndTranslation()
        {
            if (this.bhajansDataGridView.Rows.Count > 0)
            {
                this.bhajanTextBox1.Text = this.bhajansDataGridView.SelectedRows[0].Cells[4].Value.ToString();
                this.translationTextBox1.Text = this.bhajansDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            }
            else
            {
                this.bhajanTextBox1.Text = "";
                this.translationTextBox1.Text = "";
            }

            //Update scales for all Bhajan leaders for this bhajan
            filterBhajanLeaders();
        }

        private void updateSelectedBhajanBodyAndTranslation()
        {
            if (this.selectedDataGridView.SelectedRows.Count == 1 && this.selectedDataGridView.SelectedRows[0].Cells[7].Value != null)
            {
                this.bhajanTextBox2.Text = this.selectedDataGridView.SelectedRows[0].Cells[7].Value.ToString();
                if (this.selectedDataGridView.SelectedRows[0].Cells[8].Value != null)
                    this.translationTextBox2.Text = this.selectedDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            }
            else
            {
                this.bhajanTextBox2.Text = "";
                this.translationTextBox2.Text = "";
            }
        }

        private void bhajanLeadersDataGridView_DoubleClick(object sender, EventArgs e)
        {
            scaleButton_Click(null, null);
        }

        private void scaleButton_Click(object sender, EventArgs e)
        {
            if (this.bhajansDataGridView.SelectedRows.Count > 0)
            {
                BhajansForm.bhajanId = this.bhajansDataGridView.SelectedRows[0].Cells[0].Value.ToString();

                ScaleForm sform = new ScaleForm();
                sform.Location = new Point(this.Location.X + 250, this.Location.Y + 400);
                if (bhajanLeadersDataGridView.SelectedRows.Count > 0)
                {
                    bhajanLeader = bhajanLeadersDataGridView.SelectedRows[0].Cells[1].Value.ToString();
                    if (bhajanLeadersDataGridView.SelectedRows[0].Cells[2].Value != null)
                        bhajanScale = bhajanLeadersDataGridView.SelectedRows[0].Cells[2].Value.ToString();
                }
                else
                {
                    bhajanLeader = "";
                    bhajanScale = "";
                }
                sform.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Bhajan selected to set the scale for", "Error");
            }
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            ListForm listForm = new ListForm();
            if (this.bhajanLeadersDataGridView.SelectedRows.Count > 0)
            {
                listForm.bhajanLeaderId = Int32.Parse(this.bhajanLeadersDataGridView.SelectedRows[0].Cells[0].Value.ToString());
                listForm.bhajanLeader = this.bhajanLeadersDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            }
            listForm.Location = new Point(this.Location.X + 250, this.Location.Y + 250);
            listForm.ShowDialog();
        }

        public static void updateBhajanLeadersList(int bhajanLeaderId)
        {
            int index = theBhajansForm.bhajanLeadersDataGridView.FirstDisplayedScrollingRowIndex;
            int selectedIndex = -1;
            if (theBhajansForm.bhajanLeadersDataGridView.SelectedRows.Count > 0)
                selectedIndex = theBhajansForm.bhajanLeadersDataGridView.SelectedRows[0].Index;

            theBhajansForm.filterBhajanLeaders();

            if (index < 0)
                index = 0;

            if (theBhajansForm.bhajanLeadersDataGridView.Rows.Count > 0)
            {
                theBhajansForm.bhajanLeadersDataGridView.FirstDisplayedScrollingRowIndex = index;
                if (selectedIndex >= 0 && theBhajansForm.bhajanLeadersDataGridView.Rows.Count > selectedIndex)
                    theBhajansForm.bhajanLeadersDataGridView.Rows[selectedIndex].Selected = true;
                else
                    theBhajansForm.bhajanLeadersDataGridView.Rows[theBhajansForm.bhajanLeadersDataGridView.Rows.Count - 1].Selected = true;
            }

            if (bhajanLeaderId > 0)
            {
                for (int i = 0; i < theBhajansForm.bhajanLeadersDataGridView.Rows.Count; i++)
                    if (Int32.Parse(theBhajansForm.bhajanLeadersDataGridView.Rows[i].Cells[0].Value.ToString()) == bhajanLeaderId)
                    {
                        theBhajansForm.bhajanLeadersDataGridView.Rows[i].Selected = true;
                        theBhajansForm.bhajanLeadersDataGridView.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
            }
        }

        public static void updateSelections(int bhajanId, int bhajanLeaderId, object scale)
        {
            int listBhajanId = 0;
            int listBhajanLeaderId = 0;

            if (theBhajansForm.selectedDataGridView.Rows.Count > 0)
            {
                for (int i = 0; i < theBhajansForm.selectedDataGridView.Rows.Count; i++)
                {
                    if (theBhajansForm.selectedDataGridView.Rows[i].Cells[6].Value == null)
                        listBhajanId = 0;
                    else
                        listBhajanId = Int32.Parse(theBhajansForm.selectedDataGridView.Rows[i].Cells[6].Value.ToString());

                    if (theBhajansForm.selectedDataGridView.Rows[i].Cells[9].Value == null)
                        listBhajanLeaderId = 0;
                    else
                        listBhajanLeaderId = Int32.Parse(theBhajansForm.selectedDataGridView.Rows[i].Cells[9].Value.ToString());

                    if (bhajanId == listBhajanId && bhajanLeaderId == listBhajanLeaderId)
                        theBhajansForm.selectedDataGridView.Rows[i].Cells[2].Value = scale;
                }
            }
        }

        private void bhajanLeadersTextBox_TextChanged(object sender, EventArgs e)
        {
            filterBhajanLeaders();
        }

        private void filterBhajanLeaders()
        {
            if (this.bhajansDataGridView.SelectedRows.Count > 0)
                BhajansForm.bhajanId = this.bhajansDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            else
                BhajansForm.bhajanId = "0";

            if (this.hideEmptyScalesCheckBox.Checked == true)
                this.bhajanScalesQueryTableAdapter.Fill2(this.sai_bhajans5DataSet.BhajanScalesQuery, Int32.Parse(BhajansForm.bhajanId), this.bhajanLeadersTextBox.Text);
            else
                this.bhajanScalesQueryTableAdapter.Fill(this.sai_bhajans5DataSet.BhajanScalesQuery, Int32.Parse(BhajansForm.bhajanId), this.bhajanLeadersTextBox.Text);
        }

        private void clearButton2_Click(object sender, EventArgs e)
        {
            this.bhajanLeadersTextBox.Text = "";
        }

        private void bhajanLeadersDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                addButton_Click(null, null);
            }
        }

        private void bhajanLeadersTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            const int WM_KEYDOWN = 0x100;
            const int VK_DOWN = 0x28;

            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                bhajanLeadersDataGridView.Focus();
                PostMessage(bhajanLeadersDataGridView.Handle, WM_KEYDOWN, VK_DOWN, 0);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                addButton_Click(null, null);
            }
        }

        private void hideEmptyScalesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            filterBhajanLeaders();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}