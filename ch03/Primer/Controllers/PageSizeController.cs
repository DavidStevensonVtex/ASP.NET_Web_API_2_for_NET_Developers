using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Primer.Models;

namespace Primer.Controllers
{
	public class PageSizeController : ApiController, ICustomController
    {
        private static string TargetUrl = "http://apress.com";

        public async Task<long> GetPageSize(CancellationToken cToken)
		{
            WebClient wc = new WebClient();
            Stopwatch sw = Stopwatch.StartNew();
            byte[]apressData = await wc.DownloadDataTaskAsync(TargetUrl);
            Debug.WriteLine($"Elapsed: {sw.ElapsedMilliseconds}");
            return apressData.LongLength;
        }

		public Task PostUrl(string newUrl, CancellationToken cToken)
		{
            TargetUrl = newUrl;
            return Task.FromResult<object>(null);
		}
	}
}