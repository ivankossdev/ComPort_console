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
            ReciveMessage(StmPort);
        }

        static void ReciveMessage(COM stmPort)
        {
            
            List<string> ports = stmPort.SearchPort();

            Console.WriteLine("Список достуных портов: ");
            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }

            stmPort.InitPort(ports[0]);
            stmPort.OpenPort();

            try
            {
                stmPort.ReadPort();
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
            }

            Console.WriteLine("Для выхода нажмите Enter");
            Console.ReadLine();
            stmPort.ClosePort();
        }
    }
}
