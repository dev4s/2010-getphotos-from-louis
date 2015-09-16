using System;
using System.Threading;

namespace GetPhotosFromLouis
{
	public class Threads
	{
		private Thread T1 { get; set; }
		private Thread T2 { get; set; }
		private Thread T3 { get; set; }
		private Thread T4 { get; set; }

		private Thread SingleT { get; set; }

		public Threads(int max, Func<int, int, bool> method)
		{
			var piece = max / 4;
			var piece2 = piece + piece;
			var piece3 = piece + piece2;

			T1 = new Thread(() => method(0, piece));
			T2 = new Thread(() => method(piece, piece2));
			T3 = new Thread(() => method(piece2, piece3));
			T4 = new Thread(() => method(piece3, max));
		}
		
		public Threads(Func<bool> method)
		{
			SingleT = new Thread(() => method());
		}

		public void Start()
		{
			if (T1 != null || T2 != null || T3 != null || T4 != null)
			{
				// ReSharper disable PossibleNullReferenceException
				T1.Start();
				T2.Start();
				T3.Start();
				T4.Start();
				// ReSharper restore PossibleNullReferenceException
			}
			else
			{
				SingleT.Start();
			}
		}

		public bool IsRunning()
		{
			if (T1 != null || T2 != null || T3 != null || T4 != null)
			{
				// ReSharper disable PossibleNullReferenceException
				return (T1.ThreadState == ThreadState.Running || T2.ThreadState == ThreadState.Running ||
				        T3.ThreadState == ThreadState.Running || T4.ThreadState == ThreadState.Running);
				// ReSharper restore PossibleNullReferenceException
			}
			return SingleT.ThreadState == ThreadState.Running;
		}

		public static void SleepTime(int value)
		{
			Thread.Sleep(value);
		}

		public void Close()
		{
			if (T1 != null || T2 != null || T3 != null || T4 != null)
			{
				// ReSharper disable PossibleNullReferenceException
				T1.Abort();
				T2.Abort();
				T3.Abort();
				T4.Abort();
				// ReSharper restore PossibleNullReferenceException
			}
			else
			{
				SingleT.Abort();
			}
		}
	}
}
