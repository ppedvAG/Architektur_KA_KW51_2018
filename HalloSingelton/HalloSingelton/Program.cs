using System;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => Logger.Instance.Log("Hallo Log"));
            }

            Logger.Instance.Log("Ende");
            Console.ReadLine();
        }
    }

    public class Logger
    {
        private static Logger logger = null;

        private static object syncObject = new object();
        public static Logger Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (logger == null)
                        logger = new Logger();
                }
                return logger;
            }
        }

        static int instCounter = 0;
        private Logger()
        {
            instCounter++;
        }

        public void Log(string msg)
        {
            Console.WriteLine($"({instCounter})[{DateTime.Now}] {msg}");
        }
    }
}
