using System.Diagnostics;
using System.Net;
using System.Web.Http;

namespace Primer.Controllers
{
	public class PageSizeController : ApiController
    {
        private static string TargetUrl = "http://apress.com";

        public long GetPageSize()
		{
            WebClient wc = new WebClient();
            Stopwatch sw = Stopwatch.StartNew();
            byte[] apressData = wc.DownloadData(TargetUrl);
            Debug.WriteLine($"Elapsed ms: {sw.ElapsedMilliseconds} milliseconds.");
            return apressData.LongLength;
		}
    }
}