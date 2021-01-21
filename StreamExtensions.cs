using MySharedClipboard;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Extensions
{
	public static class StreamExtensions
	{
		/// <summary>
		/// Implementation of <see cref="Stream.CopyTo(System.IO.Stream)"/> with progress reporting
		/// </summary>
		/// <param name="fromStream"></param>
		/// <param name="destination"></param>
		/// <param name="bufferSize"></param>
		/// <param name="progressInfo"></param>
		internal static void CopyTo(this Stream fromStream, Stream destination, int bufferSize, CopyProgressInfo progressInfo)
		{
			var buffer = new byte[bufferSize];
			int count;
			while ((count = fromStream.Read(buffer, 0, buffer.Length)) != 0)
			{
				progressInfo.BytesTransfered += count;
				destination.Write(buffer, 0, count);
			}
		}






		/// <summary>
		/// Implementation of <see cref="Stream.CopyToAsync(System.IO.Stream)"/> with progress reporting
		/// </summary>
		/// <param name="fromStream"></param>
		/// <param name="destination"></param>
		/// <param name="bufferSize"></param>
		/// <param name="progressInfo"></param>
		internal static async Task CopyToAsync(this Stream fromStream, Stream destination, int bufferSize, CopyProgressInfo progressInfo)
		{
			var buffer = new byte[bufferSize];
			int count;
			while ((count = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
			{
				progressInfo.BytesTransfered += count;
				await destination.WriteAsync(buffer, 0, count);
			}

		}







		/// <summary>
		/// Implementation of <see cref="Stream.CopyToAsync(System.IO.Stream)"/> with progress reporting
		/// </summary>
		/// <param name="fromStream"></param>
		/// <param name="destination"></param>
		/// <param name="bufferSize"></param>
		/// <param name="progressInfo"></param>
		internal static async Task CopyToAsync(this Stream fromStream, Stream destination, int bufferSize, CopyProgressInfo progressInfo, CancellationToken cancellationToken)
		{
			var buffer = new byte[bufferSize];
			int count;
			while ((count = await fromStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) != 0)
			{
				progressInfo.BytesTransfered += count;
				await destination.WriteAsync(buffer, 0, count, cancellationToken);
			}
		}

	
		public class CopyProgressInfo
		{
			public long BytesTransfered { get; set; }
		}

    }
}