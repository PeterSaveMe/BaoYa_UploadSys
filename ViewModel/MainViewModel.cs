using BaoYa_UploadSystem.logic_Interface;
using BaoYa_UploadSystem.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using MdbDataBaseDLL;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace BaoYa_UploadSystem.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private ActionCommand createCmd;
        private ActionCommand deleteCmd;
        private ActionCommand readCmd;
        private ActionCommand updateCmd;
        private BaoYaDatabaseService Service = new BaoYaDatabaseService(@"D:\VP Data\惠州\baoya\2024-09-02.mdb");
        private List<BYData> listdata1 = new List<BYData>();
        private string title;
        private IDataService dataService;
        private ScannerServiceBase scannerService;
        private IPLCService PLCService;

        public MainViewModel()
        {
            Title = $"保压机上传系统 {Assembly.GetExecutingAssembly().GetName().Version}";
            //dataService = new DataService1();
            //dataService.Init();

            //scannerService = new NetScannerService();
            //scannerService.Init();
            //scannerService.OnCodeScanFinised1 += ScannerService_OnCodeScanFinised1;
            //scannerService.OnCodeScanFinised2 += ScannerService_OnCodeScanFinised2;
            //scannerService.OnCodeScanFinised3 += ScannerService_OnCodeScanFinised3;
            //scannerService.OnCodeScanFinised4 += ScannerService_OnCodeScanFinised4;
            //scannerService.OnCodeScanFinised5 += ScannerService_OnCodeScanFinised5;
            //scannerService.OnCodeScanFinised6 += ScannerService_OnCodeScanFinised6;
            //scannerService.OnCodeScanFinised7 += ScannerService_OnCodeScanFinised7;
            //scannerService.OnCodeScanFinised8 += ScannerService_OnCodeScanFinised8;

            //PLCService = new SanLingPlcService();
            //PLCService.Init();
            //PLCService.StartThread();
            //PLCService.OnEventTrigger1 += PLCService_OnEventTrigger1;
            //PLCService.OnEventTrigger2 += PLCService_OnEventTrigger2;
            //PLCService.OnEventTrigger3 += PLCService_OnEventTrigger3;
            //PLCService.OnEventTrigger4 += PLCService_OnEventTrigger4;
            //PLCService.OnEventTrigger5 += PLCService_OnEventTrigger5;
            //PLCService.OnEventTrigger6 += PLCService_OnEventTrigger6;
            //PLCService.OnEventTrigger7 += PLCService_OnEventTrigger7;
            //PLCService.OnEventTrigger8 += PLCService_OnEventTrigger8;

            //UploadJson j = new UploadJson();
            //j.product = "pro";
            //j.barCodeList.Add(new BarCodeList()
            //{
            //    barCode = "123",
            //    errorCode = "123",
            //    fDate = DateTime.Now,
            //    remark = "remark",

            //});
            //j.stationNo = "station1";
            //j.barCodeList[0].testList.Add(new TestList()
            //{
            //    fDescription = "des",
            //    fItem = "item",
            //    fMax = "max",
            //    fMin = "min",
            //    fResult = "1",
            //    fTime = DateTime.Now,
            //    fUnit = "00",
            //    fValue = "11"
            //});
            //j.barCodeList[0].testList.Add(new TestList()
            //{
            //    fDescription = "des1",
            //    fItem = "item1",
            //    fMax = "max1",
            //    fMin = "min1",
            //    fResult = "11",
            //    fTime = DateTime.Now,
            //    fUnit = "001",
            //    fValue = "111"
            //});

            //var jstring = Newtonsoft.Json.JsonConvert.SerializeObject(j);
            //RestClientWrapper restClient = new RestClientWrapper("http://httpbin.org/post");
            //var respond =    restClient.PostAsync("http://httpbin.org/post", j, 20000);

            OutputStatistics data = new OutputStatistics();
            //  var oj =   Newtonsoft.Json.JsonConvert.SerializeObject(output);

            //using (StreamReader sw = new StreamReader(@"C:\Users\Lenovo\Desktop\111.json"))
            //{
            //    var str =  sw.ReadToEnd();
            //    data =   Newtonsoft.Json.JsonConvert.DeserializeObject<OutputStatistics>(str);

            //}
            //List<OutputStatistics> outputStatistics = new List<OutputStatistics>();
            //outputStatistics.Add(new OutputStatistics());
            //outputStatistics.Add(new OutputStatistics());
            //outputStatistics.Add(new OutputStatistics());
            //outputStatistics.Add(new OutputStatistics());
            //outputStatistics.Add(new OutputStatistics());
        }

        private void ScannerService_OnCodeScanFinised8(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void ScannerService_OnCodeScanFinised7(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void ScannerService_OnCodeScanFinised6(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void ScannerService_OnCodeScanFinised5(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void ScannerService_OnCodeScanFinised4(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void ScannerService_OnCodeScanFinised3(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void ScannerService_OnCodeScanFinised2(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void ScannerService_OnCodeScanFinised1(object sender, string e)
        {
            throw new NotImplementedException();
        }

        private void PLCService_OnEventTrigger8(object sender, object e)
        {
            throw new NotImplementedException();
        }

        private void PLCService_OnEventTrigger7(object sender, object e)
        {
            throw new NotImplementedException();
        }

        private void PLCService_OnEventTrigger6(object sender, object e)
        {
            throw new NotImplementedException();
        }

        private void PLCService_OnEventTrigger5(object sender, object e)
        {
            throw new NotImplementedException();
        }

        private void PLCService_OnEventTrigger4(object sender, object e)
        {
            scannerService.Scanner2.EndString = "\r\n";
            scannerService.Scanner2.Send("LON");
        }

        private void PLCService_OnEventTrigger3(object sender, object e)
        {
            scannerService.Scanner2.EndString = "\r\n";
            scannerService.Scanner2.Send("LON");
        }

        private void PLCService_OnEventTrigger2(object sender, object e)
        {
            scannerService.Scanner1.EndString = "\r\n";
            scannerService.Scanner1.Send("LON");
        }

        private void PLCService_OnEventTrigger1(object sender, object e)
        {
            scannerService.Scanner1.EndString = "\r\n";
            scannerService.Scanner1.Send("LON");
        }

        public ICommand CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new ActionCommand(PerformCreateCmd);
                }

                return createCmd;
            }
        }

        public ICommand DeleteCmd
        {
            get
            {
                if (deleteCmd == null)
                {
                    deleteCmd = new ActionCommand(PerformDeleteCmd);
                }

                return deleteCmd;
            }
        }

        public List<BYData> listdata { get => listdata1; set => SetProperty(ref listdata1, value); }

        public ICommand ReadCmd
        {
            get
            {
                if (readCmd == null)
                {
                    readCmd = new ActionCommand(PerformReadCmd);
                }

                return readCmd;
            }
        }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public ICommand UpdateCmd
        {
            get
            {
                if (updateCmd == null)
                {
                    updateCmd = new ActionCommand(PerformUpdateCmd);
                }

                return updateCmd;
            }
        }

        private void PerformCreateCmd()
        {
            Service.InsertData(new BYData()
            {
                BARCODE = "111",
                BARCODE1 = "222",
                BARCODE2 = "333",
                FDATE = DateTime.Now.ToString(),
                LINE_NO = "line1",
                PadBarcode = "23",
            });
        }

        private void PerformDeleteCmd()
        {
            var allData = Service.GetAllData();
            Service.DeleteData(allData.Count - 1);
        }

        private void PerformReadCmd()
        {
            var allData = Service.GetAllData();
            listdata = allData;
        }

        private void PerformUpdateCmd()
        {
            Service.UpdateData(new BYData()
            {
                BARCODE = "222",
                BARCODE1 = "222",
                BARCODE2 = "333",
                FDATE = DateTime.Now.ToString(),
                LINE_NO = "line1",
                PadBarcode = "23",
            });
        }
    }
}