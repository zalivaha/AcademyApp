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

namespace AcademyApp.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageJournalStudent.xaml
    /// </summary>
    public partial class PageJournalStudent : Page
    {
        public PageJournalStudent(Student student)
        {
            InitializeComponent();
            TxtNameStudent.Text = student.Name;
            ListEvaluation.ItemsSource = AppConnect.modelOdb.Journal.Where(x => x.IdStudent == student.Id).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printObj = new PrintDialog();

            if (printObj.ShowDialog() == true)
            {
                BtnBack.Background = Brushes.Transparent;
                BtnBack.BorderBrush = Brushes.Transparent;
                BtnBack.Width = 400;
                BtnBack.Foreground = Brushes.Black;
                BtnBack.Content = "Страница с оценками студента";
                BtnPrint.Visibility = Visibility.Hidden;

                printObj.PrintVisual(GridAll, "");
            }
            else {
                MessageBox.Show("Пользователь прервал печать!", "Уведомление",MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
