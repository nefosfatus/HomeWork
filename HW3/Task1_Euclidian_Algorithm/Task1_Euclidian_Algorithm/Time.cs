using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Euclidian_Algorithm
{
    /// <summary>
    /// Wrapper for Stopwathch
    /// </summary>
    class Time
    {
        public class Benchmark : IDisposable
        {
            //initiaization
            private readonly Stopwatch _timer = new Stopwatch();
            private readonly string _benchmarkName;

            /// <summary>
            /// start method
            /// </summary>
            /// <param name="benchmarkName">Строка описания</param>
            public Benchmark(string benchmarkName)
            {
                this._benchmarkName = benchmarkName;
                _timer.Start();
            }
            /// <summary>
            /// stop method
            /// </summary>
            public void Dispose()
            {
                _timer.Stop();
                Console.WriteLine($"{_benchmarkName} {_timer.Elapsed}");
            }
        }
    }
}
