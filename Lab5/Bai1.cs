using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab5
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }
        void SendMail()
        {
            SmtpClient smtpClient = new SmtpClient("127.0.0.1");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(txtFrom.Text.Trim(), txtPassWord.Text.Trim());
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
                MessageBox.Show("Kiểm tra lại các thông tin","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtFrom.Text == String.Empty)
            {
                MessageBox.Show("Yêu cầu điền mail người gửi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtPassWord.Text == String.Empty)
            {
                MessageBox.Show("Yêu cầu nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Bai1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Lab5 lab5 = new Lab5();
            lab5.ShowDialog();
            this.Close();
        }
    }
}
