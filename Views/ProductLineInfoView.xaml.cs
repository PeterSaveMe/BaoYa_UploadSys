using BaoYa_UploadSystem.FileOperator;
using BaoYa_UploadSystem.Model;
using System.IO;
using System.Windows;

namespace BaoYa_UploadSystem.Views
{
    /// <summary>
    /// ProductLineInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class ProductLineInfoView : Window
    {
        public ProductLineInfoView()
        {
            InitializeComponent();
            if (File.Exists(PathManageDLL.PathData.ProductLineInfo_Path))
            {
                LineNameBox.Text = JsonHelper.DeserializeFromFile<ProductLineInfo>(PathManageDLL.PathData.ProductLineInfo_Path).LineName;
            }
        }

        private void Comfirm_Click(object sender, RoutedEventArgs e)
        {
            var v = new ProductLineInfo();
            v.LineName = LineNameBox.Text;

            JsonHelper.SerializeToFile(v, PathManageDLL.PathData.ProductLineInfo_Path);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}