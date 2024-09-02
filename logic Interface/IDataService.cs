using BaoYa_UploadSystem.FileOperator;
using BaoYa_UploadSystem.Model;
using MdbDataBaseDLL;
using System;

namespace BaoYa_UploadSystem.logic_Interface
{
    public interface IDataService
    {
        void Init();
    }

    public class DataService1 : IDataService
    {
        public void Init()
        {
            //获取统计数据
            var outputStatiscData = new OutputStatisticsDataBaseService(PathManageDLL.PathData.OutputStatiscDataBase_Path);

            //获取UploadInfo
            UploadInfo uploadInfo1 = JsonHelper.DeserializeFromFile<UploadInfo>(PathManageDLL.PathData.UploadInfo1_Path);
            UploadInfo uploadInfo2 = JsonHelper.DeserializeFromFile<UploadInfo>(PathManageDLL.PathData.UploadInfo2_Path);

            //获取PressureParameter
            PressureParameter pressureData = JsonHelper.DeserializeFromFile<PressureParameter>(PathManageDLL.PathData.PressureParameter_Path);

            //保压数据库名称
            var BYDataBase = $@"D:\DATA\{DateTime.Now.ToString("yyyy-MM-dd")}_BY.mdb";
            BaoYaDatabaseService baoYaDatabase = new BaoYaDatabaseService(BYDataBase);

            //包胶数据库名称
            var BJDataBase = $@"D:\DATA\{DateTime.Now.ToString("yyyy-MM-dd")}_BJ.mdb";
            BaoYaDatabaseService baoYaDatabase2 = new BaoYaDatabaseService(BYDataBase);
        }
    }
}