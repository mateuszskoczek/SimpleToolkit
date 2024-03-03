using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToolkit.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task DownloadAsync(this HttpClient client, string requestUri, Stream destination, CancellationToken cancellationToken = default, IProgress<double> progress = null)
        {
            using (HttpResponseMessage response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead))
            {
                long? contentLength = response.Content.Headers.ContentLength;

                using (Stream download = await response.Content.ReadAsStreamAsync(cancellationToken))
                {
                    if (progress == null || !contentLength.HasValue)
                    {
                        await download.CopyToAsync(destination);
                        return;
                    }

                    var relativeProgress = new Progress<long>(totalBytes => progress.Report((double)totalBytes * 100 / contentLength.Value));
                    await download.CopyToAsync(destination, 81920, relativeProgress, cancellationToken);
                    progress.Report(100);
                }
            }
        }
    }
}
