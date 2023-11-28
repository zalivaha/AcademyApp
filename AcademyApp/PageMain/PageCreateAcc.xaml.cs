using AcademyApp.ApplicationData;
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
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.modelOdb.User.Count(x => x.Login == TxbLogin.Text) > 0) {
                MessageBox.Show("Пользователь с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                User userObj = new User()
                {
                    Login = TxbLogin.Text,
                    Name = TxbName.Text,
                    Password = TxbPass.Text,
                    IdRole = 2,
                    DateIn = DateTime.Now
                };
                //Передача данных в таблицу User с данными в userObj
                AppConnect.modelOdb.User.Add(userObj);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Проверка на корректный ввод пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PsbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TxbPass.Text != PsbPass.Password)
            {
                BtnCreate.IsEnabled = false; //Будет заблокирована кнопка
                PsbPass.Background = Brushes.LightCoral; //Цвет фона кнопки
                PsbPass.BorderBrush = Brushes.Red;
            }
            else {
                BtnCreate.IsEnabled = true; //Будет заблокирована кнопка
                PsbPass.Background = Brushes.LightGreen; //Цвет фона кнопки
                PsbPass.BorderBrush = Brushes.Green;
            }
        }
    }
}
