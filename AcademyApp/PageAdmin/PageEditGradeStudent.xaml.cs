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
    /// Логика взаимодействия для PageEditGradeStudent.xaml
    /// </summary>
    public partial class PageEditGradeStudent : Page
    {
        public PageEditGradeStudent(Student student)
        {
            InitializeComponent();
            var studentObj = AppConnect.modelOdb.Student.FirstOrDefault(x => x.Id == student.Id);
            TxtNameStudent.Text = studentObj.Name;

            ListGrade.ItemsSource = AppConnect.modelOdb.Journal.Where(x => x.IdStudent == student.Id).ToList();
            ListGrade.Columns[0].IsReadOnly = true;
            ListGrade.SelectedIndex = 0;
        }

        private void BtnEditGrade_Click(object sender, RoutedEventArgs e)
        {
            AppConnect.modelOdb.SaveChanges();
            MessageBox.Show("Данные успешно изменены и сохранились в базе данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
