using System;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Logger.Instance.Log("Hallo Log");

            Logger.Instance.Log("Ende");
            Console.ReadLine();
        }
    }

    public class Logger
    {
        private static Logger logger = null;

        public static Logger Instance
        {
            get
            {
                if (logger == null)
                    logger = new Logger();
                return logger;
            }
        }

        private Logger()
        { }

        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now}] {msg}");
        }
    }
}
