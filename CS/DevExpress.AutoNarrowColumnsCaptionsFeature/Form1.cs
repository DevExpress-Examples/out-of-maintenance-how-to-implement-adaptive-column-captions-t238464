using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevExpress.AutoNarrowColumnsCaptionsFeature {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {

        public Form1() {
            InitializeComponent();
            gridControl1.DataSource = CreateTable(4);
        }
        

        private DataTable CreateTable(int RowCount) {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Number of departament", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            for(int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i) });
            return tbl;
        }

        


    }
}
