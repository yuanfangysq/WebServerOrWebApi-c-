using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DLL
{
    public partial class XtraForm1 : XtraForm
    {

        /// <summary>
        /// 刷新数据的代理
        /// </summary>
        /// <returns></returns>
        public delegate bool MyDel();
        public MyDel Dgv { get; set; }

        public string A { get; set; }


        public XtraForm1()
        {
            InitializeComponent();

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (Dgv != null)
            {
                bool id = Dgv();
            }

        }
    }
}