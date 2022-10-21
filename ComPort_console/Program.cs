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
            bool work = true;

            Console.WriteLine("Список достуных портов: \n");
            foreach (string port in StmPort.SearchPort())
            {
                Console.WriteLine(port);
            }
            Console.WriteLine();
            Console.WriteLine("r  -> Чтение\n" +
                "l1 -> Led 1 On\n" +
                "l2 -> Led 2 On\n" +
                "l3 -> Led 3 On\n" +
                "l4 -> Led 4 On\n" +
                "\nl0 -> led Off\n");
           
            while (work)
            {
                Console.WriteLine("Введите команду: ");
                string type = Console.ReadLine();
                switch (type)
                {
                    case "r":
                        ReciveMessage(StmPort);
                        break;
                    case "l1": 
                        SendMessage(StmPort, "l1;____");
                        break;
                    case "l2":
                        SendMessage(StmPort, "l2;____");
                        break;
                    case "l3":
                        SendMessage(StmPort, "l3;____");
                        break;
                    case "l4":
                        SendMessage(StmPort, "l4;____");
                        break;
                    case "l0": 
                        SendMessage(StmPort, "l0;____");
                        break;
                    default: work = false;
                        break;
                }
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
