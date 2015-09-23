using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OfficeStruct_Agent_Win.Classes
{
    public class FileQueue : ConcurrentQueue<string>
    {
        private CancellationTokenSource cts;

        public void Enqueue(IEnumerable<string> files)
        {
            foreach (var file in files)
                base.Enqueue(file);
        }

        public void Start()
        {
            cts = new CancellationTokenSource();
            Task.Factory.StartNew(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    string file;
                    if (!TryDequeue(out file))
                    {
                        Thread.Sleep(Shared.Options.DelayBetweenChecks);
                        continue;
                    }
                    Console.WriteLine(file);
                }
            }, cts.Token); // Pass same token to StartNew.
        }
        public void Stop()
        {
            cts.Cancel();
        }
    }
}
