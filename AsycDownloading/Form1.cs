using System.ComponentModel;
using System.Net;
namespace AsycDownloading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnDownload.Enabled = false;
            progressBar.Value = 0;
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.DownloadFileAsync(new Uri(txtBoxAdress.Text),txtBoxFile.Text);
        }

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error == null)
            {
                MessageBox.Show("Download successfully completed!");
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }

            ((WebClient)sender).Dispose();

        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void txtBoxAdress_TextChanged(object sender, EventArgs e)
        {
            txtBoxFile.Text = Path.GetFileName(txtBoxAdress.Text);  
        }
    }
}