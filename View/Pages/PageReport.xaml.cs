using PetrovaControl8.AppData;
using PetrovaControl8.Model;
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

namespace PetrovaControl8.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReport.xaml
    /// </summary>
    public partial class PageReport : Page
    {
        public PageReport()
        {
            InitializeComponent();
            SpezCmb.SelectedValuePath = "Id";
            SpezCmb.DisplayMemberPath = "Name";
            SpezCmb.ItemsSource = App.context.Spez.ToList();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            int SelectedS = Convert.ToInt32(SpezCmb.SelectedValue);
            InfoDg.ItemsSource = App.context.Group.Where(x => x.SpezId == SelectedS).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.BodyFrame.Navigate(new View.Pages.PageReport1((sender as Button).DataContext as Group));
        }
    }
}
