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
    public partial class ListForm : Form
    {
        public int bhajanLeaderId;
        public string bhajanLeader;

        public ListForm()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {
            if (bhajanLeaderId > 0)
            {
                this.allScalesQueryTableAdapter.Fill(this.sai_bhajans5DataSet.AllScalesQuery, bhajanLeaderId);
                this.Text = this.Text + " - " + bhajanLeader;
            }
            else
            {
                this.allScalesQueryTableAdapter.FillByAll(this.sai_bhajans5DataSet.AllScalesQuery);
            }
        }
    }
}
