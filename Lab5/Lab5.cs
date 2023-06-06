using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Lab5 : Form
    {
        public Lab5()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult res=MessageBox.Show("Bạn có thực sự muốn thoát","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }

        private void btnBai1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bai1 bai1 = new Bai1();
            bai1.ShowDialog();
            this.Close();   
        }

        private void btnBai2_Click(object sender, EventArgs e)
        {
            this.Hide();    
            Bai2 bai2 = new Bai2();
            bai2.ShowDialog();
            this.Close();
        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bai3 bai3 = new Bai3();
            bai3.ShowDialog();
            this.Close();
        }
    }
}
