using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing;

namespace WebScraper
{
    public partial class Form1 : Form
    {
        string data = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                htmlTxt.Text = "";
                HttpWebRequest.DefaultWebProxy = new System.Net.WebProxy();
                HttpWebRequest apireq = (HttpWebRequest)WebRequest.Create(urlTxt.Text);
                apireq.Timeout = 200 * 1000;
                HttpWebResponse apiresp = (HttpWebResponse)apireq.GetResponse();
                Stream resStream = apiresp.GetResponseStream();
                StreamReader read = new StreamReader(resStream);
                data = read.ReadToEnd();
                htmlTxt.Text = data;
                this.Size = new Size(687, 736);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error.", "Web Scraper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrlTxt_TextChanged(object sender, EventArgs e)
        {
            this.Size = new Size(687, 159);
        }

        private void UrlTxt_Click(object sender, EventArgs e)
        {
            this.Size = new Size(687, 159);
        }
    }
}
