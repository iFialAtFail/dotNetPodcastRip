using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dotNetPodcastRip
{
    class HttpWebClient
    {
        public List<HttpWebCall> calls;

        public HttpWebClient CallAll(List<HttpWebRequest> requests)
        {
            var list = requests.Select(r => r.Address.ToString()).ToList();
            return CallAll(list);
        }

        public HttpWebClient CallAll(List<String> requests)
        {
            calls = new List<HttpWebCall>();
            foreach (var request in requests)
            {
                var call = HttpWebCall.CreateCall(request, HttpMethods.GET);
                calls.Add(call);
            }
            return this;
        }

        public async Task<HttpWebClient> CallAllAsync(List<HttpWebRequest> requests)
        {
            var list = requests.Select(r => r.Address.ToString()).ToList();
            return await CallAllAsync(list).ConfigureAwait(false);
        }

        public async Task<HttpWebClient> CallAllAsync(List<String> requests)
        {
            calls = new List<HttpWebCall>();
            foreach (var request in requests)
            {
                var call = await HttpWebCall.CreateCallAsync(request, HttpMethods.GET).ConfigureAwait(false);
                calls.Add(call);
            }
            return this;
        }

        public HttpWebClient DownloadAll()
        {
            return DownloadAll(this.calls);
        }

        public HttpWebClient DownloadAll(List<HttpWebCall> calls)
        {
            foreach (var call in calls.Where(c => c.response.StatusCode == HttpStatusCode.OK))
            {

            }

            return this;
        }

        public async Task<HttpWebClient> DownloadAllAsync()
        {
            return await DownloadAllAsync(this.calls);
        }

        public async Task<HttpWebClient> DownloadAllAsync(List<HttpWebCall> calls)
        {
            foreach (var call in calls.Where(c => c.response.StatusCode == HttpStatusCode.OK))
            {
                //parse hrefs
                //foreach href,
                //verify file doesnt exist
                //download file
            }

            return this;
        }

        public HttpWebClient DownloadFile(String url)
        {
            return this;
        }

        public async Task<HttpWebClient> DownloadFileAsync(string url)
        {
            //download file async... record file statuses?
            return this;
        }
    }

    public class HttpWebCall
    {
        public string name; //name of request (could be file name, or website name, etc)
        public HttpWebRequest request;
        public HttpWebResponse response;
        public Exception exception = null;

        public static HttpWebCall CreateCall(string url, HttpMethods method)
        {
            var call = new HttpWebCall();
            call.request = (HttpWebRequest)WebRequest.Create(url);
            call.request.Method = method.ToString();

            try
            {
                var response = call.request.GetResponse();
                call.response = (HttpWebResponse)response;
            }
            catch (Exception ex)
            {
                call.exception = ex;
                return call;
            }

            return call;
        }

        public static async Task<HttpWebCall> CreateCallAsync(string url, HttpMethods method)
        {
            var call = new HttpWebCall();
            call.request = (HttpWebRequest)WebRequest.Create(url);
            call.request.Method = method.ToString();

            try
            {
                var response = await call.request.GetResponseAsync().ConfigureAwait(false);
                call.response = (HttpWebResponse)response;
            }
            catch (Exception ex)
            {
                call.exception = ex;
                return call;
            }

            return call;
        }
    }

    public enum HttpMethods
    {
        POST,
        GET,
        PUT,
        PATCH,
        DELETE
    }

    public enum FileExtensions
    {
        ALL,
        PDF,
        ZIP,
        JPG,
        PNG,
        GIF,
        JAR,
        TXT,
        JPEG,
        DOC,
        DOCX,
        PPT,
        PPTX,
        XLS,
        XLSX,
        MP3,
        WAV,
        MID,
        MIDI,
    }
}

