using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Trulioo.Client.V1.Compressor
{
    /// <summary>
    /// Handle HTTP GZip Decompression.
    /// </summary>
    /// <seealso cref="T: System.Net.Http.HttpClientHandler"/>
    internal class GZipDecompressionHandler : HttpClientHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.Content.Headers.ContentEncoding != null && response.Content.Headers.ContentEncoding.Any())
            {
                var encoding = response.Content.Headers.ContentEncoding.First();

                if (encoding.Equals("gzip", StringComparison.OrdinalIgnoreCase))
                {
                    response.Content = await DecompressContentAsync(response.Content, new GZipCompressor()).ConfigureAwait(false);
                }
            }
            return response;
        }

        /// <summary>
        /// Decompress content using <see cref="GZipCompressor"/> class.
        /// </summary>
        private static async Task<HttpContent> DecompressContentAsync(HttpContent compressedContent, GZipCompressor compressor)
        {
            using (compressedContent)
            {
                var decompressed = new MemoryStream();
                await GZipCompressor.Decompress(await compressedContent.ReadAsStreamAsync(), decompressed).ConfigureAwait(false);

                // set position back to 0 so it can be read again
                decompressed.Position = 0;

                var newContent = new StreamContent(decompressed);
                // copy content type so we know how to load correct formatter
                newContent.Headers.ContentType = compressedContent.Headers.ContentType;
                return newContent;
            }
        }
    }
}
