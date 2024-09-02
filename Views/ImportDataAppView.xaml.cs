using BaoYa_UploadSystem.FileOperator;
using BaoYa_UploadSystem.Model;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace BaoYa_UploadSystem.Views
{
    /// <summary>
    /// ImportDataAppView.xaml 的交互逻辑
    /// </summary>
    public partial class ImportDataAppView : Window
    {
        private string filePath;

        public ImportDataAppView()
        {
            InitializeComponent();

            if (File.Exists(PathManageDLL.PathData.externalAppInfo_Path))
            {
                PathBox.Text = JsonHelper.DeserializeFromFile<ExternalAppInfo>(PathManageDLL.PathData.externalAppInfo_Path).AppfileName;
                filePath = PathBox.Text;
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set filter options and filter index
            openFileDialog.Filter = "App files (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            // Call the ShowDialog method to show the dialog box
            bool? result = openFileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filePath = openFileDialog.FileName;
                PathBox.Text = filePath;
                ExternalAppInfo externalAppInfo = new ExternalAppInfo();
                externalAppInfo.AppfileName = filePath;
                JsonHelper.SerializeToFile(externalAppInfo, PathManageDLL.PathData.externalAppInfo_Path);
            }
        }

        private void StartProgramButton_Click(object sender, RoutedEventArgs e)
        {
            AppOperator.AppOp.StartApp(filePath);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}