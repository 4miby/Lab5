using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab5
{
    public partial class Bai3Menu : Form
    {
        public IMailFolder MailFolder;
        public string username;
        public string password;
        private List<MimeMessage> emails = new List<MimeMessage>();
        public Bai3Menu(IMailFolder MailForder, string username, string password)
        {
            this.username = username;   
            InitializeComponent();
            this.MailFolder = MailForder;
            this.password = password;   
            listView1.Columns.Add("Email", 255);
            listView1.Columns.Add("From", 255);
            listView1.Columns.Add("Thời gian", 250);
            listView1.View = View.Details;
        }

        private void Bai3Menu_Load(object sender, EventArgs e)
        { 
            txtUsername.Text = username;
            MailFolder.Open(FolderAccess.ReadOnly);
            txtRecent.Text=MailFolder.Recent.ToString();
            txtTotal.Text=MailFolder.Count.ToString();
            for (int i = 0; i < MailFolder.Count; i++)
            {
                var message = MailFolder.GetMessage(i);
                emails.Add(message);
            }
            for (int i=0;i<MailFolder.Count;i++)
            {
                var message = MailFolder.GetMessage(i);
                ListViewItem lvi = new ListViewItem(message.Subject);
                lvi.SubItems.Add(message.From.ToString());
                lvi.SubItems.Add(message.Date.ToString());
                lvi.Tag = message.MessageId;
                listView1.Items.Add(lvi);
            }
        }

        private void btnNewMail_Click(object sender, EventArgs e)
        {
            Bai3NewMail newMail = new Bai3NewMail(this.username, this.password);
            newMail.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int emailIndex = listView1.SelectedItems[0].Index;

                MimeMessage email = emails[emailIndex];

                ViewMailDetail detail = new ViewMailDetail(email);

                detail.ShowDialog();
            }
        }
    }
}
