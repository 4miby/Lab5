using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Bai3NewMail : Form
    {
        public Bai3NewMail()
        {
            InitializeComponent(); 
        }
        string PASS;
        public Bai3NewMail(string user, string pass) : this()
        {
            txtFrom.Text = user;
            PASS = pass;
        }
        void SendMail()
        {
            SmtpClient smtpClient = new SmtpClient("127.0.0.1");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(txtFrom.Text.Trim(),PASS);
            MailAddress From = new MailAddress(txtFrom.Text.Trim());
            MailAddress To = new MailAddress(txtTo.Text.Trim());
            MailMessage message = new MailMessage(From, To);
            message.Subject = txtSubject.Text;
            message.Body = rtbBody.Text;
            message.IsBodyHtml = true;
            try
            {
                smtpClient.Send(message);
                MessageBox.Show("Send thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiểm tra lại các thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtFrom.Text == String.Empty)
            {
                MessageBox.Show("Yêu cầu điền mail người gửi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtTo.Text == String.Empty)
            {
                MessageBox.Show("Yêu cầu điền mail người nhận", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                SendMail();
        }
    }
}
