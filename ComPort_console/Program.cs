using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComPort_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Старт программы.\n");

            COM StmPort = new COM();
            List<string> ports = StmPort.SearchPort();

            Console.WriteLine("Список достуных портов: ");
            foreach(string port in ports)
            {
                Console.WriteLine(port);
            }

            StmPort.InitPort(ports[0]);
            StmPort.OpenPort();

            try
            {
                StmPort.ReadPort();
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
            }

            Console.WriteLine("Нажмите Enter");
            Console.ReadLine();
            StmPort.ClosePort();
        }
    }
}
