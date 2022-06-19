using MySQL_test.Data.Interfaces;
using MySQL_test.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MySQL_test
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        readonly ILoginRepository _loginRepository;

        public LoginView()
        {
            _loginRepository = new LoginRepository();

            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginTextBox.Text;
            var password = PasswordBox.Password;

            LoginBtn.IsEnabled = false;

            Auth(login, password);
        }

        async void Auth(string login, string password)
        {
            await Task.Run(async () =>
            {
                try
                {
                    var user = await _loginRepository.CheckUserLogin(login, password);

                    if (user != null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            var window = new MainWindow(user);
                            window.Show();
                            Close();
                        });
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль..");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });

            LoginBtn.IsEnabled = true;
        }
    }
}
