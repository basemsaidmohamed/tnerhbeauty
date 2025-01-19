using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tnerhbeauty
{
    public partial class app_update : Form
    {
        public app_update()
        {
            InitializeComponent();
        }
        private async void login_Load(object sender, EventArgs e)
        {
            await update();
        }
        private async Task update()
        {
            try
            {
                if (File.Exists(@".\SetupTnerhBeauty.msi"))
                { File.Delete(@".\SetupTnerhBeauty.msi"); }
                if (File.Exists(@".\Setupapp.zip"))
                { File.Delete(@".\Setupapp.zip"); }
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    await Client.DownloadFileTaskAsync(new Uri("https://drive.usercontent.google.com/download?id=1Gq6m7PQd59eX7SEzExOyDFXwilfQOvLX&export=download&authuser=0&confirm=t&uuid=1d8f7107-32f6-4543-9a99-2fdbcba81c50&at=AIrpjvOJjfioIQ2_57wL7zJIcBxE:1736552156852"), @"Setupapp.zip");
                }
                string zipPath = @".\Setupapp.zip";
                string extractPath = @".\";
                ZipFile.ExtractToDirectory(zipPath, extractPath);

                Process process = new Process();
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = string.Format(@"/c msiexec.exe /i SetupTnerhBeauty.msi /qb && tnerhbeauty.exe");
                System.Windows.Forms.Application.Exit();
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Minimum = 0;
            double receive = double.Parse(e.BytesReceived.ToString());
            double total = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = receive / total * 100;
            lblStatus.Text = $"{string.Format("{0:0.##}", percentage)}%";
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());

            //progressBar1.Value = e.ProgressPercentage;
        }
    }
}
