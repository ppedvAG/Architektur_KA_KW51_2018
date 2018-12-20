using ppedv.EverGreen.Logic;
using ppedv.EverGreen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.EverGreen.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("*** EverGreen v0.1 PREMIUM VERSION ***");

            var core = new Core();

            //core.CreateDemoData();

            foreach (var b in core.Repository.GetAll<Tannenbaum>())
            {
                Console.WriteLine($"{b.BaumArt.Name} {b.Height}cm {b.Price:c}");
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
