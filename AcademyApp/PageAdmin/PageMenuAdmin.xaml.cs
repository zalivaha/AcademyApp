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
    /// Логика взаимодействия для PageMenuAdmin.xaml
    /// </summary>
    public partial class PageMenuAdmin : Page
    {
        public PageMenuAdmin()
        {
            InitializeComponent();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageStudent());
        }

        private void BtnAddEvaluation_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageAddEvaluation());
        }

        private void BtnListStudent_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageStudentList());
        }

        private void BtnEditEvaluation_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageEditEvaluation());
        }
    }
}
