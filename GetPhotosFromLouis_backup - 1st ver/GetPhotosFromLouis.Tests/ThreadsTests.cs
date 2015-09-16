using System.Collections.Generic;
using NUnit.Framework;

namespace GetPhotosFromLouis.Tests
{
	[TestFixture]
	class ThreadsTests
	{
		private static readonly object Locker = new object();
		private static List<int> _testint;
		private const int SingleValue = 1000000;

		private static bool TestingThreads(int min, int max)
		{
			for (; min < max; min++)
			{
				lock (Locker)
				{
					_testint.Add(min);
				}
			}

			return true;
		}

		private static bool TestingSingleThread()
		{
			for (var i = 0; i < SingleValue; i++)
			{
				_testint.Add(i);
			}
			return true;
		}

		[Test]
		public void DoesThreadsDoWhatTheyHaveToDo()
		{
			_testint = new List<int>();
			const int value = 1000000;
			var threads = new Threads(value, TestingThreads);
			threads.Start();

			while(threads.IsRunning())
			{
				Threads.SleepTime(500);
			}

			_testint.Sort();

			for (var i = 0; i < value; i++)
			{
				Assert.That(_testint[i], Is.EqualTo(i));
			}
		}

		[Test]
		public void LoadSingleTest()
		{
			_testint = new List<int>();
			var threads = new Threads(TestingSingleThread);
			threads.Start();

			while (threads.IsRunning())
			{
				Threads.SleepTime(100);
			}

			for (var i = 0; i < SingleValue; i++)
			{
				Assert.That(_testint[i], Is.EqualTo(i));
			}
		}
	}
}
