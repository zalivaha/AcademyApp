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
    public partial class PageStudent : Page
    {
        public PageStudent()
        {
            InitializeComponent();

            CmbFormTime.SelectedValuePath = "Id";
            CmbFormTime.DisplayMemberPath = "Name";
            CmbFormTime.ItemsSource = AppConnect.modelOdb.FormTime.ToList();

            CmbNameGroup.SelectedValuePath = "Id";
            CmbNameGroup.DisplayMemberPath = "Name";
            CmbNameGroup.ItemsSource = AppConnect.modelOdb.NameGroup.ToList();

            CmbSpecial.SelectedValuePath = "Id";
            CmbSpecial.DisplayMemberPath = "Name";
            CmbSpecial.ItemsSource = AppConnect.modelOdb.Special.ToList();

            CmbYear.SelectedValuePath = "Id";
            CmbYear.DisplayMemberPath = "Year";
            CmbYear.ItemsSource = AppConnect.modelOdb.YearAdd.ToList();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student studObj = new Student() {
                    Name = TxbNameStudent.Text,
                    Special = CmbSpecial.SelectedItem as Special,
                    YearAdd = CmbYear.SelectedItem as YearAdd,
                    FormTime = CmbFormTime.SelectedItem as FormTime,
                    NameGroup = CmbNameGroup.SelectedItem as NameGroup
                };

                AppConnect.modelOdb.Student.Add(studObj);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Студент успешно добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frameMain.GoBack();
            }
            catch (Exception ex) {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
