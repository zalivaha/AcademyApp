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

namespace AcademyApp.PageStudent
{
    /// <summary>
    /// Логика взаимодействия для PageAccountStudent.xaml
    /// </summary>
    public partial class PageAccountStudent : Page
    {
        public PageAccountStudent()
        {
            InitializeComponent();

            var studentObj = AppConnect.modelOdb.User.FirstOrDefault(x => x.Id == AccountHelpClass.Id);

            TxtDateEvent.Text = Convert.ToString(studentObj.DateIn);
            TxtLoginUser.Text = studentObj.Login;
            TxtNameStudent.Text = studentObj.Name;
            listGridView.ItemsSource = AppConnect.modelOdb.User.ToList();
        }
    }
}
