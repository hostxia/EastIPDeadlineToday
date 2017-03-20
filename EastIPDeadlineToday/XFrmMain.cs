using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using EastIPDeadlineToday.DbUtility;

namespace EastIPDeadlineToday
{
    public partial class XFrmMain : DevExpress.XtraEditors.XtraForm
    {
        //private string _sSql = @"select v.caseno,v.agent,v.targetdate,v.tr,v.dor,m.title from ALERTVIEW v,ALERTMETA m where v.alerttype = m.typeid(+) and v.dor <= 0";
        private string _sSql = @"select v.caseno,m.title,v.targetdate,v.dor from ALERTVIEW v,ALERTMETA m where v.alerttype = m.typeid(+) and v.dor <= 0 order by v.dor asc";
        public XFrmMain()
        {
            InitializeComponent();
        }

        private void xsbSearch_Click(object sender, EventArgs e)
        {
            xgcResult.DataSource = DbHelperOra.Query(_sSql).Tables[0];
            xgvResult.BestFitColumns(true);
            xgvResult.Columns[0].Summary.Add(SummaryItemType.Count);
        }

        private void xgcResult_Load(object sender, EventArgs e)
        {
        }
    }
}
