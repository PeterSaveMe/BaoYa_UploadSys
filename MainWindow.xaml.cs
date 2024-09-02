using BaoYa_UploadSystem.ViewModel;
using BaoYa_UploadSystem.Views;
using System.Windows;

namespace BaoYa_UploadSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginView v = new LoginView();
            v.ShowDialog();
            if (v.IsLoggedIn)
            {
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
        }

        private void OpenImportDataApp(object sender, RoutedEventArgs e)
        {
            ImportDataAppView v = new ImportDataAppView();
            v.ShowDialog();
        }

        private void EditProductLineInfo(object sender, RoutedEventArgs e)
        {
            ProductLineInfoView v = new ProductLineInfoView();
            v.ShowDialog();
        }

        private void Window_StateChanged(object sender, System.EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                // 留出边距
                var margin = 1; // 边距大小
                WindowState = WindowState.Normal;
                Left = margin;
                Top = margin;
                Width = SystemParameters.WorkArea.Width - (2 * margin);
                Height = SystemParameters.WorkArea.Height - (2 * margin);
            }
        }
    }
}