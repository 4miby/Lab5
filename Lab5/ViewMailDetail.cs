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

namespace Lab5
{
    public partial class ViewMailDetail : Form
    {
        private MimeMessage email;
        public ViewMailDetail(MimeMessage email)
        {
            InitializeComponent();
            this.email = email;
            LoadHtmlAsync();
        }

        private void LoadHtmlAsync()
        {
            txtFrom.Text=email.From.ToString();
            txtTo.Text=email.To.ToString();
            txtSubject.Text = email.Subject;
            webView_mail.DocumentText = email.HtmlBody;

        }
    }
}
