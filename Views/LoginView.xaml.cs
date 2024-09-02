using System.Windows;

namespace BaoYa_UploadSystem.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public bool IsLoggedIn { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = userNameTxt.Text;
            var psw = passwordbox1.Password;
            if (psw != string.Empty)
            {
                MessageBox.Show("密码错误，请重新输入!!");
                return;
            }
            IsLoggedIn = true;
            this.Close();
        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}