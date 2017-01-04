using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace DNRPodcastRipForm
{
    public partial class Form1 : Form
    {
        //Get list of links
        List<Uri> uriLinks = new List<Uri>();
        List<string> filesFound = new List<string>();
        string path;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //Make sure we have correct path here.
            path = lblPathLocation.Text + "/";

            if (String.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("Please Select a download location");
                return;
            }

            for (int i = 0; i < 2; i++)
            {

                using (WebClient wc = new WebClient())
                {
                    string filename = Path.GetFileName(uriLinks[i].LocalPath);
                    if (File.Exists(path + filename))
                    {
                        //Console.WriteLine("File {0} exists!", filename);
                        continue;
                    }
                    wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleteMessage);
                    wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                    wc.DownloadFileAsync(uriLinks[i], path + filename);
                    //Console.WriteLine("{0} has started downloading.", filename);
                }
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            progressBarDownload.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        private void DownloadCompleteMessage(object sender, AsyncCompletedEventArgs e)
        {
            //MessageBox.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLinksFromWebsite();
            listBoxAllFilesAvailable.DataSource = uriLinks;
            setupFileListbox();
            setupLables();
        }

        private void setupLables()
        {
            lblFileCount.Text = "Files downloaded: " + filesFound.Count;
            lblFilesAvailableCount.Text = "Total files available: " + uriLinks.Count;
        }

        private void setupFileListbox()
        {
            if (path != null)
            {
                DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.mp3"); //Getting Text files
                filesFound.Clear();
                foreach (FileInfo file in Files)
                {
                    filesFound.Add(file.Name);
                }
                listBoxFileList.DataSource = filesFound;
            }
            
        }

        private void LoadLinksFromWebsite()
        {
            string url = "http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master";
            string html;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            //At this point all of the xml is good. Just need to parse it, then get a list of url's for the mp3 files.

            XDocument xDoc = XDocument.Parse(html);

            var enclosureURLS = from enclosure in xDoc.Descendants("enclosure")
                                select enclosure.Attribute("url").Value;

            uriLinks.Clear();
            foreach (var item in enclosureURLS)
            {
                uriLinks.Add(new Uri(item, UriKind.Absolute));
                //Console.WriteLine(item);
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    lblPathLocation.Text = folderDialog.SelectedPath;
                }
            }
        }
    }
}
