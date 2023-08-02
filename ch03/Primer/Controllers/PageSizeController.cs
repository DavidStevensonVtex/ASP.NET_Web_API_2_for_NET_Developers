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
            List<long> results = new List<long>();

            for ( int i = 0; i < 10; i++ )
			{
                if (!cToken.IsCancellationRequested)
				{
                    Debug.WriteLine($"Making Request: {i}");
                    byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl);
                    results.Add(apressData.Length);
                }
                else
				{
                    Debug.WriteLine("Cancelled");
                    return 0;
				}
            }

            Debug.WriteLine($"Elapsed ms: {sw.ElapsedMilliseconds} milliseconds.");
            return (long)results.Average();
        }
    }
}