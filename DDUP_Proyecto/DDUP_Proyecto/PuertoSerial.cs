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

    public class PuertoSerial
    {
        private readonly SerialPort _serialPort;

        public event LineReceivedEventHandler LineReceived;

        public PuertoSerial()
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
            _serialPort.ReadTimeout = 1000;
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

            if (_serialPort.BytesToRead > 13)
            {
                if (LineReceived != null)
                    LineReceived(this, new LineReceivedEventArgs(_serialPort.ReadExisting()));
            }
        }

        public void WriteLine(string text)
        {
            _serialPort.WriteLine(text);
        }
    }
}
