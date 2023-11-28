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
    /// Логика взаимодействия для PageAddEvaluation.xaml
    /// </summary>
    public partial class PageAddEvaluation : Page
    {

        public PageAddEvaluation()
        {
            InitializeComponent();

            CmbDiscipline.SelectedValuePath = "Id";
            CmbDiscipline.DisplayMemberPath = "Name";
            CmbDiscipline.ItemsSource = AppConnect.modelOdb.Discipline.ToList();

            CmbGroup.SelectedValuePath = "Id";
            CmbGroup.DisplayMemberPath = "Name";
            CmbGroup.ItemsSource = AppConnect.modelOdb.NameGroup.ToList();

            CmbStudent.SelectedValuePath = "Id";
            CmbStudent.DisplayMemberPath = "Name";
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroup = Convert.ToInt32(CmbGroup.SelectedValue);
            CmbStudent.ItemsSource = AppConnect.modelOdb.Student.Where(x => x.IdNameGroup == SelectGroup).ToList();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(TxbEvaluation.Text) < 2 || int.Parse(TxbEvaluation.Text) > 5)
            {
                MessageBox.Show("Введите корректную оценку!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Journal journalObj = new Journal() { 
                Student = CmbStudent.SelectedItem as Student,
                Evaluation = Convert.ToInt32(TxbEvaluation.Text),
                Discipline = CmbDiscipline.SelectedItem as Discipline,
                NameGroup = CmbGroup.SelectedItem as NameGroup
            };

            AppConnect.modelOdb.Journal.Add(journalObj);
            AppConnect.modelOdb.SaveChanges();
            MessageBox.Show("Оценка успешно добавлена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            AppFrame.frameMain.GoBack();
        }

        private void TxbEvaluation_TextChanged(object sender, RoutedEventArgs e)
        {
                if (Convert.ToInt32(TxbEvaluation.Text) < 2 || int.Parse(TxbEvaluation.Text) > 5)
                {
                    BtnAccept.IsEnabled = false;
                    MessageBox.Show("Неверная оценка!");
                    return;
                }

            BtnAccept.IsEnabled = true;
        }

        private void TxbEvaluation_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }
    }
}
