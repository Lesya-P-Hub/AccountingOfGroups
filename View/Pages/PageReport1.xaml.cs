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
    /// Логика взаимодействия для PageReport1.xaml
    /// </summary>
    public partial class PageReport1 : Page
    {
        public PageReport1(Group group)
        {
            InitializeComponent();
            JournalDg.ItemsSource = App.context.Acc.Where(x => x.GroupId == group.Id).ToList();
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
                printDialog.PrintVisual(JournalDg, "Баллы");
        }
    }
}
