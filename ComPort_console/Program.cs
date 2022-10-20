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

            Console.WriteLine("0 -> Чтение\n1 -> Запись");
           
            while (work)
            {
                Console.WriteLine("Выбирите значение: ");
                string type = Console.ReadLine();
                switch (type)
                {
                    case "0":
                        ReciveMessage(StmPort);
                        break;
                    case "1":
                        Console.WriteLine("В разработке");
                        break;
                    default: Console.WriteLine("Ничего не подошло");
                        work = false;
                        break;
                }
            }

            Console.WriteLine("Для выхода нажмите Enter");
            Console.ReadLine();
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
           
            Console.ReadLine();
            stmPort.ClosePort();
        }
    }
}
