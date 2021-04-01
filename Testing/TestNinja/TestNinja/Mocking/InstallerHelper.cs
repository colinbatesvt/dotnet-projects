using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IDownloader _downloader;

        public InstallerHelper(IDownloader downloader)
        {
            _downloader = downloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                string url = string.Format("http://example.com/{0}/{1}",
                          customerName,
                          installerName);

                _downloader.Download(url, _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }

    public interface IDownloader
    {
        void Download(string url, string destination);
    }

    public class WebDownloader
    {
        void Download(string url, string destination)
        {
            var client = new WebClient();

            client.DownloadFile(url, destination);
        }
    }
}