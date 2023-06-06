using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;

namespace Lab5
{
    public partial class Bai2 : Form
    {
        public Bai2()
        {
            InitializeComponent();
        }

        private void Bai2_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Email", 250);
            listView1.Columns.Add("From", 250);
            listView1.Columns.Add("Thời gian", 230);
            listView1.View = View.Details;

        }
        void ReadMail()
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("localhost", 993, true);
                    client.Authenticate(txtEmail.Text.Trim(), txtPassWord.Text.Trim());
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    txtTotal.Text = inbox.Count.ToString();
                    txtRecent.Text = inbox.Recent.ToString();
                    for (int i = 0; i < inbox.Count; i++)
                    {
                        var message = inbox.GetMessage(i);
                        ListViewItem item = listView1.Items.Add(message.Subject);
                        item.SubItems.Add(message.From.ToString());
                        item.SubItems.Add(message.Date.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại user và password","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtEmail.Text != string.Empty) && (txtPassWord.Text != string.Empty))
            {
                ReadMail();
            }
            else if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Điền user!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtPassWord.Text == string.Empty)
            {
                MessageBox.Show("Điền password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Bai2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Lab5 lab5 = new Lab5();
            lab5.ShowDialog();
            this.Close();
        }
    }
}
