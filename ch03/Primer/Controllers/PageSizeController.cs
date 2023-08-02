using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Primer.Controllers
{
    public class PageSizeController : Controller
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