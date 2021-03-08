
using System.Threading;
using System.Threading.Tasks;

namespace System.IO.Pipelines
{
	internal static class TaskHelpers
	{
		public static Task CompletedTask = Task.FromResult(default(object));

		public static Task FromException(Exception exception)
		{
			if (exception == null) throw new ArgumentNullException(nameof(exception));

			var tcs = new TaskCompletionSource<object>();
			tcs.TrySetException(exception);
			return tcs.Task;
		}
		public static Task FromCanceled(CancellationToken _)
		{
			var tcs = new TaskCompletionSource<object>();
			tcs.TrySetCanceled();
			return tcs.Task;
		}
	}
}
