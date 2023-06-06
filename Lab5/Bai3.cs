using MailKit;
using MailKit.Net.Imap;
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
    public partial class Bai3 : Form
    {
        public Bai3()
        {
            InitializeComponent();

        }

        private void btnDangNhap_Click(object sender, EventArgs ea)
        {
            if(txtPassWord.Text==String.Empty)
            {
                MessageBox.Show("Vui lòng điền mật khẩu","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if(txtUsername.Text==String.Empty)
            {
                MessageBox.Show("Vui lòng điền username","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                return;
            }
            else
            {
                try
                {
                    using(var client = new ImapClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        client.Connect("localhost", 993, true);
                        client.Authenticate(txtUsername.Text.Trim(), txtPassWord.Text.Trim());
                        IMailFolder inbox = client.Inbox;
                        this.Hide();
                        Bai3Menu menu = new Bai3Menu(inbox,txtUsername.Text,txtPassWord.Text);
                        menu.ShowDialog();
                        this.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kiểm tra lại username và mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void Bai3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Lab5 lab5 = new Lab5();
            lab5.ShowDialog();
            this.Close();
        }
    }
}
