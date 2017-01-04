using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace dotNetPodcastRip
{
    class Program
    {
        static void Main(string[] args)
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
            //File.WriteAllText(@"C:\Users\USER\Downloads\zzz.txt", html);
            //Console.WriteLine(html);

            XDocument xDoc = XDocument.Parse(html);

            var enclosureURLS = from enclosure in xDoc.Descendants("enclosure")
                                select enclosure.Attribute("url").Value;

            List<Uri> uriLinks = new List<Uri>();

            foreach (var item in enclosureURLS)
            {
                uriLinks.Add(new Uri(item, UriKind.Absolute));
                //Console.WriteLine(item);
            }
            for (int i = 0; i < 8; i++)
            {

                using (WebClient wc = new WebClient())
                {
                    string filename = System.IO.Path.GetFileName(uriLinks[i].LocalPath);
                    string path = @"C:\Users\USER\Documents\Podcast\";
                    if (File.Exists(path+filename))
                    {
                        Console.WriteLine("File {0} exists!", filename);
                        continue;
                    }
                    wc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadCompleteMessage);
                    wc.DownloadFileAsync(uriLinks[i], path + filename);
                    Console.WriteLine("{0} has started downloading.", filename);
                }
            }

            Console.ReadKey();
        }

        private static void DownloadCompleteMessage(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

            Console.WriteLine("Download Finished for {0}.", e.UserState);
        }
    }
}
