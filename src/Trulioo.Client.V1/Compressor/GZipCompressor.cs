using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Trulioo.Client.V1.Compressor
{
    /// <summary>
    /// GZip Compressor.
    /// </summary>
    internal class GZipCompressor
    {
        #region Methods

        /// <summary>
        /// Compress the stream.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public Task Compress(Stream source, Stream destination)
        {
            var compressed = CreateCompressionStream(destination);
            return Pump(source, compressed).ContinueWith(task => compressed.Dispose());
        }

        /// <summary>
        /// Decompress the stream.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Task Decompress(Stream source, Stream destination)
        {
            var decompressed = CreateDecompressionStream(source);
            return Pump(decompressed, destination).ContinueWith(task => decompressed.Dispose());
        }

        #endregion

        #region Privates/internals

        /// <summary>
        /// Create compression stream.
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private static Stream CreateCompressionStream(Stream output)
        {
            return new GZipStream(output, CompressionMode.Compress, true);
        }

        /// <summary>
        /// Create decompression stream.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static Stream CreateDecompressionStream(Stream input)
        {
            return new GZipStream(input, CompressionMode.Decompress, true);
        }

        /// <summary>
        /// Pump the stream.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        private static Task Pump(Stream input, Stream output)
        {
            return input.CopyToAsync(output);
        }

        #endregion
    }
}
