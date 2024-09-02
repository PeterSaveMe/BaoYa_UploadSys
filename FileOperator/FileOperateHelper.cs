using System;
using System.IO;

namespace BaoYa_UploadSystem.FileOperator
{
    public class FileOperateHelper
    {
        public static void DeleteDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                if (dir.Exists)
                {
                    DirectoryInfo[] childs = dir.GetDirectories();
                    foreach (DirectoryInfo child in childs)
                    {
                        child.Delete(true);
                    }
                    dir.Delete(true);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void CreateDirectory(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            try
            {
                if (!Directory.Exists(fileInfo.DirectoryName))
                    Directory.CreateDirectory(fileInfo.DirectoryName);
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                    return;
                File.Delete(fileName);
            }
            catch (Exception)
            {
            }
        }
    }
}