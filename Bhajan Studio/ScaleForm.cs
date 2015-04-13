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
    public partial class ScaleForm : Form
    {
        private string originalScale;

        public ScaleForm()
        {
            InitializeComponent();
        }

        private void ScaleForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.BhajanScales' table. You can move, or remove it, as needed.
            this.bhajanScalesTableAdapter.Fill(this.sai_bhajans5DataSet.BhajanScales);
            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.BhajanLeaders' table. You can move, or remove it, as needed.
            this.bhajanLeadersTableAdapter.Fill(this.sai_bhajans5DataSet.BhajanLeaders);
            // TODO: This line of code loads data into the 'sai_bhajans5DataSet.BhajanLeadersQuery' table. You can move, or remove it, as needed.
            this.bhajanLeadersQueryTableAdapter.Fill(this.sai_bhajans5DataSet.BhajanLeadersQuery);

            this.bhajanLeaderComboBox.Text = BhajansForm.bhajanLeader;
            this.scaleComboBox.Text = BhajansForm.bhajanScale;

            originalScale = this.scaleComboBox.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string bhajanLeader = this.bhajanLeaderComboBox.Text;
            int bhajanLeaderId = 0;
            int bhajanId = Int32.Parse(BhajansForm.bhajanId);

            if (bhajanLeader.Equals(""))
            {
                MessageBox.Show("Bhajan Leader is not entered", "Wait a minute!");
                this.bhajanLeaderComboBox.Focus();
                return;
            }
            else
            {
                bool found = false;
                for (int i = 0; i < this.bhajanLeaderComboBox.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)this.bhajanLeaderComboBox.Items[i]).Row.ItemArray[0].ToString().ToLower().Equals(bhajanLeader.ToLower()))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    this.bhajanLeadersTableAdapter.Insert(bhajanLeader);

                bhajanLeaderId = Int32.Parse(this.bhajanLeadersTableAdapter.GetIDByName(bhajanLeader).ToString());
                object rowId = this.bhajanScalesTableAdapter.GetID(bhajanId, bhajanLeaderId);

                if (rowId == null || rowId.Equals(""))
                {
                    if (!scaleComboBox.Text.Equals(""))
                        this.bhajanScalesTableAdapter.Insert(bhajanId, bhajanLeaderId, scaleComboBox.Text);
                }
                else
                {
                    if (scaleComboBox.Text.Equals(""))
                        this.bhajanScalesTableAdapter.DeleteByID(Int32.Parse(rowId.ToString()));
                    else
                        this.bhajanScalesTableAdapter.Update(bhajanId, bhajanLeaderId, scaleComboBox.Text,
                                                                Int32.Parse(rowId.ToString()), bhajanId, bhajanLeaderId, originalScale);
                }
            }

            this.Close();

            BhajansForm.updateBhajanLeadersList(bhajanLeaderId);
            BhajansForm.updateSelections(bhajanId, bhajanLeaderId, scaleComboBox.Text);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string bhajanLeader = this.bhajanLeaderComboBox.Text;
            int bhajanLeaderId = 0;
            int bhajanId = Int32.Parse(BhajansForm.bhajanId);

            if (bhajanLeader.Equals(""))
                this.Close();
            else
            {
                bool found = false;
                for (int i = 0; i < this.bhajanLeaderComboBox.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)this.bhajanLeaderComboBox.Items[i]).Row.ItemArray[0].ToString().ToLower().Equals(bhajanLeader.ToLower()))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    bhajanLeaderId = Int32.Parse(this.bhajanLeadersTableAdapter.GetIDByName(bhajanLeader).ToString());
                    object rowId = this.bhajanScalesTableAdapter.GetID(bhajanId, bhajanLeaderId);

                    if (rowId != null && !rowId.Equals(""))
                        this.bhajanScalesTableAdapter.DeleteByID(Int32.Parse(rowId.ToString()));
                }
            }

            this.Close();

            BhajansForm.updateBhajanLeadersList(bhajanLeaderId);
            BhajansForm.updateSelections(bhajanId, bhajanLeaderId, scaleComboBox.Text);
        }
    }
}
