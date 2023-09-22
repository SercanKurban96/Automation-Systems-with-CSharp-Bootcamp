using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    internal class Program
    {
        public event EventHandler Started;
        public void Run()
        {
            Console.WriteLine("Program is running.");

            // Eventi tetikle
            OnStarted();
        }

        protected virtual void OnStarted()
        {
            Started?.Invoke(this, EventArgs.Empty);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Started += (sender, e) =>
            {
                Console.WriteLine("OnStarted event has been triggered.");
            };
            program.Run();

            Console.ReadLine();
        }
    }
}
