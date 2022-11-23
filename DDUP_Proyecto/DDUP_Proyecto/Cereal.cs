using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace DDUP_Proyecto
{
    public class LineReceivedEventArgs : EventArgs
    {
        public string LineData { get; private set; }

        public LineReceivedEventArgs(string lineData)
        {
            this.LineData = lineData;
        }
    }

    public delegate void LineReceivedEventHandler(object sender, LineReceivedEventArgs Args);

    public class Cereal
    {
        private SerialPort serialPort;
        private Queue<byte> recievedData = new Queue<byte>();

        public event LineReceivedEventHandler LineReceived;

        public Cereal()
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += serialPort_DataReceived;
        }

        public void Open(string port, int baudRate)
        {
            serialPort.PortName = port;
            serialPort.BaudRate = baudRate;
            serialPort.DataBits = 8;
            serialPort.ReadBufferSize = 409600;
            serialPort.NewLine = "F";
            serialPort.ReadTimeout = 1000;  // When using ReadLine it is good to set a timeout.
            serialPort.Open();
        }

        public void Close()
        {
            serialPort.Close();
        }

        public bool IsOpen()
        {
            return serialPort.IsOpen;
        }

        public string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }

        void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
        {
            /*
            byte[] data = new byte[serialPort.BytesToRead];
            serialPort.Read(data, 0, data.Length);
            data.ToList().ForEach(b => recievedData.Enqueue(b));
            processData();

            //raise event here
            */

            if (serialPort.BytesToRead > 13)
            {
                if (this.LineReceived != null)
                    LineReceived(this, new LineReceivedEventArgs(serialPort.ReadExisting()));
            }


        }

        private void processData()
        {
            // Determine if we have a "packet" in the queue
            if (recievedData.Count > 50)
            {
                var packet = Enumerable.Range(0, 50).Select(i => recievedData.Dequeue());
            }
        }

        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }

        public void WriteLine(string text)
        {
            serialPort.WriteLine(text);
        }
    }
}
