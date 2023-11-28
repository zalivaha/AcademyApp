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
using System.Windows.Threading;

namespace AcademyApp.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageStudentList.xaml
    /// </summary>
    public partial class PageStudentList : Page
    {
        public PageStudentList()
        {
            InitializeComponent();

            CmbGroup.DisplayMemberPath = "Name";
            CmbGroup.SelectedValuePath = "Id";
            CmbGroup.ItemsSource = AppConnect.modelOdb.NameGroup.ToList();

            ListStudent.ItemsSource = AppConnect.modelOdb.Student.ToList();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += UpdateData;
            timer.Start();
        }

        public void UpdateData(object sender, object e) {
            ListStudent.ItemsSource = AppConnect.modelOdb.Student.ToList();
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Те же действия по кнопке
            int SelectGroup = Convert.ToInt32(CmbGroup.SelectedValue);
            ListStudent.ItemsSource = AppConnect.modelOdb.Student.Where(x => x.IdNameGroup == SelectGroup).ToList();
            ListStudent.SelectedIndex = 0; 
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            //int SelectGroup = Convert.ToInt32(CmbGroup.SelectedValue);
            //ListStudent.ItemsSource = AppConnect.modelOdb.Student.Where(x => x.IdNameGroup == SelectGroup).ToList();
            //ListStudent.SelectedIndex = 0;
        }

        private void BtnSelectStudent_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageJournalStudent((sender as Button).DataContext as Student));
        }
    }
}
