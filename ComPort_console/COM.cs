using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Collections.Specialized;

namespace ComPort_console
{
    public class COM
    {
        SerialPort _serialPort = new SerialPort();

        //00 
        // Создаем список доступных портов 
        public List<string> SearchPort()
        {
            List<string> ports = new List<string>();

            foreach (string serial in PortName())
            {
                ports.Add(serial);
            }
            return ports;
        }

        //01
        //Инициализация порта
        public void InitPort (string serial)
        {
            _serialPort.PortName = serial;
            _serialPort.BaudRate = 9600;
            _serialPort.DataBits = 8;
        }

        //02
        //Открытие порта
        public void OpenPort()
        {
            _serialPort.ReadTimeout = 5000;
            _serialPort.Open();
        }

        //03
        //Закрытие порта
        public void ClosePort()
        {
            _serialPort.Close();
        }

        //04
        //Чтение порта
        public void ReadPort()
        {
           _serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(_serialPort.ReadExisting());
        }

        //05
        //Запись порта
        public void WritePort(string message)
        {
            _serialPort.Write(message);
        }

        //06
        //Поиск доступных портов 
        public StringCollection PortName()
        {
            string[] ports = SerialPort.GetPortNames();
            StringCollection names = new StringCollection();

            if (ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    names.Add(port);
                }
            }
            else
            {
                Console.WriteLine("Not serial port.");
                names.Add(null);
            }
            return names;
        }
    }
}
