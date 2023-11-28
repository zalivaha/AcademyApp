using AcademyApp.ApplicationData;
using AcademyApp.PageAdmin;
using AcademyApp.PageStudent;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AcademyApp.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
            TxbLogin.Text = "1";
            PsbPassword.Password = "1";
        }

        private void BtnInLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.User.FirstOrDefault(x => 
                x.Login == TxbLogin.Text && x.Password == PsbPassword.Password);

                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else {
                    AccountHelpClass.Id = userObj.Id;

                    switch (userObj.IdRole) {
                        case 1:
                            AppFrame.frameMain.Navigate(new PageMenuAdmin());
                            //MessageBox.Show("Здравтсвуйте " + userObj.Role.Name + ", " + userObj.Name + "!", "Уведомление",
                            //                    MessageBoxButton.OK, MessageBoxImage.Information);
                                break;
                        case 2:
                            AppFrame.frameMain.Navigate(new PageAccountStudent());
                            //MessageBox.Show("Здравтсвуйте " + userObj.Role.Name + ", " + userObj.Name + "!", "Уведомление",
                            //                    MessageBoxButton.OK, MessageBoxImage.Information);
                                break;
                        default: MessageBox.Show("Данные не обнаружены!", "Уведомление",
                                 MessageBoxButton.OK, MessageBoxImage.Warning);
                                 break;
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageCreateAcc());
        }
    }
}
