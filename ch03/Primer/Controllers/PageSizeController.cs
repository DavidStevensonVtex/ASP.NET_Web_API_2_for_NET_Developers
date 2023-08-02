using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Primer.Controllers
{
	public class PageSizeController : ApiController
    {
        private static string TargetUrl = "http://apress.com";

        public async Task<long> GetPageSize()
		{
            WebClient wc = new WebClient();
            Stopwatch sw = Stopwatch.StartNew();
            byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
            Debug.WriteLine($"Elapsed ms: {sw.ElapsedMilliseconds} milliseconds.");
            return apressData.LongLength;
        }
    }
}