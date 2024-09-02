using System;
using TcpCommunicationDLL;

namespace BaoYa_UploadSystem.logic_Interface
{
    public interface IScannerService
    {
        void Init();

        event EventHandler<string> OnCodeScanFinised1;

        event EventHandler<string> OnCodeScanFinised2;

        event EventHandler<string> OnCodeScanFinised3;

        event EventHandler<string> OnCodeScanFinised4;

        event EventHandler<string> OnCodeScanFinised5;

        event EventHandler<string> OnCodeScanFinised6;

        event EventHandler<string> OnCodeScanFinised7;

        event EventHandler<string> OnCodeScanFinised8;
    }

    public abstract class ScannerServiceBase : IScannerService
    {
        public event EventHandler<string> OnCodeScanFinised1;

        public event EventHandler<string> OnCodeScanFinised2;

        public event EventHandler<string> OnCodeScanFinised3;

        public event EventHandler<string> OnCodeScanFinised4;

        public event EventHandler<string> OnCodeScanFinised5;

        public event EventHandler<string> OnCodeScanFinised6;

        public event EventHandler<string> OnCodeScanFinised7;

        public event EventHandler<string> OnCodeScanFinised8;

        public ITcpSerialCommunication Scanner1;
        public ITcpSerialCommunication Scanner2;
        public ITcpSerialCommunication Scanner3;
        public ITcpSerialCommunication Scanner4;
        public ITcpSerialCommunication Scanner5;
        public ITcpSerialCommunication Scanner6;
        public ITcpSerialCommunication Scanner7;
        public ITcpSerialCommunication Scanner8;

        public abstract void Init();
    }

    public class NetScannerService : ScannerServiceBase
    {
        public new event EventHandler<string> OnCodeScanFinised1;

        public new event EventHandler<string> OnCodeScanFinised2;

        public new event EventHandler<string> OnCodeScanFinised3;

        public new event EventHandler<string> OnCodeScanFinised4;

        public new event EventHandler<string> OnCodeScanFinised5;

        public new event EventHandler<string> OnCodeScanFinised6;

        public new event EventHandler<string> OnCodeScanFinised7;

        public new event EventHandler<string> OnCodeScanFinised8;

        public override void Init()
        {
            Scanner1 = new TcpClient();
            Scanner1.OnDataRecevied -= Client1_OnDataRecevied;
            Scanner1.OnDataRecevied -= Client1_OnDataRecevied;
            Scanner1.OnDataRecevied += Client1_OnDataRecevied;
            Scanner1.Connect("", 0);

            Scanner2 = new TcpClient();
            Scanner2.OnDataRecevied -= Client2_OnDataRecevied;
            Scanner2.OnDataRecevied -= Client2_OnDataRecevied;
            Scanner2.OnDataRecevied += Client2_OnDataRecevied;
            Scanner2.Connect("", 0);

            Scanner3 = new TcpClient();
            Scanner3.OnDataRecevied -= Client3_OnDataRecevied;
            Scanner3.OnDataRecevied -= Client3_OnDataRecevied;
            Scanner3.OnDataRecevied += Client3_OnDataRecevied;
            Scanner3.Connect("", 0);

            Scanner4 = new TcpClient();
            Scanner4.OnDataRecevied -= Client4_OnDataRecevied;
            Scanner4.OnDataRecevied -= Client4_OnDataRecevied;
            Scanner4.OnDataRecevied += Client4_OnDataRecevied;
            Scanner4.Connect("", 0);
        }

        private void Client4_OnDataRecevied(object sender, string e)
        {
            OnCodeScanFinised4?.Invoke(null, e);
        }

        private void Client3_OnDataRecevied(object sender, string e)
        {
            OnCodeScanFinised3?.Invoke(null, e);
        }

        private void Client2_OnDataRecevied(object sender, string e)
        {
            OnCodeScanFinised2?.Invoke(null, e);
        }

        private void Client1_OnDataRecevied(object sender, string e)
        {
            OnCodeScanFinised1?.Invoke(null, e);
        }
    }
}