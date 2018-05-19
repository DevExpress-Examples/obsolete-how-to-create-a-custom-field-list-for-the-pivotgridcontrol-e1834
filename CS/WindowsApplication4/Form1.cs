using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraPivotGrid;

namespace WindowsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            dt.Columns.Add("Customer");
            dt.Columns.Add("Group");
            dt.Columns.Add("Amount", typeof(decimal));

            dt.Rows.Add(new object[] { "A", "Group1", 500 });
            dt.Rows.Add(new object[] { "B", "Group2", 200 });
            dt.Rows.Add(new object[] { "C", "Group3", 200 });
            dt.Rows.Add(new object[] { "B", "Group1", 700 });
            dt.Rows.Add(new object[] { "A", "Group2", 0 });
            dt.Rows.Add(new object[] { "C", "Group3", 100 });
            dt.Rows.Add(new object[] { "A", "Group1", 100 });
            dt.Rows.Add(new object[] { "B", "Group2", 400 });
            dt.Rows.Add(new object[] { "C", "Group3", 200 });

            pivotGridControl1.Fields.Add("Customer", PivotArea.FilterArea).Visible = false;
            pivotGridControl1.Fields.Add("Group", PivotArea.RowArea).Visible = false;
            PivotGridField f = pivotGridControl1.Fields.Add("Amount", PivotArea.DataArea);
            f.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum;

            pivotGridControl1.DataSource = dt;

        }

    }
}