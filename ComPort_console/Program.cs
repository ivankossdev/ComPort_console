using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComPort_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Старт программы.\n");

            COM StmPort = new COM();
            bool work = true;
            //string tm = DateTime.Now.ToString().Substring(11);

            string full;

            Console.WriteLine("Список достуных портов: \n");
            foreach (string port in StmPort.SearchPort())
            {
                Console.WriteLine(port);
            }
            Console.WriteLine();
           
            while (work)
            {
                full = DateTime.Now.ToString();
                SendMessage(StmPort, full);
                Thread.Sleep(250);
            }

            Console.WriteLine("Для выхода нажмите Enter");
            Console.ReadLine();
        }

        static void ReciveMessage(COM stmPort)
        {
            
            List<string> ports = stmPort.SearchPort();

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
           
            Console.ReadLine();
            stmPort.ClosePort();
        }

        static void SendMessage(COM stmPort, string message)
        {

            List<string> ports = stmPort.SearchPort();

            stmPort.InitPort(ports[0]);
            stmPort.OpenPort();

            try
            {
                stmPort.WritePort(message);
            }
            catch
            {
                Console.WriteLine("Произошла ошибка");
            }
            stmPort.ClosePort();
        }
    }
}
