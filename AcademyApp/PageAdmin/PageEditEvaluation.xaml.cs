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
    /// Логика взаимодействия для PageEditEvaluation.xaml
    /// </summary>
    public partial class PageEditEvaluation : Page
    {
        public PageEditEvaluation()
        {
            InitializeComponent();

            CmbNameGroup.SelectedValuePath = "Id";
            CmbNameGroup.DisplayMemberPath = "Name";
            CmbNameGroup.ItemsSource = AppConnect.modelOdb.NameGroup.ToList();
        }

        private void BtnEditGrade_Click(object sender, RoutedEventArgs e)
        {

            AppFrame.frameMain.Navigate(new PageEditGradeStudent((sender as Button).DataContext as Student));
        }

        private void CmbNameGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectGroup = Convert.ToInt32(CmbNameGroup.SelectedValue);
            ListStudent.ItemsSource = AppConnect.modelOdb.Student.Where(x => x.IdNameGroup ==SelectGroup).ToList();
            ListStudent.SelectedIndex = 0;
        }
    }
}
