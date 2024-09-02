using PLCCommunicationDll;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using VPLogger;

namespace BaoYa_UploadSystem.logic_Interface
{
    public interface IPLCService
    {
        void Init();

        void StartThread();

        void StopThread();

        event EventHandler<Object> OnEventTrigger1;

        event EventHandler<Object> OnEventTrigger2;

        event EventHandler<Object> OnEventTrigger3;

        event EventHandler<Object> OnEventTrigger4;

        event EventHandler<Object> OnEventTrigger5;

        event EventHandler<Object> OnEventTrigger6;

        event EventHandler<Object> OnEventTrigger7;

        event EventHandler<Object> OnEventTrigger8;
    }

    public class BeiFuPlcService : IPLCService
    {
        public event EventHandler<object> OnEventTrigger1;

        public event EventHandler<object> OnEventTrigger2;

        public event EventHandler<object> OnEventTrigger3;

        public event EventHandler<object> OnEventTrigger4;

        public event EventHandler<object> OnEventTrigger5;

        public event EventHandler<object> OnEventTrigger6;

        public event EventHandler<object> OnEventTrigger7;

        public event EventHandler<object> OnEventTrigger8;

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void StartThread()
        {
            throw new NotImplementedException();
        }

        public void StopThread()
        {
            throw new NotImplementedException();
        }
    }

    public class SanLingPlcService : IPLCService
    {
        private bool inService => File.Exists("");
        private SanLingCommunication comm;
        private bool IsStopPlc = false;

        public event EventHandler<object> OnEventTrigger1;

        public event EventHandler<object> OnEventTrigger2;

        public event EventHandler<object> OnEventTrigger3;

        public event EventHandler<object> OnEventTrigger4;

        public event EventHandler<object> OnEventTrigger5;

        public event EventHandler<object> OnEventTrigger6;

        public event EventHandler<object> OnEventTrigger7;

        public event EventHandler<object> OnEventTrigger8;

        public void Init()
        {
            comm = new SanLingCommunication();
            var ret = comm.Connnect(0);
            if (!ret)
            {
                var errorMesg = $"连接PLC{comm.LogicalNum}失败";
                MessageBox.Show(errorMesg);
                Logger.LogError(errorMesg);
            }
        }

        public void StartThread()
        {
            short triggered1 = -999, triggered2 = -999;
            short triggered3 = -999, triggered4 = -999;
            short temp1 = 0, temp2 = 0;
            short temp3 = 0, temp4 = 0;
            new Thread(() =>
            {
                while (!IsStopPlc)
                {
                    Thread.Sleep(10);
                    try
                    {
                        //联机信号
                        if (inService)
                        {
                            comm.Send("D630", 1);
                        }
                        comm.ReadShort("D600", out triggered1);
                        // 20240730增加触发信号log
                        //listbox_show(listBox1, string.Format("D600收到触发信号：{0}", triggered1));
                        if (temp1 != triggered1)
                        {
                            temp1 = triggered1;
                            if (triggered1 > 0 && triggered1 < 4)
                            {
                                try
                                {
                                    OnEventTrigger1?.Invoke(this, triggered1);
                                    //_station1L = 1;
                                    //Thread thAction = new Thread(new ParameterizedThreadStart(sp_writeL));
                                    //thAction.IsBackground = true;
                                    //thAction.Start();
                                    //sendMsg(string.Format("T1,{0}", triggered1));
                                }
                                catch (Exception ex)
                                {
                                    //listbox_show(listBox1, string.Format("出料扫码1触发异常:"));
                                }
                            }
                        }
                        comm.ReadShort("D601", out triggered2);

                        // 20240730增加触发信号log
                        // listbox_show(listBox1, string.Format("D601收到触发信号：{0}", triggered2));
                        if (temp2 != triggered2)
                        {
                            temp2 = triggered2;
                            if (triggered2 > 0 && triggered2 < 4)
                            {
                                //listbox_show(listBox1, string.Format("PLC{2} D{0}地址结果:{1},位置{3}执行拍照", 601, triggered2, 0, triggered2));

                                try
                                {
                                    OnEventTrigger2?.Invoke(this, triggered2);

                                    //_station1L = 2;
                                    //sp_writeR("4C4F4E0D");
                                    //Thread thAction1 = new Thread(new ParameterizedThreadStart(sp_writeR));
                                    //thAction1.IsBackground = true;
                                    //thAction1.Start(triggered1);
                                }
                                catch (Exception ex)
                                {
                                    //listbox_show(listBox1, string.Format("出料扫码2触发异常:"));
                                }
                            }
                        }

                        comm.ReadShort("D602", out triggered3);
                        // 20240730增加触发信号log
                        // listbox_show(listBox1, string.Format("D602收到触发信号：{0}", triggered3));
                        if (temp3 != triggered3)
                        {
                            temp3 = triggered3;
                            if (triggered3 > 0 && triggered3 < 4)
                            {
                                //listbox_show(listBox1, string.Format("PLC{2} D{0}地址结果:{1},位置{3}执行拍照", 602, triggered3, 0, triggered3));

                                try
                                {
                                    //State = true;

                                    //sp_writeUPL("4C4F4E0D");
                                    //Thread thAction2 = new Thread(new ParameterizedThreadStart(sp_writeUPL));
                                    //thAction2.IsBackground = true;
                                    //thAction2.Start(triggered1);
                                    OnEventTrigger3?.Invoke(this, triggered3);
                                }
                                catch (Exception ex)
                                {
                                    // listbox_show(listBox1, string.Format("扫码下2触发异常:"));
                                }
                            }
                        }
                        comm.ReadShort("D603", out triggered4);

                        // 20240730增加触发信号log
                        //listbox_show(listBox1, string.Format("D603收到触发信号：{0}", triggered4));
                        if (temp4 != triggered4)
                        {
                            temp4 = triggered4;
                            if (triggered4 > 0 && triggered4 < 4)
                            {
                                //listbox_show(listBox1, string.Format("PLC{2} D{0}地址结果:{1},位置{3}执行拍照", 603, triggered4, 0, triggered4));
                                try
                                {
                                    // State = false;
                                    //sp_writeUPL("4C4F4E0D");

                                    //Thread thAction2 = new Thread(new ParameterizedThreadStart(sp_writeUPL));
                                    //thAction2.IsBackground = true;
                                    //thAction2.Start(triggered1);
                                    OnEventTrigger4?.Invoke(this, triggered4);
                                }
                                catch (Exception ex)
                                {
                                    //listbox_show(listBox1, string.Format("扫码下2触发异常:"));
                                }
                            }
                        }
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }).Start();
        }

        public void StopThread()
        {
            IsStopPlc = true;
        }
    }
}