using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace DDUP_Proyecto
{
    public class LineReceivedEventArgs : EventArgs
    {
        public string LineData { get; }

        public LineReceivedEventArgs(string lineData)
        {
            LineData = lineData;
        }
    }

    public delegate void LineReceivedEventHandler(object sender, LineReceivedEventArgs args);

    public class Cereal : IDisposable
    {
        private readonly SerialPort _serialPort;

        public event LineReceivedEventHandler LineReceived;

        public Cereal()
        {
            _serialPort = new SerialPort();
            _serialPort.DataReceived += serialPort_DataReceived;
        }

        public void Open(string port, int baudRate)
        {
            _serialPort.DtrEnable= true;
            _serialPort.PortName = port;
            _serialPort.BaudRate = baudRate;
            _serialPort.DataBits = 8;
            _serialPort.ReadBufferSize = 409600;
            _serialPort.NewLine = "F";
            _serialPort.ReadTimeout = 1000;  // When using ReadLine it is good to set a timeout.
            _serialPort.Open();
        }

        public void Close()
        {
            _serialPort.Close();
        }

        public bool IsOpen()
        {
            return _serialPort.IsOpen;
        }

        private void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
        {
            /*
            byte[] data = new byte[serialPort.BytesToRead];
            serialPort.Read(data, 0, data.Length);
            data.ToList().ForEach(b => recievedData.Enqueue(b));
            processData();

            //raise event here
            */

            if (_serialPort.BytesToRead > 13)
            {
                if (this.LineReceived != null)
                    LineReceived(this, new LineReceivedEventArgs(_serialPort.ReadExisting()));
            }


        }

        public void Dispose()
        {
            if (_serialPort != null)
                _serialPort.Dispose();
        }

        public void WriteLine(string text)
        {
            _serialPort.WriteLine(text);
        }
    }
}
